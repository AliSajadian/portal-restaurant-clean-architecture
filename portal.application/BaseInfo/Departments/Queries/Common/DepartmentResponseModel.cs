namespace Portal.Application.BaseInfo.Departments.Queries.Common;

using Application.Common.Mapping;
using Domain.BaseInfo.Models.Departments;

public class DepartmentResponseModel : IMapFrom<Department>
{
    public string Name { get; private set; } = default!;
}