namespace Portal.Application.BaseInfo.Companies.Queries.Common;

using Application.Common.Mapping;
using Domain.BaseInfo.Models.Companies;

public class CompanyResponseModel : IMapFrom<Company>
{
    public string Name { get; private set; } = default!;
}