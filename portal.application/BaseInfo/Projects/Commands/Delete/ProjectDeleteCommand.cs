namespace Portal.Application.BaseInfo.Projects.Commands.Delete;

using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Models;
using Domain.BaseInfo.Repositories;
using MediatR;

public class ProjectDeleteCommand : EntityCommand<int>, IRequest<Result>
{
    public class ProjectDeleteCommandHandler : IRequestHandler<ProjectDeleteCommand, Result>
    {
        private readonly IProjectDomainRepository projectRepository;

        public ProjectDeleteCommandHandler(IProjectDomainRepository projectRepository)
            => this.projectRepository = projectRepository;

        public async Task<Result> Handle(
            ProjectDeleteCommand request,
            CancellationToken cancellationToken)
            => await this.projectRepository.Delete(
                request.Id,
                cancellationToken);
    }
}