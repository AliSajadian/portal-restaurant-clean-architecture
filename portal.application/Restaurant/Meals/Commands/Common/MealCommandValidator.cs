namespace Portal.Application.Restaurant.Meals.Commands.Common;

using Application.Common;
using FluentValidation;

// using static Domain.BaseInfo.Models.ModelConstants.Common;
using static Domain.Common.Models.ModelConstants.Common;

public class MealCommandValidator<TCommand> : AbstractValidator<MealCommand<TCommand>>
    where TCommand : EntityCommand<int>
{
    public MealCommandValidator()
    {
        this.RuleFor(b => b.Name)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();
    }
}