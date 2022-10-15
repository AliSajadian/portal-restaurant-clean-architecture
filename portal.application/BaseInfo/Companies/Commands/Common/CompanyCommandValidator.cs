namespace Portal.Application.BaseInfo.Companies.Commands.Common;

using Application.Common;
using FluentValidation;

using static Domain.Common.Models.ModelConstants.Common;

public class CompanyCommandValidator<TCommand> : AbstractValidator<CompanyCommand<TCommand>>
    where TCommand : EntityCommand<int>
{
    public CompanyCommandValidator()
    {
        this.RuleFor(b => b.Name)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();
    }
}