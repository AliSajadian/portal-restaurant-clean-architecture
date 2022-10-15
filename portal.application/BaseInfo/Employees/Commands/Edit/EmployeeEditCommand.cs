namespace Portal.Application.BaseInfo.Employees.Commands.Edit;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Models;
using Common;
using Domain.BaseInfo.Repositories;
using MediatR;

public class EmployeeEditCommand : EmployeeCommand<EmployeeEditCommand>, IRequest<Result<int>>
{
    public class EmployeeEditCommandHandler : IRequestHandler<EmployeeEditCommand, Result<int>>
    {
        private readonly IEmployeeDomainRepository employeeRepository;
        private readonly IDepartmentDomainRepository departmentRepository;
        private readonly IProjectDomainRepository projectRepository;
        private readonly IJobPositionDomainRepository jobPositionRepository;

        
        public EmployeeEditCommandHandler(
            IEmployeeDomainRepository employeeRepository,
            IDepartmentDomainRepository departmentRepository,
            IJobPositionDomainRepository jobPositionRepository,
            IProjectDomainRepository projectRepository)
        {
            this.employeeRepository = employeeRepository;
            this.jobPositionRepository = jobPositionRepository;
            this.departmentRepository = departmentRepository;
            this.projectRepository = projectRepository;
        } 
                

        public async Task<Result<int>> Handle(
            EmployeeEditCommand request,
            CancellationToken cancellationToken)
        {
            var employee = await this.employeeRepository.Find(
                request.Id,
                cancellationToken);

            if (employee is null)
            {
                throw new NotFoundException(nameof(employee), request.Id);
            }

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


            employee.UpdatePersonelCode(request.PersonelCode)
                    .UpdateFirstName(request.FirstName)
                    .UpdateLastName(request.LastName)
                    .UpdateGender(request.Gender)
                    .UpdatePicture(request.Picture)
                    .UpdatePhone(request.Phone)
                    .UpdateEmail(request.Email)
                    .UpdateIsActive(request.IsActive)
                    .UpdateJobPosition(jobPosition)
                    .UpdateProject(project)
                    .UpdateDepartment(department);

            await this.employeeRepository.Save(employee, cancellationToken);

            return employee.Id;
        }
    }
}