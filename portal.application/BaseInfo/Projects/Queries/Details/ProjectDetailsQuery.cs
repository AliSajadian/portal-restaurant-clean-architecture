namespace Portal.Application.BaseInfo.Projects.Queries.Details;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class ProjectDetailsQuery : IRequest<ProjectDetailsResponseModel?>
{
    public int Id { get; init; }

    public class ProjectDetailsQueryHandler : IRequestHandler<ProjectDetailsQuery, ProjectDetailsResponseModel?>
    {
        private readonly IProjectQueryRepository projectRepository;

        public ProjectDetailsQueryHandler(IProjectQueryRepository projectRepository)
            => this.projectRepository = projectRepository;

        public async Task<ProjectDetailsResponseModel?> Handle(
            ProjectDetailsQuery request,
            CancellationToken cancellationToken)
            => await this.projectRepository.Details(
                request.Id,
                cancellationToken);
    }
}