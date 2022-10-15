namespace Portal.Domain.Restaurant.Factories.Meals;

using Common;
using Models.Meals;

public interface IMealFactory : IFactory<Meal>
{
    IMealFactory WithName(string name);
}