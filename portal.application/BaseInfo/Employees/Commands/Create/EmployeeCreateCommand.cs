namespace Portal.Application.BaseInfo.Employees.Commands.Create;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.Common.Exceptions;
using Common;
using Domain.BaseInfo.Factories.Employees;
using Domain.BaseInfo.Repositories;
using MediatR;

public class EmployeeCreateCommand : EmployeeCommand<EmployeeCreateCommand>, IRequest<Result<int>>
{
    public class EmployeeCreateCommandHandler : IRequestHandler<EmployeeCreateCommand, Result<int>>
    {
        private readonly IEmployeeFactory employeeFactory;
        private readonly IEmployeeDomainRepository employeeRepository;
        private readonly IDepartmentDomainRepository departmentRepository;
        private readonly IProjectDomainRepository projectRepository;
        private readonly IJobPositionDomainRepository jobPositionRepository;

        public EmployeeCreateCommandHandler(
            IEmployeeFactory employeeFactory,
            IEmployeeDomainRepository employeeRepository,
            IJobPositionDomainRepository jobPositionRepository,
            IDepartmentDomainRepository departmentRepository,
            IProjectDomainRepository projectRepository)
        {
            this.employeeFactory = employeeFactory;
            this.employeeRepository = employeeRepository;
            this.jobPositionRepository = jobPositionRepository;
            this.departmentRepository = departmentRepository;
            this.projectRepository = projectRepository;
        }

        public async Task<Result<int>> Handle(
            EmployeeCreateCommand request,
            CancellationToken cancellationToken)
        {
            var jobPosition = await this.jobPositionRepository.Find(
                request.JobPosition,
                cancellationToken);

            if (jobPosition is null)
            {
                throw new NotFoundException(nameof(jobPosition), request.JobPosition);
            }

            var department = await this.departmentRepository.Find(
                request.Department,
                cancellationToken);

            if (department is null)
            {
                throw new NotFoundException(nameof(department), request.Department);
            }

            var project = await this.projectRepository.Find(
                request.Project,
                cancellationToken);

            if (project is null)
            {
                throw new NotFoundException(nameof(project), request.Project);
            }

            var employee = this.employeeFactory
                .WithPersonelCode(request.PersonelCode)
                .WithFirstName(request.FirstName)
                .WithLastName(request.LastName)
                .WithGender(request.Gender)
                .WithPhone(request.Phone)
                .WithEmail(request.Email)
                .WithIsActive(request.IsActive)
                .FromSection(department, project)
                .FromJobPosition(jobPosition)
                .Build();

            await this.employeeRepository.Save(employee, cancellationToken);

            return employee.Id;
        }
    }
}