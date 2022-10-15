namespace Portal.Application.Restaurant.DayMeals.Commands.Create;

using Common;
using FluentValidation;

public class DayMealCreateCommandValidator : AbstractValidator<DayMealCreateCommand>
{
    public DayMealCreateCommandValidator()
        => this.Include(new DayMealCommandValidator<DayMealCreateCommand>());
}