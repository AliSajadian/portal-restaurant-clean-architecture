namespace Portal.Domain.BaseInfo.Repositories;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Models.Companies;

public interface ICompanyDomainRepository : IDomainRepository<Company>
{
    Task<Company?> Find(
        int id,
        CancellationToken cancellationToken = default);

    Task<Company?> Find(
        string name,
        CancellationToken cancellationToken = default);

    Task<bool> Delete(
        int id,
        CancellationToken cancellationToken = default);
}