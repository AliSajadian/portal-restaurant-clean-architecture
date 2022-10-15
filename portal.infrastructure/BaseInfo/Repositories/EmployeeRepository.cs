namespace Portal.Infrastructure.BaseInfo.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.BaseInfo.Employees;
using Application.BaseInfo.Employees.Queries.Common;
using Application.BaseInfo.Employees.Queries.Details;
using AutoMapper;
using Common.Events;
using Common.Repositories;
using Domain.BaseInfo.Models.Employees;
using Domain.BaseInfo.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

internal class EmployeeRepository : DataRepository<IBaseInfoDbContext, Employee>,
    IEmployeeDomainRepository,
    IEmployeeQueryRepository
{
    public EmployeeRepository(
        IBaseInfoDbContext db,
        IMapper mapper,
        IEventDispatcher eventDispatcher)
        : base(db, mapper, eventDispatcher)
    {
    }

    public async Task<Employee?> Find(
        int id,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<Employee?> Find(
        string personelCode,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(a => a.PersonelCode == personelCode)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<bool> Delete(
        int id,
        CancellationToken cancellationToken = default)
    {
        var employee = await this.Data.Employees.FindAsync(id);

        if (employee is null)
        {
            return false;
        }

        this.Data.Employees.Remove(employee);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<EmployeeDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<EmployeeDetailsResponseModel>(this
                .AllAsNoTracking()
                .Where(a => a.Id == id))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<int> Total(
        Specification<Employee> specification,
        CancellationToken cancellationToken = default)
        => await this
            .GetEmployeesQuery(specification)
            .CountAsync(cancellationToken);

    public async Task<IEnumerable<EmployeeResponseModel>> GetEmployeesListing(
        Specification<Employee> specification,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<EmployeeResponseModel>(this
                .GetEmployeesQuery(specification)
                .OrderBy(a => a.LastName)
                .Skip(skip)
                .Take(take))
            .ToListAsync(cancellationToken);

    private IQueryable<Employee> GetEmployeesQuery(
        Specification<Employee> specification)
        => this
            .AllAsNoTracking()
            .Where(specification);
}