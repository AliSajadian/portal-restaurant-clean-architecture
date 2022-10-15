namespace Portal.Domain.BaseInfo.Factories.Companies;

using Exceptions;
using Models.Companies;

internal class CompanyFactory : ICompanyFactory
{
    private string companyName = default!;

    private bool isNameSet = false;

    public ICompanyFactory WithName(string name)
    {
        this.companyName = name;
        this.isNameSet = true;

        return this;
    }

    public Company Build()
    {
        if (!this.isNameSet)
        {
            throw new InvalidCompanyException("Name must have a value.");
        }

        return new Company(this.companyName);
    }
}