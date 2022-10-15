namespace Portal.Domain.BaseInfo.Specifications.Employees;

using System;
using System.Linq.Expressions;
using Common;
using Models.Employees;

public class EmployeeByProjectSpecification : Specification<Employee>
{
    private readonly string? project;

    public EmployeeByProjectSpecification(string? project) => this.project = project;

    protected override bool Include => this.project != null;

    public override Expression<Func<Employee, bool>> ToExpression()
        => employee => employee.Project != null && employee.Project.Name.ToLower()
            .Contains(this.project!.ToLower());
}