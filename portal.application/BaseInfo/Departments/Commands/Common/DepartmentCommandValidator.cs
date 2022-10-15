namespace Portal.Application.BaseInfo.Departments.Commands.Common;

using Application.Common;
using FluentValidation;

// using static Domain.BaseInfo.Models.ModelConstants.Common;
using static Domain.Common.Models.ModelConstants.Common;

public class DepartmentCommandValidator<TCommand> : AbstractValidator<DepartmentCommand<TCommand>>
    where TCommand : EntityCommand<int>
{
    public DepartmentCommandValidator()
    {
        this.RuleFor(b => b.Name)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();

        this.RuleFor(b => b.Company)
            .NotEmpty();
    }
}