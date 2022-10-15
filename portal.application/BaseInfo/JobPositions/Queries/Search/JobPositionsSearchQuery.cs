namespace Portal.Application.BaseInfo.JobPositions.Queries.Search;

using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.BaseInfo.Models.JobPositions;
using Domain.BaseInfo.Specifications.JobPositions;
using Domain.Common;
using MediatR;

public class JobPositionsSearchQuery : IRequest<JobPositionsSearchResponseModel>
{
    private const int JobPositionsPerPage = 10;

    public string? Name { get; init; }

    public int Page { get; init; } = 1;

    public class JobPositionsSearchQueryHandler : IRequestHandler<JobPositionsSearchQuery, JobPositionsSearchResponseModel>
    {
        private readonly IJobPositionQueryRepository jobPositionRepository;

        public JobPositionsSearchQueryHandler(IJobPositionQueryRepository jobPositionRepository)
            => this.jobPositionRepository = jobPositionRepository;

        public async Task<JobPositionsSearchResponseModel> Handle(
            JobPositionsSearchQuery request,
            CancellationToken cancellationToken)
        {
            var specification = this.GetJobPositionSpecification(request);

            var skip = (request.Page - 1) * JobPositionsPerPage;

            var companiesListing = await this.jobPositionRepository.GetJobPositionsListing(
                specification,
                skip,
                take: JobPositionsPerPage,
                cancellationToken);

            var totalJobPositions = await this.jobPositionRepository.Total(
                specification,
                cancellationToken);

            var totalPages = (int)Math.Ceiling((double)totalJobPositions / JobPositionsPerPage);

            return new JobPositionsSearchResponseModel(companiesListing, request.Page, totalPages);
        }

        private Specification<JobPosition> GetJobPositionSpecification(
            JobPositionsSearchQuery request)
            => new JobPositionByNameSpecification(request.Name);
    }
}