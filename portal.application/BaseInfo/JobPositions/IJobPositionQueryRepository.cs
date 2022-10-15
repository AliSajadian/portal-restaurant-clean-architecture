namespace Portal.Application.BaseInfo.JobPositions;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.BaseInfo.Models.JobPositions;
using Domain.Common;
using Queries.Common;
using Queries.Details;

public interface IJobPositionQueryRepository : IQueryRepository<JobPosition>
{
    Task<JobPositionDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default);

    Task<int> Total(
        Specification<JobPosition> specification,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<JobPositionResponseModel>> GetJobPositionsListing(
        Specification<JobPosition> specification,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default);
}