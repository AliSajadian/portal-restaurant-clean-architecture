namespace Portal.Domain.BaseInfo.Specifications.Projects;

using System;
using System.Linq.Expressions;
using Common;
using Models.Projects;

public class ProjectByNameSpecification : Specification<Project>
{
    private readonly string? name;

    public ProjectByNameSpecification(string? name) => this.name = name;

    protected override bool Include => this.name != null;

    public override Expression<Func<Project, bool>> ToExpression()
        => project => project.Name.ToLower()
            .Contains(this.name!.ToLower());
}