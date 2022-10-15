namespace Portal.Domain.BaseInfo.Specifications.Employees;

using System;
using System.Linq.Expressions;
using Common;
using Models.Employees;

public class EmployeeByPersonelCodeSpecification : Specification<Employee>
{
    private readonly string? personelCode;

    public EmployeeByPersonelCodeSpecification(string? personelCode) => this.personelCode = personelCode;

    protected override bool Include => this.personelCode != null;

    public override Expression<Func<Employee, bool>> ToExpression()
        => employee => employee.PersonelCode != null && employee.PersonelCode.Trim()
                .Contains(this.personelCode!.Trim());
}