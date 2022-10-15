namespace Portal.Domain.Restaurant.Models.Meals;

using Common;
using Common.Models;
using Exceptions;

// using static Common.Models.ModelConstants.Common;
using static ModelConstants.Common;

public class Meal : Entity<int>, IAggregateRoot
{
    internal Meal(string name)
    {
        this.Validate(name);

        this.Name = name;
    }

    public string Name { get; private set; }

    public Meal UpdateName(string name)
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
        => Validations.ForStringLength<InvalidMealException>(
            name,
            MinNameLength,
            MaxNameLength,
            nameof(this.Name));
}