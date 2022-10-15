namespace Portal.Web.Controllers;

using System.Threading.Tasks;
using Application.BaseInfo.Departments.Commands.Create;
using Application.BaseInfo.Departments.Commands.Delete;
using Application.BaseInfo.Departments.Commands.Edit;
using Application.BaseInfo.Departments.Queries.Details;
using Application.BaseInfo.Departments.Queries.Search;
using Application.Common;
using Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[AuthorizeAdministrator]
public class DepartmentsController : ApiController
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<DepartmentsSearchResponseModel>> Search(
        [FromQuery] DepartmentsSearchQuery query)
        => await this.Send(query);

    [HttpGet]
    [Route(Id)]
    [AllowAnonymous]
    public async Task<ActionResult<DepartmentDetailsResponseModel?>> Details(
        [FromRoute] DepartmentDetailsQuery query)
        => await this.Send(query);

    [HttpPost]
    public async Task<ActionResult<int>> Create(
        DepartmentCreateCommand command)
        => await this.Send(command);

    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult<int>> Edit(
        int id, DepartmentEditCommand command)
        => await this.Send(command.SetId(id));

    [HttpDelete]
    [Route(Id)]
    public async Task<ActionResult> Delete(
        [FromRoute] DepartmentDeleteCommand command)
        => await this.Send(command);
}