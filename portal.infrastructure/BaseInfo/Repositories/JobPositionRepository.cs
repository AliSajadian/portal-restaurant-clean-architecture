namespace Portal.Infrastructure.BaseInfo.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.BaseInfo.JobPositions;
using Application.BaseInfo.JobPositions.Queries.Common;
using Application.BaseInfo.JobPositions.Queries.Details;
using AutoMapper;
using Common.Events;
using Common.Repositories;
using Domain.BaseInfo.Models.JobPositions;
using Domain.BaseInfo.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

internal class JobPositionRepository : DataRepository<IBaseInfoDbContext, JobPosition>,
    IJobPositionDomainRepository,
    IJobPositionQueryRepository
{
    public JobPositionRepository(
        IBaseInfoDbContext db,
        IMapper mapper,
        IEventDispatcher eventDispatcher)
        : base(db, mapper, eventDispatcher)
    {
    }

    public async Task<JobPosition?> Find(
        int id,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<JobPosition?> Find(
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
        var jobPosition = await this.Data.JobPositions.FindAsync(id);

        if (jobPosition is null)
        {
            return false;
        }

        this.Data.JobPositions.Remove(jobPosition);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<JobPositionDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<JobPositionDetailsResponseModel>(this
                .AllAsNoTracking()
                .Where(a => a.Id == id))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<int> Total(
        Specification<JobPosition> specification,
        CancellationToken cancellationToken = default)
        => await this
            .GetJobPositionsQuery(specification)
            .CountAsync(cancellationToken);

    public async Task<IEnumerable<JobPositionResponseModel>> GetJobPositionsListing(
        Specification<JobPosition> specification,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<JobPositionResponseModel>(this
                .GetJobPositionsQuery(specification)
                .OrderBy(a => a.Name)
                .Skip(skip)
                .Take(take))
            .ToListAsync(cancellationToken);

    private IQueryable<JobPosition> GetJobPositionsQuery(
        Specification<JobPosition> specification)
        => this
            .AllAsNoTracking()
            .Where(specification);
}