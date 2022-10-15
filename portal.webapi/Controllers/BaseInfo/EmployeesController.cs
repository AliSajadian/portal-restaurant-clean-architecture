namespace Portal.Web.Controllers;

using System.Threading.Tasks;
using Application.BaseInfo.Employees.Commands.Create;
using Application.BaseInfo.Employees.Commands.Delete;
using Application.BaseInfo.Employees.Commands.Edit;
using Application.BaseInfo.Employees.Queries.Details;
using Application.BaseInfo.Employees.Queries.Search;
using Application.Common;
using Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[AuthorizeAdministrator]
public class EmployeesController : ApiController
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<EmployeesSearchResponseModel>> Search(
        [FromQuery] EmployeesSearchQuery query)
        => await this.Send(query);

    [HttpGet]
    [Route(Id)]
    [AllowAnonymous]
    public async Task<ActionResult<EmployeeDetailsResponseModel?>> Details(
        [FromRoute] EmployeeDetailsQuery query)
        => await this.Send(query);

    [HttpPost]
    public async Task<ActionResult<int>> Create(
        EmployeeCreateCommand command)
        => await this.Send(command);

    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult<int>> Edit(
        int id, EmployeeEditCommand command)
        => await this.Send(command.SetId(id));

    [HttpDelete]
    [Route(Id)]
    public async Task<ActionResult> Delete(
        [FromRoute] EmployeeDeleteCommand command)
        => await this.Send(command);
}