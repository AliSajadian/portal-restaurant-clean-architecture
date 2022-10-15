namespace Portal.Application.Restaurant.DayMeals.Commands.Edit;

using Common;
using FluentValidation;

public class DayMealEditCommandValidator : AbstractValidator<DayMealEditCommand>
{
    public DayMealEditCommandValidator()
        => this.Include(new DayMealCommandValidator<DayMealEditCommand>());
}