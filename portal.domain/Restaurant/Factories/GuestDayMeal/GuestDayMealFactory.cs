namespace Portal.Domain.Restaurant.Factories.GuestDayMeals;

using Exceptions;
using Portal.Domain.BaseInfo.Models.Departments;
using Portal.Domain.BaseInfo.Models.Projects;
using Models.Meals;
using Models.DayMeals;
using Models.GuestDayMeals;

internal class GuestDayMealFactory : IGuestDayMealFactory
{
    private DateTime Date = default!;
    private string Description = default!;
    private Department? Department = default!;
    private Project? Project = default!;

    private bool isDateSet = false;
    private bool isDescriptionSet = false;
    private bool isSectionSet = false;

    public IGuestDayMealFactory WithDate(DateTime date)
    {
        this.Date = date;
        this.isDateSet = true;

        return this;
    }
    public IGuestDayMealFactory WithDescription(string description)
    {
        this.Description = description;
        this.isDescriptionSet = true;

        return this;
    }
    public IGuestDayMealFactory FromSection(Department department, Project project)
    {
        if(!(department != null && project != null) && (department != null || project != null))
        {
            this.Department = department;
            this.Project = project;

            this.isSectionSet = true;
        }

        return this;
    }

    public GuestDayMeal Build()
    {
        if (!this.isDateSet || !this.isSectionSet || !this.isDescriptionSet)
        {
            throw new InvalidGuestDayMealException("Date, Description and one of Department or Project must have a value.");
        }

        return new GuestDayMeal(this.Date, 
                           this.Description, 
                           this.Department, 
                           this.Project);
    }
}