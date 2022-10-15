namespace Portal.Domain.BaseInfo.Factories.Projects;

using Common;
using Models.Companies;
using Models.Projects;

public interface IProjectFactory : IFactory<Project>
{
    IProjectFactory WithName(string name);
    IProjectFactory FromCompany(Company company);
}