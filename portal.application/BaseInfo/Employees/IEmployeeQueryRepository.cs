namespace Portal.Application.BaseInfo.Employees;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.BaseInfo.Models.Employees;
using Domain.Common;
using Queries.Common;
using Queries.Details;

public interface IEmployeeQueryRepository : IQueryRepository<Employee>
{
    Task<EmployeeDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default);

    Task<int> Total(
        Specification<Employee> specification,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<EmployeeResponseModel>> GetEmployeesListing(
        Specification<Employee> specification,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default);
}