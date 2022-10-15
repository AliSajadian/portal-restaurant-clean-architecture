namespace Portal.Domain.BaseInfo.Specifications.Companies;

using System;
using System.Linq.Expressions;
using Common;
using Models.Companies;

public class CompanyByNameSpecification : Specification<Company>
{
    private readonly string? name;

    public CompanyByNameSpecification(string? name) => this.name = name;

    protected override bool Include => this.name != null;

    public override Expression<Func<Company, bool>> ToExpression()
        => company => company.Name.ToLower()
            .Contains(this.name!.ToLower());
}