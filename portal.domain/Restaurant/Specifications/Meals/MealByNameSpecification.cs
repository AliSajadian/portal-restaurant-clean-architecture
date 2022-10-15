namespace Portal.Domain.Restaurant.Specifications.Meals;

using System;
using System.Linq.Expressions;
using Common;
using Models.Meals;

public class MealByNameSpecification : Specification<Meal>
{
    private readonly string? name;

    public MealByNameSpecification(string? name) => this.name = name;

    protected override bool Include => this.name != null;

    public override Expression<Func<Meal, bool>> ToExpression()
        => meal => meal.Name.ToLower()
            .Contains(this.name!.ToLower());
}