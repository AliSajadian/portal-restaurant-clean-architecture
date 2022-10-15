namespace Portal.Domain.BaseInfo.Factories.Departments;

using Common;
using Models.Companies;
using Models.Departments;

public interface IDepartmentFactory : IFactory<Department>
{
    IDepartmentFactory WithName(string name);

    IDepartmentFactory FromCompany(Company company);
}