namespace Portal.Application.BaseInfo.Employees.Queries.Common;

using Application.Common.Mapping;
using Domain.BaseInfo.Models.Employees;

public class EmployeeResponseModel : IMapFrom<Employee>
{
    public int Id { get; private set; } = default!;
    public string PersonelCode { get; private set; } = default!;
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public bool Gender { get; private set; } = default!;
    public string Picture { get; private set; } = default!;
    public string Phone { get; private set; } = default!;
    public string Email{ get; private set; } = default!;
    public bool IsActive { get; private set; } = default!;
    public string Department { get; private set; } = default!;
    public string JobPosition { get; private set; } = default!;
    public string Project { get; private set; } = default!;
    public int UserId { get; private set; } = default!;
}