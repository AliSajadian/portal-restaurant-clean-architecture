namespace Portal.Domain.Restaurant.Factories.GuestDayMeals;

using Common;
using Portal.Domain.BaseInfo.Models.Departments;
using Portal.Domain.BaseInfo.Models.Projects;
using Models.GuestDayMeals;

public interface IGuestDayMealFactory : IFactory<GuestDayMeal>
{
    IGuestDayMealFactory WithDate(DateTime date);
    IGuestDayMealFactory WithDescription(string description);
    IGuestDayMealFactory FromSection(Department department, Project project);
}