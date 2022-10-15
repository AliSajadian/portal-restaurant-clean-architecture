namespace Portal.Application.Restaurant.EmployeeDayMeals.Commands.Common;

using Application.Common;
using FluentValidation;

// using static Domain.BaseInfo.Models.ModelConstants.Common;
using static Domain.Common.Models.ModelConstants.Common;

public class EmployeeDayMealCommandValidator<TCommand> : AbstractValidator<EmployeeDayMealCommand<TCommand>>
    where TCommand : EntityCommand<int>
{
    public EmployeeDayMealCommandValidator()
    {
        this.RuleFor(b => b.PersonelCode)
            .NotEmpty();
            
        this.RuleFor(b => b.DayMealId)
            .NotEmpty();
    }
}