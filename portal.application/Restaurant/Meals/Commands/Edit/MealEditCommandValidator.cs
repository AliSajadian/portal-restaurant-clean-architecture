namespace Portal.Application.Restaurant.Meals.Commands.Edit;

using Common;
using FluentValidation;

public class MealEditCommandValidator : AbstractValidator<MealEditCommand>
{
    public MealEditCommandValidator()
        => this.Include(new MealCommandValidator<MealEditCommand>());
}