namespace Portal.Application.BaseInfo.Projects.Commands.Common;

using Application.Common;
using FluentValidation;

// using static Domain.BaseInfo.Models.ModelConstants.Common;
using static Domain.Common.Models.ModelConstants.Common;

public class ProjectCommandValidator<TCommand> : AbstractValidator<ProjectCommand<TCommand>>
    where TCommand : EntityCommand<int>
{
    public ProjectCommandValidator()
    {
        this.RuleFor(b => b.Name)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();

        this.RuleFor(b => b.Company)
            .NotEmpty();
    }
}