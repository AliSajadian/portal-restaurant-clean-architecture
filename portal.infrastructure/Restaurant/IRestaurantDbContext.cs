namespace Portal.Infrastructure.Restaurant;

using Common.Persistence;
using Domain.Restaurant.Models.Meals;
using Domain.Restaurant.Models.DayMeals;
using Domain.Restaurant.Models.GuestDayMeals;
using Domain.Restaurant.Models.GuestDayMealJunctions;
using Domain.Restaurant.Models.EmployeeDayMeals;
using Microsoft.EntityFrameworkCore;

internal interface IRestaurantDbContext : IDbContext
{
    DbSet<Meal> Meals { get; }
    DbSet<DayMeal> DayMeals { get; }
    DbSet<GuestDayMeal> GuestDayMeals { get; }
    DbSet<EmployeeDayMeal> EmployeeDayMeals { get; }
    DbSet<GuestDayMealJunction> GuestDayMealJunctions { get; }
}