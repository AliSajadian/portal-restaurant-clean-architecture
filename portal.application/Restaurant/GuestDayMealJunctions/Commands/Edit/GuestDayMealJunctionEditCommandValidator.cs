namespace Portal.Application.Restaurant.GuestDayMealJunctions.Commands.Edit;

using Common;
using FluentValidation;

public class GuestDayMealJunctionEditCommandValidator : AbstractValidator<GuestDayMealJunctionEditCommand>
{
    public GuestDayMealJunctionEditCommandValidator()
        => this.Include(new GuestDayMealJunctionCommandValidator<GuestDayMealJunctionEditCommand>());
}