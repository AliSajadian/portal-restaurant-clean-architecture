namespace Portal.Application.Restaurant.GuestDayMeals.Commands.Common;

using Application.Common;
using FluentValidation;

// using static Domain.BaseInfo.Models.ModelConstants.Common;
using static Domain.Common.Models.ModelConstants.Common;

public class GuestDayMealCommandValidator<TCommand> : AbstractValidator<GuestDayMealCommand<TCommand>>
    where TCommand : EntityCommand<int>
{
    public GuestDayMealCommandValidator()
    {
        this.RuleFor(b => b.Date)
            .NotEmpty();
            
        this.RuleFor(b => b.Description)
            .MinimumLength(MinDescriptionLength)
            .MaximumLength(MaxDescriptionLength)
            .NotEmpty();
    }
}