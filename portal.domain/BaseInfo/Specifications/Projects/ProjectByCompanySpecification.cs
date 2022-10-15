namespace Portal.Domain.BaseInfo.Specifications.Projects;

using System;
using System.Linq.Expressions;
using Common;
using Models.Projects;

public class ProjectByCompanySpecification : Specification<Project>
{
    private readonly string? company;

    public ProjectByCompanySpecification(string? company) => this.company = company;

    protected override bool Include => this.company != null;

    public override Expression<Func<Project, bool>> ToExpression()
        => project => project.Company.Name.ToLower()
            .Contains(this.company!.ToLower());
}