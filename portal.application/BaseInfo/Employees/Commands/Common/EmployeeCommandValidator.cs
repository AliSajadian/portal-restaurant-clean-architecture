namespace Portal.Application.BaseInfo.Employees.Commands.Common;

using Application.Common;
using FluentValidation;

// using static Domain.BaseInfo.Models.ModelConstants.Common;
using static Domain.Common.Models.ModelConstants.Common;

public class EmployeeCommandValidator<TCommand> : AbstractValidator<EmployeeCommand<TCommand>>
    where TCommand : EntityCommand<int>
{
    public EmployeeCommandValidator()
    {
        this.RuleFor(b => b.FirstName)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();

        this.RuleFor(b => b.LastName)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();

        this.RuleFor(b => b.Email)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();

        this.RuleFor(b => b.Gender)
            .NotEmpty();

        this.RuleFor(b => b.JobPosition)
            .NotEmpty();
    }
}