namespace Portal.Domain.BaseInfo.Models.Projects;

using Companies;
using Common;
using Common.Models;
using Exceptions;

// using static Common.Models.ModelConstants.Common;
using static ModelConstants.Common;

public class Project : Entity<int>, IAggregateRoot
{
    internal Project(string name, Company company)
    {
        this.Validate(name);

        this.Name = name;
        this.Company = company;
    }

    public string Name { get; private set; }

    public Company Company { get; private set; }

    public Project UpdateName(string name)
    {
        this.ValidateName(name);

        this.Name = name;

        return this;
    }
    public Project UpdateCompany(Company company)
    {
        this.Company = company;

        return this;
    }

    private void Validate(string name)
    {
        this.ValidateName(name);
    }

    private void ValidateName(string name)
        => Validations.ForStringLength<InvalidProjectException>(
            name,
            MinNameLength,
            MaxNameLength,
            nameof(this.Name));
}