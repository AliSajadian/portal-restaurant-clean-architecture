namespace Portal.Domain.BaseInfo.Specifications.Employees;

using System;
using System.Linq.Expressions;
using Common;
using Models.Employees;

public class EmployeeByJobPositionSpecification : Specification<Employee>
{
    private readonly string? jobPosition;

    public EmployeeByJobPositionSpecification(string? jobPosition) => this.jobPosition = jobPosition;

    protected override bool Include => this.jobPosition != null;

    public override Expression<Func<Employee, bool>> ToExpression()
        => employee => employee.JobPosition != null && employee.JobPosition.Name.ToLower()
            .Contains(this.jobPosition!.ToLower());
}