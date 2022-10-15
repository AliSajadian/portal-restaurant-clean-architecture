namespace Portal.Domain.BaseInfo.Repositories;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Models.Departments;

public interface IDepartmentDomainRepository : IDomainRepository<Department>
{
    Task<Department?> Find(
        int id,
        CancellationToken cancellationToken = default);

    Task<Department?> Find(
        string name,
        CancellationToken cancellationToken = default); 

    Task<bool> Delete(
        int id,
        CancellationToken cancellationToken = default);
}