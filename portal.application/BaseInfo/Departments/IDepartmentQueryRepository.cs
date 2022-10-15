namespace Portal.Application.BaseInfo.Departments;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.BaseInfo.Models.Departments;
using Domain.Common;
using Queries.Common;
using Queries.Details;

public interface IDepartmentQueryRepository : IQueryRepository<Department>
{
    Task<DepartmentDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default);

    Task<int> Total(
        Specification<Department> specification,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<DepartmentResponseModel>> GetDepartmentsListing(
        Specification<Department> specification,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default);
}