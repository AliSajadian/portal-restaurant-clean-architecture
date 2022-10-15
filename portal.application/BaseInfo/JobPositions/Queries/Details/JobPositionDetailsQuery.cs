namespace Portal.Application.BaseInfo.JobPositions.Queries.Details;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class JobPositionDetailsQuery : IRequest<JobPositionDetailsResponseModel?>
{
    public int Id { get; init; }

    public class JobPositionDetailsQueryHandler : IRequestHandler<JobPositionDetailsQuery, JobPositionDetailsResponseModel?>
    {
        private readonly IJobPositionQueryRepository jobPositionRepository;

        public JobPositionDetailsQueryHandler(IJobPositionQueryRepository jobPositionRepository)
            => this.jobPositionRepository = jobPositionRepository;

        public async Task<JobPositionDetailsResponseModel?> Handle(
            JobPositionDetailsQuery request,
            CancellationToken cancellationToken)
            => await this.jobPositionRepository.Details(
                request.Id,
                cancellationToken);
    }
}