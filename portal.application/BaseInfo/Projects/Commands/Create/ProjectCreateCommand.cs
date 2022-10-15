namespace Portal.Application.BaseInfo.Projects.Commands.Create;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Common;
using Application.Common.Exceptions;
using Domain.BaseInfo.Factories.Projects;
using Domain.BaseInfo.Repositories;
using MediatR;

public class ProjectCreateCommand : ProjectCommand<ProjectCreateCommand>, IRequest<Result<int>>
{
    public class ProjectCreateCommandHandler : IRequestHandler<ProjectCreateCommand, Result<int>>
    {
        private readonly IProjectFactory projectFactory;
        private readonly IProjectDomainRepository projectRepository;
        private readonly ICompanyDomainRepository companyRepository;

        public ProjectCreateCommandHandler(
            IProjectFactory projectFactory,
            IProjectDomainRepository projectRepository,
            ICompanyDomainRepository companyRepository)
        {
            this.projectFactory = projectFactory;
            this.projectRepository = projectRepository;
            this.companyRepository = companyRepository;
        }

        public async Task<Result<int>> Handle(
            ProjectCreateCommand request,
            CancellationToken cancellationToken)
        {
            var company = await this.companyRepository.Find(
                request.Company,
                cancellationToken);

            if (company is null)
            {
                throw new NotFoundException(nameof(company), request.Company);
            }

            var project = this.projectFactory
                .WithName(request.Name)
                .FromCompany(company)
                .Build();

            await this.projectRepository.Save(project, cancellationToken);

            return project.Id;
        }
    }
}