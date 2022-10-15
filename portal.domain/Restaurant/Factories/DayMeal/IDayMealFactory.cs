namespace Portal.Domain.Restaurant.Factories.DayMeals;

using Common;
using Models.Meals;
using Models.DayMeals;

public interface IDayMealFactory : IFactory<DayMeal>
{
    IDayMealFactory WithDate(DateTime date);
    IDayMealFactory FromMeal(Meal meal);
}