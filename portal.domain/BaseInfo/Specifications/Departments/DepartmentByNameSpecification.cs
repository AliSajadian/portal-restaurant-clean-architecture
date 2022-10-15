namespace Portal.Domain.BaseInfo.Specifications.Departments;

using System;
using System.Linq.Expressions;
using Common;
using Models.Departments;

public class DepartmentByNameSpecification : Specification<Department>
{
    private readonly string? name;

    public DepartmentByNameSpecification(string? name) => this.name = name;

    protected override bool Include => this.name != null;

    public override Expression<Func<Department, bool>> ToExpression()
        => department => department.Name.ToLower()
            .Contains(this.name!.ToLower());
}