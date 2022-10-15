namespace Portal.Application.BaseInfo.Employees.Queries.Search;

using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.BaseInfo.Models.Departments;
using Domain.BaseInfo.Models.Projects;
using Domain.BaseInfo.Models.JobPositions;
using Domain.BaseInfo.Models.Employees;
using Domain.BaseInfo.Specifications.Employees;
using Domain.Common;
using MediatR;

public class EmployeesSearchQuery : IRequest<EmployeesSearchResponseModel>
{
    private const int EmployeesPerPage = 10;

    public string? PersonelCode { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public bool? Gender { get; init; }
    public string? Picture { get; init; }
    public string? Phone { get; init; }
    public string? Email { get; init; }
    public bool? IsActive { get; init; }
    public string? Company { get; init; }
    public string? Department { get; init; }
    public string? JobPosition { get; init; }
    public string? Project { get; init; }
    public int? UserId { get; init; }


    public int Page { get; init; } = 1;

    public class EmployeesSearchQueryHandler : IRequestHandler<EmployeesSearchQuery, EmployeesSearchResponseModel>
    {
        private readonly IEmployeeQueryRepository employeeRepository;

        public EmployeesSearchQueryHandler(IEmployeeQueryRepository employeeRepository)
            => this.employeeRepository = employeeRepository;

        public async Task<EmployeesSearchResponseModel> Handle(
            EmployeesSearchQuery request,
            CancellationToken cancellationToken)
        {
            var specification = this.GetEmployeeSpecification(request);

            var skip = (request.Page - 1) * EmployeesPerPage;

            var companiesListing = await this.employeeRepository.GetEmployeesListing(
                specification,
                skip,
                take: EmployeesPerPage,
                cancellationToken);

            var totalEmployees = await this.employeeRepository.Total(
                specification,
                cancellationToken);

            var totalPages = (int)Math.Ceiling((double)totalEmployees / EmployeesPerPage);

            return new EmployeesSearchResponseModel(companiesListing, request.Page, totalPages);
        }

        private Specification<Employee> GetEmployeeSpecification(
            EmployeesSearchQuery request)
            => new EmployeeByPersonelCodeSpecification(request.PersonelCode)
                .And(new EmployeeByJobPositionSpecification(request.JobPosition))
                .And(new EmployeeByDepartmentSpecification(request.Department))
                .And(new EmployeeByProjectSpecification(request.Project))
                .And(new EmployeeByCompanySpecification(request.Company));
    }
}