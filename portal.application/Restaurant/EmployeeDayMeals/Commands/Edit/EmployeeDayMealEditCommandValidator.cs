namespace Portal.Application.Restaurant.EmployeeDayMeals.Commands.Edit;

using Common;
using FluentValidation;

public class EmployeeDayMealEditCommandValidator : AbstractValidator<EmployeeDayMealEditCommand>
{
    public EmployeeDayMealEditCommandValidator()
        => this.Include(new EmployeeDayMealCommandValidator<EmployeeDayMealEditCommand>());
}