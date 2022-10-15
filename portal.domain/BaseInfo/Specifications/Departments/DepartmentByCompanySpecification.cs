namespace Portal.Domain.BaseInfo.Specifications.Departments;

using System;
using System.Linq.Expressions;
using Common;
using Models.Companies;
using Models.Departments;

public class DepartmentByCompanySpecification : Specification<Department>
{
    private readonly string? company;

    public DepartmentByCompanySpecification(string? company) => this.company = company;

    protected override bool Include => this.company != null;

    public override Expression<Func<Department, bool>> ToExpression()
        => department => department.Company.Name.ToLower()
            .Contains(this.company!.ToLower());
}