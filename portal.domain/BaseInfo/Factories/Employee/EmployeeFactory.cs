namespace Portal.Domain.BaseInfo.Factories.Employees;

using Exceptions;
using Models.Employees;
using Models.Departments;
using Models.Projects;
using Models.JobPositions;

internal class EmployeeFactory : IEmployeeFactory
{
    private string PersonelCode = default!;
    private string FirstName = default!;
    private string LastName = default!;
    private bool Gender = default!;
    private string Picture = default!;
    private string Phone = default!;
    private string Email = default!;
    private bool IsActive = default!;
    private Department Department = default!;
    private Project Project = default!;
    private JobPosition JobPosition = default!;
    private int UserId = default!;

    private bool isPersonelCodeSet = false;
    private bool isFirstNameSet = false;
    private bool isLastNameSet = false;
    private bool isGenderSet = false;
    private bool isPhoneSet = false;
    private bool isEmailSet = false;
    private bool isIsActiveSet = false;
    private bool isJobPositionSet = false;
    private bool isSectionSet = false;
    private bool isUserIdSet = false;

    public IEmployeeFactory WithPersonelCode(string personelCode)
    {
        this.PersonelCode = personelCode;
        this.isPersonelCodeSet = true;

        return this;
    }
    public IEmployeeFactory WithFirstName(string firstName)
    {
        this.FirstName = firstName;
        this.isFirstNameSet = true;

        return this;
    }
    public IEmployeeFactory WithLastName(string lastName)
    {
        this.LastName = lastName;
        this.isLastNameSet = true;

        return this;
    }
    public IEmployeeFactory WithGender(bool gender)
    {
        this.Gender = gender;
        this.isGenderSet = true;

        return this;
    }
    public IEmployeeFactory WithPhone(string phone)
    {
        this.Phone = phone;
        this.isPhoneSet = true;

        return this;
    }
    public IEmployeeFactory WithEmail(string email)
    {
        this.Email = email;
        this.isEmailSet = true;

        return this;
    }
    public IEmployeeFactory WithIsActive(bool isActive)
    {
        this.IsActive = isActive;
        this.isIsActiveSet = true;

        return this;
    }
    public IEmployeeFactory FromJobPosition(JobPosition jobPosition)
    {
        this.JobPosition = jobPosition;
        this.isJobPositionSet = true;

        return this;
    }
    public IEmployeeFactory FromSection(Department department, Project project)
    {
        if(department == null)
        {
            if(project != null)
            {
                this.Project = project;
                this.isSectionSet = true;
            }
        }
        else
        {
            if(project == null)
            {
                this.Department = department;
                this.isSectionSet = true;
            }
        }

        return this;
    }
    public IEmployeeFactory WithUserId(int userId)
    {
        this.UserId = userId;
        this.isUserIdSet = true;

        return this;
    }

    public Employee Build()
    {
        if (!this.isPersonelCodeSet ||
            !this.isFirstNameSet ||
            !this.isLastNameSet ||
            !this.isGenderSet ||
            !this.isPhoneSet ||
            !this.isEmailSet ||
            !this.isIsActiveSet ||
            !this.isJobPositionSet ||
            !this.isSectionSet ||
            !this.isUserIdSet)
        {
            throw new InvalidEmployeeException("PersonelCode, FirstName, LastName, Gender, Phone, Email, IsActive, UserId, JobPosition and one of Department or Project must have a value.");
        }

        return new Employee(
            this.PersonelCode,
            this.FirstName,
            this.LastName,
            this.Gender,
            this.Picture,
            this.Phone,
            this.Email,
            this.IsActive,
            this.JobPosition,
            this.Department,
            this.Project, 
            this.UserId);
    }
}