namespace Portal.Application.BaseInfo.Departments.Commands.Create;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Common;
using Application.Common.Exceptions;
using Domain.BaseInfo.Factories.Departments;
using Domain.BaseInfo.Repositories;
using MediatR;

public class DepartmentCreateCommand : DepartmentCommand<DepartmentCreateCommand>, IRequest<Result<int>>
{
    public class DepartmentCreateCommandHandler : IRequestHandler<DepartmentCreateCommand, Result<int>>
    {
        private readonly IDepartmentFactory departmentFactory;
        private readonly IDepartmentDomainRepository departmentRepository;
        private readonly ICompanyDomainRepository companyRepository;

        public DepartmentCreateCommandHandler(
            IDepartmentFactory departmentFactory,
            IDepartmentDomainRepository departmentRepository,
            ICompanyDomainRepository companyRepository)
        {
            this.departmentFactory = departmentFactory;
            this.departmentRepository = departmentRepository;
            this.companyRepository = companyRepository;
        }

        public async Task<Result<int>> Handle(
            DepartmentCreateCommand request,
            CancellationToken cancellationToken)
        {
            var company = await this.companyRepository.Find(
                request.Company,
                cancellationToken);

            if (company is null)
            {
                throw new NotFoundException(nameof(company), request.Company);
            }
            
            var department = this.departmentFactory
                .WithName(request.Name)
                .FromCompany(company)
                .Build();

            await this.departmentRepository.Save(department, cancellationToken);

            return department.Id;
        }
    }
}