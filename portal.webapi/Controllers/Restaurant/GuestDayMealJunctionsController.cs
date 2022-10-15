namespace Portal.Web.Controllers;

using System.Threading.Tasks;
using Application.Restaurant.GuestDayMealJunctions.Commands.Create;
using Application.Restaurant.GuestDayMealJunctions.Commands.Delete;
using Application.Restaurant.GuestDayMealJunctions.Commands.Edit;
using Application.Restaurant.GuestDayMealJunctions.Queries.Details;
using Application.Restaurant.GuestDayMealJunctions.Queries.Search;
using Application.Common;
using Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[AuthorizeAdministrator]
public class GuestDayMealJunctionsController : ApiController
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<GuestDayMealJunctionsSearchResponseModel>> Search(
        [FromQuery] GuestDayMealJunctionsSearchQuery query)
        => await this.Send(query);

    [HttpGet]
    [Route(Id)]
    [AllowAnonymous]
    public async Task<ActionResult<GuestDayMealJunctionDetailsResponseModel?>> Details(
        [FromRoute] GuestDayMealJunctionDetailsQuery query)
        => await this.Send(query);

    [HttpPost]
    public async Task<ActionResult<int>> Create(
        GuestDayMealJunctionCreateCommand command)
        => await this.Send(command);

    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult<int>> Edit(
        int id, GuestDayMealJunctionEditCommand command)
        => await this.Send(command.SetId(id));

    [HttpDelete]
    [Route(Id)]
    public async Task<ActionResult> Delete(
        [FromRoute] GuestDayMealJunctionDeleteCommand command)
        => await this.Send(command);
}