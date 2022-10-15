namespace Portal.Domain.Restaurant.Factories.GuestDayMealJunctions;

using Exceptions;
using Models.Meals;
using Models.DayMeals;
using Models.GuestDayMeals;
using Models.GuestDayMealJunctions;

internal class GuestDayMealJunctionFactory : IGuestDayMealJunctionsFactory
{
    private short Qty = default!;
    private DayMeal DayMeal = default!;
    private GuestDayMeal GuestDayMeal = default!;

    private bool isQtySet = false;
    private bool isDayMealSet = false;
    private bool isGuestDayMealSet = false;

    public IGuestDayMealJunctionsFactory WithQty(short qty)
    {
        this.Qty = qty;
        this.isQtySet = true;

        return this;
    }
    public IGuestDayMealJunctionsFactory FromDayMeal(DayMeal dayMeal)
    {
        this.DayMeal = dayMeal;
        this.isDayMealSet = true;

        return this;
    }

    public IGuestDayMealJunctionsFactory FromGuestDayMeal(GuestDayMeal guestDayMeal)
    {
        this.GuestDayMeal = guestDayMeal;
        this.isGuestDayMealSet = true;

        return this;
    }

    public GuestDayMealJunction Build()
    {
        if (!this.isQtySet || !this.isDayMealSet || !this.isGuestDayMealSet)
        {
            throw new InvalidGuestDayMealJunctionException("Qty, DayMeal and GuestDayMeal must have a value.");
        }

        return new GuestDayMealJunction(this.Qty, 
                                        this.DayMeal, 
                                        this.GuestDayMeal);
    }
}