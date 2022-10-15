namespace Portal.Web.Controllers;

using System.Threading.Tasks;
using Application.BaseInfo.Projects.Commands.Create;
using Application.BaseInfo.Projects.Commands.Delete;
using Application.BaseInfo.Projects.Commands.Edit;
using Application.BaseInfo.Projects.Queries.Details;
using Application.BaseInfo.Projects.Queries.Search;
using Application.Common;
using Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[AuthorizeAdministrator]
public class ProjectsController : ApiController
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<ProjectsSearchResponseModel>> Search(
        [FromQuery] ProjectsSearchQuery query)
        => await this.Send(query);

    [HttpGet]
    [Route(Id)]
    [AllowAnonymous]
    public async Task<ActionResult<ProjectDetailsResponseModel?>> Details(
        [FromRoute] ProjectDetailsQuery query)
        => await this.Send(query);

    [HttpPost]
    public async Task<ActionResult<int>> Create(
        ProjectCreateCommand command)
        => await this.Send(command);

    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult<int>> Edit(
        int id, ProjectEditCommand command)
        => await this.Send(command.SetId(id));

    [HttpDelete]
    [Route(Id)]
    public async Task<ActionResult> Delete(
        [FromRoute] ProjectDeleteCommand command)
        => await this.Send(command);
}