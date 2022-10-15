namespace Portal.Domain.BaseInfo.Factories.Companies;

using Common;
using Models.Companies;

public interface ICompanyFactory : IFactory<Company>
{
    ICompanyFactory WithName(string name);
}