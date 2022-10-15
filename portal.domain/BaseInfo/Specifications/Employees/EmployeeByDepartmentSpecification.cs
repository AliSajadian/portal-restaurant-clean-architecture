namespace Portal.Domain.BaseInfo.Specifications.Employees;

using System;
using System.Linq.Expressions;
using Common;
using Models.Employees;

public class EmployeeByDepartmentSpecification : Specification<Employee>
{
    private readonly string? department;

    public EmployeeByDepartmentSpecification(string? department) => this.department = department;

    protected override bool Include => this.department != null;

    public override Expression<Func<Employee, bool>> ToExpression()
        => employee => employee.Department != null && employee.Department.Name.ToLower()
            .Contains(this.department!.ToLower());
}