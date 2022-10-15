namespace Portal.Application.BaseInfo.Employees.Commands.Common;

using Domain.BaseInfo.Models.Departments;
using Domain.BaseInfo.Models.Projects;
using Domain.BaseInfo.Models.JobPositions;

using Application.Common;

public abstract class EmployeeCommand<TCommand> : EntityCommand<int>
    where TCommand : EntityCommand<int>
{
    public string PersonelCode { get; init; } = default!;
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public bool Gender { get; init; } = default!;
    public string Picture { get; init; } = default!;
    public string Phone { get; init; } = default!;
    public string Email{ get; init; } = default!;
    public bool IsActive { get; init; } = default!;
    public string Department { get; init; } = default!;
    public string JobPosition { get; init; } = default!;
    public string Project { get; init; } = default!;
    public int UserId { get; init; } = default!;
}