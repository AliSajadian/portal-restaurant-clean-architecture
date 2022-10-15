namespace Portal.Web.Controllers;

using System.Threading.Tasks;
using Application.Restaurant.GuestDayMeals.Commands.Create;
using Application.Restaurant.GuestDayMeals.Commands.Delete;
using Application.Restaurant.GuestDayMeals.Commands.Edit;
using Application.Restaurant.GuestDayMeals.Queries.Details;
using Application.Restaurant.GuestDayMeals.Queries.Search;
using Application.Common;
using Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[AuthorizeAdministrator]
public class GuestDayMealsController : ApiController
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<GuestDayMealsSearchResponseModel>> Search(
        [FromQuery] GuestDayMealsSearchQuery query)
        => await this.Send(query);

    [HttpGet]
    [Route(Id)]
    [AllowAnonymous]
    public async Task<ActionResult<GuestDayMealDetailsResponseModel?>> Details(
        [FromRoute] GuestDayMealDetailsQuery query)
        => await this.Send(query);

    [HttpPost]
    public async Task<ActionResult<int>> Create(
        GuestDayMealCreateCommand command)
        => await this.Send(command);

    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult<int>> Edit(
        int id, GuestDayMealEditCommand command)
        => await this.Send(command.SetId(id));

    [HttpDelete]
    [Route(Id)]
    public async Task<ActionResult> Delete(
        [FromRoute] GuestDayMealDeleteCommand command)
        => await this.Send(command);
}