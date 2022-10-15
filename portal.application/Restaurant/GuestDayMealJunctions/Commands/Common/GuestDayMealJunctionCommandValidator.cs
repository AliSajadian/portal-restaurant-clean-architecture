namespace Portal.Application.Restaurant.GuestDayMealJunctions.Commands.Common;

using Application.Common;
using FluentValidation;

// using static Domain.BaseInfo.Models.ModelConstants.Common;
using static Domain.Common.Models.ModelConstants.Common;

public class GuestDayMealJunctionCommandValidator<TCommand> : AbstractValidator<GuestDayMealJunctionCommand<TCommand>>
    where TCommand : EntityCommand<int>
{
    public GuestDayMealJunctionCommandValidator()
    {
        this.RuleFor(b => b.Qty)
            .NotEmpty();
            
        this.RuleFor(b => b.DayMealId)
            .NotEmpty();

        this.RuleFor(b => b.GuestDayMealId)
            .NotEmpty();
    }
}