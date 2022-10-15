namespace Portal.Domain.BaseInfo.Repositories;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Models.Employees;

public interface IEmployeeDomainRepository : IDomainRepository<Employee>
{
    Task<Employee?> Find(
        int id,
        CancellationToken cancellationToken = default);
    Task<Employee?> Find(
        string personelCode,
        CancellationToken cancellationToken = default);

    Task<bool> Delete(
        int id,
        CancellationToken cancellationToken = default);
}