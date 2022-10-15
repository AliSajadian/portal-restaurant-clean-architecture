namespace Portal.Application.Restaurant.DayMeals.Commands.Common;

using Application.Common;
using FluentValidation;

// using static Domain.BaseInfo.Models.ModelConstants.Common;
using static Domain.Common.Models.ModelConstants.Common;

public class DayMealCommandValidator<TCommand> : AbstractValidator<DayMealCommand<TCommand>>
    where TCommand : EntityCommand<int>
{
    public DayMealCommandValidator()
    {
        this.RuleFor(b => b.Date)
            .NotEmpty();
            
        this.RuleFor(b => b.Meal)
            .NotEmpty();
    }
}