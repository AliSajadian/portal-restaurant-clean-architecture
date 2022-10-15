namespace Portal.Application.BaseInfo.Projects;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Domain.BaseInfo.Models.Projects;
using Domain.Common;
using Queries.Common;
using Queries.Details;

public interface IProjectQueryRepository : IQueryRepository<Project>
{
    Task<ProjectDetailsResponseModel?> Details(
        int id,
        CancellationToken cancellationToken = default);

    Task<int> Total(
        Specification<Project> specification,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<ProjectResponseModel>> GetProjectsListing(
        Specification<Project> specification,
        int skip = 0,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default);
}