namespace Portal.Domain.BaseInfo.Factories.JobPositions;

using Common;
using Models.JobPositions;

public interface IJobPositionFactory : IFactory<JobPosition>
{
    IJobPositionFactory WithName(string name);
}