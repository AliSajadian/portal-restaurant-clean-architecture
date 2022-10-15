namespace Portal.Application.BaseInfo.JobPositions.Commands.Delete;

using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Models;
using Domain.BaseInfo.Repositories;
using MediatR;

public class JobPositionDeleteCommand : EntityCommand<int>, IRequest<Result>
{
    public class JobPositionDeleteCommandHandler : IRequestHandler<JobPositionDeleteCommand, Result>
    {
        private readonly IJobPositionDomainRepository jobPositionRepository;

        public JobPositionDeleteCommandHandler(IJobPositionDomainRepository jobPositionRepository)
            => this.jobPositionRepository = jobPositionRepository;

        public async Task<Result> Handle(
            JobPositionDeleteCommand request,
            CancellationToken cancellationToken)
            => await this.jobPositionRepository.Delete(
                request.Id,
                cancellationToken);
    }
}