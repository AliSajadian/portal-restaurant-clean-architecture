namespace Portal.Domain.BaseInfo.Repositories;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Models.Projects;

public interface IProjectDomainRepository : IDomainRepository<Project>
{
    Task<Project?> Find(
        int id,
        CancellationToken cancellationToken = default);
    Task<Project?> Find(
        string name,
        CancellationToken cancellationToken = default);

    Task<bool> Delete(
        int id,
        CancellationToken cancellationToken = default);
}