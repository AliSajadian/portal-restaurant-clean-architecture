namespace Portal.Application.BaseInfo.Projects.Commands.Edit;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Models;
using Common;
using Domain.BaseInfo.Repositories;
using MediatR;

public class ProjectEditCommand : ProjectCommand<ProjectEditCommand>, IRequest<Result<int>>
{
    public class ProjectEditCommandHandler : IRequestHandler<ProjectEditCommand, Result<int>>
    {
        private readonly IProjectDomainRepository projectRepository;
        private readonly ICompanyDomainRepository companyRepository;
        
        public ProjectEditCommandHandler(
            IProjectDomainRepository projectRepository,
            ICompanyDomainRepository companyRepository)
        {
            this.projectRepository = projectRepository;
            this.companyRepository = companyRepository;
        } 
                

        public async Task<Result<int>> Handle(
            ProjectEditCommand request,
            CancellationToken cancellationToken)
        {
            var project = await this.projectRepository.Find(
                request.Id,
                cancellationToken);

            if (project is null)
            {
                throw new NotFoundException(nameof(project), request.Id);
            }

            var company = await this.companyRepository.Find(
                request.Company,
                cancellationToken);

            if (company is null)
            {
                throw new NotFoundException(nameof(company), request.Company);
            }

            project.UpdateName(request.Name)
                   .UpdateCompany(company);

            await this.projectRepository.Save(project, cancellationToken);

            return project.Id;
        }
    }
}