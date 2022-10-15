namespace Portal.Domain.BaseInfo.Repositories;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Models.JobPositions;

public interface IJobPositionDomainRepository : IDomainRepository<JobPosition>
{
    Task<JobPosition?> Find(
        int id,
        CancellationToken cancellationToken = default);
    Task<JobPosition?> Find(
        string name,
        CancellationToken cancellationToken = default);

    Task<bool> Delete(
        int id,
        CancellationToken cancellationToken = default);
}