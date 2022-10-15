namespace Portal.Application.Restaurant.EmployeeDayMeals.Commands.Create;

using Common;
using FluentValidation;

public class EmployeeDayMealCreateCommandValidator : AbstractValidator<EmployeeDayMealCreateCommand>
{
    public EmployeeDayMealCreateCommandValidator()
        => this.Include(new EmployeeDayMealCommandValidator<EmployeeDayMealCreateCommand>());
}