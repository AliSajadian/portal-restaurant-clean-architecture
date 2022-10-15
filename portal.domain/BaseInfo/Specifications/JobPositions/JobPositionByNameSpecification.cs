namespace Portal.Domain.BaseInfo.Specifications.JobPositions;

using System;
using System.Linq.Expressions;
using Common;
using Models.JobPositions;

public class JobPositionByNameSpecification : Specification<JobPosition>
{
    private readonly string? name;

    public JobPositionByNameSpecification(string? name) => this.name = name;

    protected override bool Include => this.name != null;

    public override Expression<Func<JobPosition, bool>> ToExpression()
        => jobPosition => jobPosition.Name.ToLower()
            .Contains(this.name!.ToLower());
}