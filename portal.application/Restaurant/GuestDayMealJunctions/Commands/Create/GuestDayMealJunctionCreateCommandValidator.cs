namespace Portal.Application.Restaurant.GuestDayMealJunctions.Commands.Create;

using Common;
using FluentValidation;

public class GuestDayMealJunctionCreateCommandValidator : AbstractValidator<GuestDayMealJunctionCreateCommand>
{
    public GuestDayMealJunctionCreateCommandValidator()
        => this.Include(new GuestDayMealJunctionCommandValidator<GuestDayMealJunctionCreateCommand>());
}