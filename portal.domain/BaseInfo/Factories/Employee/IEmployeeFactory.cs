namespace Portal.Domain.BaseInfo.Factories.Employees;

using Common;
using Models.Employees;
using Models.Departments;
using Models.Projects;
using Models.JobPositions;


public interface IEmployeeFactory : IFactory<Employee>
{
    IEmployeeFactory WithPersonelCode(string personelCode);
    IEmployeeFactory WithFirstName(string firstName);
    IEmployeeFactory WithLastName(string lastName);
    IEmployeeFactory WithGender(bool gender);
    IEmployeeFactory WithPhone(string phone);
    IEmployeeFactory WithEmail(string email);
    IEmployeeFactory WithIsActive(bool isActive);

    IEmployeeFactory FromSection(Department department, Project project);
    IEmployeeFactory FromJobPosition(JobPosition jobPosition);

    IEmployeeFactory WithUserId(int userId);
}