namespace Portal.Application.BaseInfo.JobPositions.Commands.Edit;

using Common;
using FluentValidation;

public class JobPositionEditCommandValidator : AbstractValidator<JobPositionEditCommand>
{
    public JobPositionEditCommandValidator()
        => this.Include(new JobPositionCommandValidator<JobPositionEditCommand>());
}