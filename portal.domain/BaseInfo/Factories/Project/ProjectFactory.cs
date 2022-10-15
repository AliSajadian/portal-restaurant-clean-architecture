namespace Portal.Domain.BaseInfo.Factories.Projects;

using Exceptions;
using Models.Companies;
using Models.Projects;

internal class ProjectFactory : IProjectFactory
{
    private string Name = default!;
    private Company Company = default!;

    private bool isNameSet = false;
    private bool isCompanySet = false;

    public IProjectFactory WithName(string name)
    {
        this.Name = name;
        this.isNameSet = true;

        return this;
    }

    public IProjectFactory FromCompany(Company company)
    {
        this.Company = company;
        this.isCompanySet = true;

        return this;
    }

    public Project Build()
    {
        if (!this.isNameSet || !this.isCompanySet)
        {
            throw new InvalidProjectException("Name and company must have a value.");
        }

        return new Project(this.Name, this.Company);
    }
}