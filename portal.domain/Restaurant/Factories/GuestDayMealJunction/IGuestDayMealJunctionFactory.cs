namespace Portal.Domain.Restaurant.Factories.GuestDayMealJunctions;

using Common;
using Models.DayMeals;
using Models.GuestDayMeals;
using Models.GuestDayMealJunctions;

public interface IGuestDayMealJunctionsFactory : IFactory<GuestDayMealJunction>
{
    IGuestDayMealJunctionsFactory WithQty(short qty);
    IGuestDayMealJunctionsFactory FromGuestDayMeal(GuestDayMeal guestDayMeal);
    IGuestDayMealJunctionsFactory FromDayMeal(DayMeal dayMeal);
}