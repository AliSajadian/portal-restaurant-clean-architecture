namespace Portal.Infrastructure.BaseInfo.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.BaseInfo.Projects;
using Application.BaseInfo.Projects.Queries.Common;
using Application.BaseInfo.Projects.Queries.Details;
using AutoMapper;
using Common.Events;
using Common.Repositories;
using Domain.BaseInfo.Models.Projects;
using Domain.BaseInfo.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

internal class ProjectRepository : DataRepository<IBaseInfoDbContext, Project>,
    IProjectDomainRepository,
    IProjectQueryRepository
{
    public ProjectRepository(
        IBaseInfoDbContext db,
        IMapper mapper,
        IEventDispatcher eventDispatcher)
        : base(db, mapper, eventDispatcher)
    {
    }

    public async Task<Project?> Find(
        int id,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<Project?> Find(
        string name,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(a => a.Name == name)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<bool> Delete(
        int id,
        CancellationToken cancellationToken = default)
    {
        var project = await this.Data.Projects.FindAsync(id);

        if (project is null)
        {
            return false;
        }

        this.Data.Projects.Remove(project);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<ProjectDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<ProjectDetailsResponseModel>(this
                .AllAsNoTracking()
                .Where(a => a.Id == id))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<int> Total(
        Specification<Project> specification,
        CancellationToken cancellationToken = default)
        => await this
            .GetProjectsQuery(specification)
            .CountAsync(cancellationToken);

    public async Task<IEnumerable<ProjectResponseModel>> GetProjectsListing(
        Specification<Project> specification,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<ProjectResponseModel>(this
                .GetProjectsQuery(specification)
                .OrderBy(a => a.Name)
                .Skip(skip)
                .Take(take))
            .ToListAsync(cancellationToken);

    private IQueryable<Project> GetProjectsQuery(
        Specification<Project> specification)
        => this
            .AllAsNoTracking()
            .Where(specification);
}