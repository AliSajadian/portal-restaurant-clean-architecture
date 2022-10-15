namespace Portal.Domain.BaseInfo.Models.JobPositions;

using Common;
using Common.Models;
using Exceptions;

// using static Common.Models.ModelConstants.Common;
using static ModelConstants.Common;

public class JobPosition : Entity<int>, IAggregateRoot
{
    internal JobPosition(string name)
    {
        this.Validate(name);

        this.Name = name;
    }

    public string Name { get; private set; }

    public JobPosition UpdateName(string name)
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
        => Validations.ForStringLength<InvalidJobPositionException>(
            name,
            MinNameLength,
            MaxNameLength,
            nameof(this.Name));
}