namespace Portal.Application.BaseInfo.JobPositions.Commands.Common;

using Application.Common;
using FluentValidation;

// using static Domain.BaseInfo.Models.ModelConstants.Common;
using static Domain.Common.Models.ModelConstants.Common;

public class JobPositionCommandValidator<TCommand> : AbstractValidator<JobPositionCommand<TCommand>>
    where TCommand : EntityCommand<int>
{
    public JobPositionCommandValidator()
    {
        this.RuleFor(b => b.Name)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();
    }
}