namespace Portal.Domain.Restaurant.Specifications.GuestDayMealJunctions;

using System;
using System.Linq.Expressions;
using Common;
using Models.GuestDayMealJunctions;

public class GuestDayMealJunctionByDateSpecification : Specification<GuestDayMealJunction>
{
    private readonly string? date;

    public GuestDayMealJunctionByDateSpecification(string? date) => this.date = date;

    protected override bool Include => this.date != null;

    public override Expression<Func<GuestDayMealJunction, bool>> ToExpression()
        => guestDayMealJunction => guestDayMealJunction.DayMeal != null && 
            guestDayMealJunction.DayMeal.Date.Date.ToString().ToLower()
                    .Contains(this.date!.ToLower());
}