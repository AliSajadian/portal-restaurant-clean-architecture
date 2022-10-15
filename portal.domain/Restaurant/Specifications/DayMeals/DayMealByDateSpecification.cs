namespace Portal.Domain.Restaurant.Specifications.DayMeals;

using System;
using System.Linq.Expressions;
using Common;
using Models.DayMeals;

public class DayMealByDateSpecification : Specification<DayMeal>
{
    private readonly string? date;

    public DayMealByDateSpecification(string? date) => this.date = date;

    protected override bool Include => this.date != null;

    public override Expression<Func<DayMeal, bool>> ToExpression()
        => dayMeal => dayMeal.Date.Date.ToString().ToLower()
                    .Contains(this.date!.ToLower());
}