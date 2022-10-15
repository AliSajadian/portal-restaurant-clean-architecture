namespace Portal.Domain.BaseInfo.Models.Companies;

using Common;
using Common.Models;
using Exceptions;

// using static Common.Models.ModelConstants.Common;
using static ModelConstants.Common;

public class Company : Entity<int>, IAggregateRoot
{
    internal Company(string name)
    {
        this.Validate(name);

        this.Name = name;
    }

    public string Name { get; private set; }

    public Company UpdateName(string name)
    {
        this.ValidateName(name);

        this.Name = name;

        return this;
    }

    private void Validate(string name)
    {
        this.ValidateName(name);
    }

    private void ValidateName(string name)
        => Validations.ForStringLength<InvalidCompanyException>(
            name,
            MinNameLength,
            MaxNameLength,
            nameof(this.Name));
}