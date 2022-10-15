namespace Portal.Domain.BaseInfo.Factories.JobPositions;

using Exceptions;
using Models.JobPositions;

internal class JobPositionFactory : IJobPositionFactory
{
    private string Name = default!;

    private bool isNameSet = false;

    public IJobPositionFactory WithName(string name)
    {
        this.Name = name;
        this.isNameSet = true;

        return this;
    }

     public JobPosition Build()
    {
        if (!this.isNameSet)
        {
            throw new InvalidJobPositionException("Name must have a value.");
        }

        return new JobPosition(this.Name);
    }
}