namespace Portal.Application.BaseInfo.Departments.Queries.Search;

using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.BaseInfo.Models.Departments;
using Domain.BaseInfo.Specifications.Departments;
using Domain.Common;
using MediatR;

public class DepartmentsSearchQuery : IRequest<DepartmentsSearchResponseModel>
{
    private const int DepartmentsPerPage = 10;

    public string? Name { get; init; }

    public int Page { get; init; } = 1;

    public class DepartmentsSearchQueryHandler : IRequestHandler<DepartmentsSearchQuery, DepartmentsSearchResponseModel>
    {
        private readonly IDepartmentQueryRepository departmentRepository;

        public DepartmentsSearchQueryHandler(IDepartmentQueryRepository departmentRepository)
            => this.departmentRepository = departmentRepository;

        public async Task<DepartmentsSearchResponseModel> Handle(
            DepartmentsSearchQuery request,
            CancellationToken cancellationToken)
        {
            var specification = this.GetDepartmentSpecification(request);

            var skip = (request.Page - 1) * DepartmentsPerPage;

            var companiesListing = await this.departmentRepository.GetDepartmentsListing(
                specification,
                skip,
                take: DepartmentsPerPage,
                cancellationToken);

            var totalDepartments = await this.departmentRepository.Total(
                specification,
                cancellationToken);

            var totalPages = (int)Math.Ceiling((double)totalDepartments / DepartmentsPerPage);

            return new DepartmentsSearchResponseModel(companiesListing, request.Page, totalPages);
        }

        private Specification<Department> GetDepartmentSpecification(
            DepartmentsSearchQuery request)
            => new DepartmentByNameSpecification(request.Name);
    }
}