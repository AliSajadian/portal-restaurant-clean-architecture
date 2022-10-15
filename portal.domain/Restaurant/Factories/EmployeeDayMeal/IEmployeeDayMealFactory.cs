namespace Portal.Domain.Restaurant.Factories.EmployeeDayMeals;

using Portal.Domain.BaseInfo.Models.Employees;
using Common;
using Models.DayMeals;
using Models.EmployeeDayMeals;

public interface IEmployeeDayMealFactory : IFactory<EmployeeDayMeal>
{
    IEmployeeDayMealFactory WithServed(bool served);
    IEmployeeDayMealFactory FromEmployee(Employee employee);
    IEmployeeDayMealFactory FromDayMeal(DayMeal dayMeal);
}