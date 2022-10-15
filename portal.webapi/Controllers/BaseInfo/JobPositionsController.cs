namespace Portal.Web.Controllers;

using System.Threading.Tasks;
using Application.BaseInfo.JobPositions.Commands.Create;
using Application.BaseInfo.JobPositions.Commands.Delete;
using Application.BaseInfo.JobPositions.Commands.Edit;
using Application.BaseInfo.JobPositions.Queries.Details;
using Application.BaseInfo.JobPositions.Queries.Search;
using Application.Common;
using Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[AuthorizeAdministrator]
public class JobPositionsController : ApiController
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<JobPositionsSearchResponseModel>> Search(
        [FromQuery] JobPositionsSearchQuery query)
        => await this.Send(query);

    [HttpGet]
    [Route(Id)]
    [AllowAnonymous]
    public async Task<ActionResult<JobPositionDetailsResponseModel?>> Details(
        [FromRoute] JobPositionDetailsQuery query)
        => await this.Send(query);

    [HttpPost]
    public async Task<ActionResult<int>> Create(
        JobPositionCreateCommand command)
        => await this.Send(command);

    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult<int>> Edit(
        int id, JobPositionEditCommand command)
        => await this.Send(command.SetId(id));

    [HttpDelete]
    [Route(Id)]
    public async Task<ActionResult> Delete(
        [FromRoute] JobPositionDeleteCommand command)
        => await this.Send(command);
}