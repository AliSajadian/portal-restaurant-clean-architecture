namespace Portal.Application.Restaurant.Meals.Commands.Create;

using Common;
using FluentValidation;

public class MealCreateCommandValidator : AbstractValidator<MealCreateCommand>
{
    public MealCreateCommandValidator()
        => this.Include(new MealCommandValidator<MealCreateCommand>());
}