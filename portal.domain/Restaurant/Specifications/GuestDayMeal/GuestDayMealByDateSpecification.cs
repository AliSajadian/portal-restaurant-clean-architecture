namespace Portal.Domain.Restaurant.Specifications.GuestDayMeals;

using System;
using System.Linq.Expressions;
using Common;
using Models.GuestDayMeals;

public class GuestDayMealByDateSpecification : Specification<GuestDayMeal>
{
    private readonly string? date;

    public GuestDayMealByDateSpecification(string? date) => this.date = date;

    protected override bool Include => this.date != null;

    public override Expression<Func<GuestDayMeal, bool>> ToExpression()
        => guestDayMeal => guestDayMeal.Date.Date.ToString().ToLower()
                .Contains(this.date!.ToLower());
}