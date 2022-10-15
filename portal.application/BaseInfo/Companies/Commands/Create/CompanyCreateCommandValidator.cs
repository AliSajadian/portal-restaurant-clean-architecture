namespace Portal.Application.BaseInfo.Companies.Commands.Create;

using Common;
using FluentValidation;

public class CompanyCreateCommandValidator : AbstractValidator<CompanyCreateCommand>
{
    public CompanyCreateCommandValidator()
        => this.Include(new CompanyCommandValidator<CompanyCreateCommand>());
}