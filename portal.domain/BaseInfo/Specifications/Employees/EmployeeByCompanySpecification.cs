namespace Portal.Domain.BaseInfo.Specifications.Employees;

using System;
using System.Linq.Expressions;
using Common;
using Models.Employees;

public class EmployeeByCompanySpecification : Specification<Employee>
{
    private readonly string? company;

    public EmployeeByCompanySpecification(string? company) => this.company = company;

    protected override bool Include => this.company != null;

    public override Expression<Func<Employee, bool>> ToExpression()
        => employee => employee.Department != null && employee.Department.Company.Name.ToLower()
            .Contains(this.company!.ToLower());
}