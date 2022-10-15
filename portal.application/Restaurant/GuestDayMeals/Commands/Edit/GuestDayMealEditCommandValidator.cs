namespace Portal.Application.Restaurant.GuestDayMeals.Commands.Edit;

using Common;
using FluentValidation;

public class GuestDayMealEditCommandValidator : AbstractValidator<GuestDayMealEditCommand>
{
    public GuestDayMealEditCommandValidator()
        => this.Include(new GuestDayMealCommandValidator<GuestDayMealEditCommand>());
}