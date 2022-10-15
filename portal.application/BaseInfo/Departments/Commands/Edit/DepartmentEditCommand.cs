namespace Portal.Application.BaseInfo.Departments.Commands.Edit;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Models;
using Common;
using Domain.BaseInfo.Repositories;
using MediatR;

public class DepartmentEditCommand : DepartmentCommand<DepartmentEditCommand>, IRequest<Result<int>>
{
    public class DepartmentEditCommandHandler : IRequestHandler<DepartmentEditCommand, Result<int>>
    {
        private readonly IDepartmentDomainRepository departmentRepository;
        private readonly ICompanyDomainRepository companyRepository;
        
        public DepartmentEditCommandHandler(
            IDepartmentDomainRepository departmentRepository,
            ICompanyDomainRepository companyRepository)
        {
            this.departmentRepository = departmentRepository;
            this.companyRepository = companyRepository;
        } 
                

        public async Task<Result<int>> Handle(
            DepartmentEditCommand request,
            CancellationToken cancellationToken)
        {
            var department = await this.departmentRepository.Find(
                request.Id,
                cancellationToken);

            if (department is null)
            {
                throw new NotFoundException(nameof(department), request.Id);
            }

            var company = await this.companyRepository.Find(
                request.Company,
                cancellationToken);

            if (company is null)
            {
                throw new NotFoundException(nameof(company), request.Company);
            }

            department.UpdateName(request.Name)
                      .UpdateCompany(company);

            await this.departmentRepository.Save(department, cancellationToken);

            return department.Id;
        }
    }
}