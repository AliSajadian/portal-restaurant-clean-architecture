namespace Portal.Domain.Restaurant.Factories.Meals;

using Exceptions;
using Models.Meals;

internal class MealFactory : IMealFactory
{
    private string Name = default!;

    private bool isNameSet = false;

    public IMealFactory WithName(string name)
    {
        this.Name = name;
        this.isNameSet = true;

        return this;
    }

    public Meal Build()
    {
        if (!this.isNameSet)
        {
            throw new InvalidMealException("Name must have a value.");
        }

        return new Meal(this.Name);
    }
}