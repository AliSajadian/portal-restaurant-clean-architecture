namespace Portal.Application.BaseInfo.Projects.Queries.Search;

using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.BaseInfo.Models.Projects;
using Domain.BaseInfo.Specifications.Projects;
using Domain.Common;
using MediatR;

public class ProjectsSearchQuery : IRequest<ProjectsSearchResponseModel>
{
    private const int ProjectsPerPage = 10;

    public string? Name { get; init; }

    public int Page { get; init; } = 1;

    public class ProjectsSearchQueryHandler : IRequestHandler<ProjectsSearchQuery, ProjectsSearchResponseModel>
    {
        private readonly IProjectQueryRepository projectRepository;

        public ProjectsSearchQueryHandler(IProjectQueryRepository projectRepository)
            => this.projectRepository = projectRepository;

        public async Task<ProjectsSearchResponseModel> Handle(
            ProjectsSearchQuery request,
            CancellationToken cancellationToken)
        {
            var specification = this.GetProjectSpecification(request);

            var skip = (request.Page - 1) * ProjectsPerPage;

            var companiesListing = await this.projectRepository.GetProjectsListing(
                specification,
                skip,
                take: ProjectsPerPage,
                cancellationToken);

            var totalProjects = await this.projectRepository.Total(
                specification,
                cancellationToken);

            var totalPages = (int)Math.Ceiling((double)totalProjects / ProjectsPerPage);

            return new ProjectsSearchResponseModel(companiesListing, request.Page, totalPages);
        }

        private Specification<Project> GetProjectSpecification(
            ProjectsSearchQuery request)
            => new ProjectByNameSpecification(request.Name);
    }
}