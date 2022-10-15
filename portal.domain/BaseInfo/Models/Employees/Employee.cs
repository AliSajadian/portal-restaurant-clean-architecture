namespace Portal.Domain.BaseInfo.Models.Employees;

// using Users;
using Departments;
using Projects;
using JobPositions;
using Common;
using Common.Models;
using Exceptions;

// using static Common.Models.ModelConstants.Common;
using static ModelConstants.Common;

public class Employee : Entity<int>, IAggregateRoot
{
    internal Employee(string personelCode, 
                      string firstName, 
                      string lastName, 
                      bool gender, 
                      string picture, 
                      string phone, 
                      string email, 
                      bool isActive, 
                      JobPosition jobPosition,
                      Department department,
                      Project project,
                      int userId)
    {
        this.Validate(personelCode, 
                     firstName, 
                     lastName,
                     phone,
                     email);

        this.PersonelCode = personelCode;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Gender = gender;
        this.Picture = picture;
        this.Phone = phone;
        this.Email = email;
        this.IsActive = isActive;
        this.Department = department;
        this.JobPosition = jobPosition;
        this.Project = project;
        this.UserId = userId;
    }

    public string PersonelCode { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public bool Gender { get; set; }
    public string Picture { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; } = null!;
    public bool IsActive { get; set; }
    public Department Department { get; set; }
    public JobPosition JobPosition { get; set; }
    public Project Project { get; set; }
    public int UserId { get; set; }


    public Employee UpdatePersonelCode(string personelCode)
    {
        this.ValidatePersonelCode(personelCode);

        this.PersonelCode = personelCode;

        return this;
    }
    public Employee UpdateFirstName(string firstName)
    {
        this.ValidateFirstName(firstName);

        this.FirstName = firstName;

        return this;
    }
    public Employee UpdateLastName(string lastName)
    {
        this.ValidateLastName(lastName);

        this.LastName = lastName;

        return this;
    }
    public Employee UpdateGender(bool gender)
    {
        this.Gender = gender;

        return this;
    }
    public Employee UpdatePicture(string picture)
    {
        this.Picture = picture;

        return this;
    }
    public Employee UpdatePhone(string phone)
    {
        this.ValidatePhone(phone);

        this.Phone = phone;

        return this;
    }
    public Employee UpdateEmail(string email)
    {
        this.ValidateEmail(email);

        this.Email = email;

        return this;
    }
    public Employee UpdateIsActive(bool isActive)
    {
        this.IsActive = isActive;

        return this;
    }
    public Employee UpdateDepartment(Department department)
    {
        this.Department = department;

        return this;
    }
    public Employee UpdateProject(Project project)
    {
        this.Project = project;

        return this;
    }
    public Employee UpdateJobPosition(JobPosition jobPosition)
    {
        this.JobPosition = jobPosition;

        return this;
    }

    private void Validate(string personelCode, 
                          string firstName, 
                          string lastName,
                          string phone,
                          string email)
    {
        this.ValidatePersonelCode(personelCode);
        this.ValidateFirstName(firstName);
        this.ValidateLastName(lastName);
        this.ValidatePhone(phone);
        this.ValidateEmail(email);
    }

    private void ValidatePersonelCode(string personelCode)
        => Validations.ForStringNumeric<InvalidEmployeeException>(
            personelCode,
            nameof(this.PersonelCode));

    private void ValidateFirstName(string firstName)
        => Validations.ForStringLength<InvalidEmployeeException>(
            firstName,
            MinNameLength,
            MaxNameLength,
            nameof(this.FirstName));

    private void ValidateLastName(string lastName)
        => Validations.ForStringLength<InvalidEmployeeException>(
            lastName,
            MinNameLength,
            MaxNameLength,
            nameof(this.LastName));

    private void ValidatePhone(string phone)
        => Validations.ForStringNumeric<InvalidEmployeeException>(
        phone,
        nameof(this.Phone));

    private void ValidateEmail(string email)
        => Validations.ForStringNumeric<InvalidEmployeeException>(
        email,
        nameof(this.Email));
}