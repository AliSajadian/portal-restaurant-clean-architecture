namespace Portal.Application.Restaurant.GuestDayMeals.Commands.Create;

using Common;
using FluentValidation;

public class GuestDayMealCreateCommandValidator : AbstractValidator<GuestDayMealCreateCommand>
{
    public GuestDayMealCreateCommandValidator()
        => this.Include(new GuestDayMealCommandValidator<GuestDayMealCreateCommand>());
}