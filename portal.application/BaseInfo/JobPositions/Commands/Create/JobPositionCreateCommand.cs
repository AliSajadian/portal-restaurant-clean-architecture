namespace Portal.Application.BaseInfo.JobPositions.Commands.Create;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Common;
using Domain.BaseInfo.Factories.JobPositions;
using Domain.BaseInfo.Repositories;
using MediatR;

public class JobPositionCreateCommand : JobPositionCommand<JobPositionCreateCommand>, IRequest<Result<int>>
{
    public class JobPositionCreateCommandHandler : IRequestHandler<JobPositionCreateCommand, Result<int>>
    {
        private readonly IJobPositionFactory jobPositionFactory;
        private readonly IJobPositionDomainRepository jobPositionRepository;

        public JobPositionCreateCommandHandler(
            IJobPositionFactory jobPositionFactory,
            IJobPositionDomainRepository jobPositionRepository)
        {
            this.jobPositionFactory = jobPositionFactory;
            this.jobPositionRepository = jobPositionRepository;
        }

        public async Task<Result<int>> Handle(
            JobPositionCreateCommand request,
            CancellationToken cancellationToken)
        {
            var jobPosition = this.jobPositionFactory
                .WithName(request.Name)
                .Build();

            await this.jobPositionRepository.Save(jobPosition, cancellationToken);

            return jobPosition.Id;
        }
    }
}