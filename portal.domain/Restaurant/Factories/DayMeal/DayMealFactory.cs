namespace Portal.Domain.Restaurant.Factories.DayMeals;

using Exceptions;
using Models.Meals;
using Models.DayMeals;

internal class DayMealFactory : IDayMealFactory
{
    private DateTime Date = default!;
    private int? TotalNo = default!;
    private bool? IsActive = default!;
    private Meal Meal = default!;

    private bool isDateSet = false;
    private bool isMealSet = false;

    public IDayMealFactory WithDate(DateTime date)
    {
        this.Date = date;
        this.isDateSet = true;

        return this;
    }

    public IDayMealFactory FromMeal(Meal meal)
    {
        this.Meal = meal;
        this.isMealSet = true;

        return this;
    }

    public DayMeal Build()
    {
        if (!this.isDateSet || !this.isMealSet)
        {
            throw new InvalidDayMealException("Date and meal must have a value.");
        }

        return new DayMeal(this.Date, 
                           this.TotalNo, 
                           this.IsActive, 
                           this.Meal);
    }
}