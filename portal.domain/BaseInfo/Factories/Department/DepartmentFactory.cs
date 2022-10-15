namespace Portal.Domain.BaseInfo.Factories.Departments;

using Exceptions;
using Models.Companies;
using Models.Departments;

internal class DepartmentFactory : IDepartmentFactory
{
    private string Name = default!;
    private Company Company = default!;

    private bool isNameSet = false;
    private bool isCompanySet = false;

    public IDepartmentFactory WithName(string name)
    {
        this.Name = name;
        this.isNameSet = true;

        return this;
    }

    public IDepartmentFactory FromCompany(Company company)
    {
        this.Company = company;
        this.isCompanySet = true;

        return this;
    }

    public Department Build()
    {
        if (!this.isNameSet || !this.isCompanySet)
        {
            throw new InvalidDepartmentException("Name and company must have a value.");
        }

        return new Department(this.Name, this.Company);
    }
}