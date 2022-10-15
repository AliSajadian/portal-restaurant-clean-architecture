namespace Portal.Infrastructure.BaseInfo.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.BaseInfo.Departments;
using Application.BaseInfo.Departments.Queries.Common;
using Application.BaseInfo.Departments.Queries.Details;
using AutoMapper;
using Common.Events;
using Common.Repositories;
using Domain.BaseInfo.Models.Departments;
using Domain.BaseInfo.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

internal class DepartmentRepository : DataRepository<IBaseInfoDbContext, Department>,
    IDepartmentDomainRepository,
    IDepartmentQueryRepository
{
    public DepartmentRepository(
        IBaseInfoDbContext db,
        IMapper mapper,
        IEventDispatcher eventDispatcher)
        : base(db, mapper, eventDispatcher)
    {
    }

    public async Task<Department?> Find(
        int id,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<Department?> Find(
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
        var department = await this.Data.Departments.FindAsync(id);

        if (department is null)
        {
            return false;
        }

        this.Data.Departments.Remove(department);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<DepartmentDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<DepartmentDetailsResponseModel>(this
                .AllAsNoTracking()
                .Where(a => a.Id == id))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<int> Total(
        Specification<Department> specification,
        CancellationToken cancellationToken = default)
        => await this
            .GetDepartmentsQuery(specification)
            .CountAsync(cancellationToken);

    public async Task<IEnumerable<DepartmentResponseModel>> GetDepartmentsListing(
        Specification<Department> specification,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<DepartmentResponseModel>(this
                .GetDepartmentsQuery(specification)
                .OrderBy(a => a.Name)
                .Skip(skip)
                .Take(take))
            .ToListAsync(cancellationToken);

    private IQueryable<Department> GetDepartmentsQuery(
        Specification<Department> specification)
        => this
            .AllAsNoTracking()
            .Where(specification);
}