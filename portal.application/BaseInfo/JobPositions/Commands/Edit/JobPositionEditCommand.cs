namespace Portal.Application.BaseInfo.JobPositions.Commands.Edit;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Models;
using Common;
using Domain.BaseInfo.Repositories;
using MediatR;

public class JobPositionEditCommand : JobPositionCommand<JobPositionEditCommand>, IRequest<Result<int>>
{
    public class JobPositionEditCommandHandler : IRequestHandler<JobPositionEditCommand, Result<int>>
    {
        private readonly IJobPositionDomainRepository jobPositionRepository;

        public JobPositionEditCommandHandler(IJobPositionDomainRepository jobPositionRepository)
            => this.jobPositionRepository = jobPositionRepository;

        public async Task<Result<int>> Handle(
            JobPositionEditCommand request,
            CancellationToken cancellationToken)
        {
            var jobPosition = await this.jobPositionRepository.Find(
                request.Id,
                cancellationToken);

            if (jobPosition is null)
            {
                throw new NotFoundException(nameof(jobPosition), request.Id);
            }

            jobPosition.UpdateName(request.Name);

            await this.jobPositionRepository.Save(jobPosition, cancellationToken);

            return jobPosition.Id;
        }
    }
}