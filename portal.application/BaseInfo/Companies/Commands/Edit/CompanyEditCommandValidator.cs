namespace Portal.Application.BaseInfo.Companies.Commands.Edit;

using Common;
using FluentValidation;

public class CompanyEditCommandValidator : AbstractValidator<CompanyEditCommand>
{
    public CompanyEditCommandValidator()
        => this.Include(new CompanyCommandValidator<CompanyEditCommand>());
}