namespace Portal.Application.BaseInfo.JobPositions.Commands.Create;

using Common;
using FluentValidation;

public class JobPositionCreateCommandValidator : AbstractValidator<JobPositionCreateCommand>
{
    public JobPositionCreateCommandValidator()
        => this.Include(new JobPositionCommandValidator<JobPositionCreateCommand>());
}