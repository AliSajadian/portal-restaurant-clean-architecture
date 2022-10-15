using System.Globalization;
namespace Portal.Domain.Restaurant.Models.GuestDayMeals;

using Portal.Domain.BaseInfo.Models.Departments;
using Portal.Domain.BaseInfo.Models.Projects;
using Common;
using Common.Models;
using Exceptions;

//using static Common.Models.ModelConstants.Common;
using static ModelConstants.Common;

public class GuestDayMeal : Entity<int>, IAggregateRoot
{
    internal GuestDayMeal(DateTime date, 
                     string description,
                     Department? department,
                     Project? project)
    {
        this.Validate(description);

        this.Date = date;
        this.Description = description;
        this.Department = department;
        this.Project = project;
    }

    public DateTime Date { get; private set; }
    public string? Description { get; private set; }
    public Department? Department { get; private set; }
    public Project? Project { get; private set; }

    public GuestDayMeal UpdateDate(DateTime date)
    {
        // this.ValidateDate(date);

        this.Date = date;

        return this;
    }
    public GuestDayMeal UpdateDescription(string description)
    {
        this.ValidateDescription(description);

        this.Description = description;

        return this;
    }
    public GuestDayMeal UpdateDepartment(Department? department)
    {
        this.Department = department;

        return this;
    }
    public GuestDayMeal UpdateProject(Project? project)
    {
        this.Project = project;

        return this;
    }

    private void Validate(string description)
    {
        this.ValidateDescription(description);
    }
    private void ValidateDescription(string description)
        => Validations.ForStringLength<InvalidGuestDayMealException>(
            description,
            MinDescriptionLength,
            MaxDescriptionLength,
            nameof(this.Description));               
}