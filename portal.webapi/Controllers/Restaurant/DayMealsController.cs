namespace Portal.Web.Controllers;

using System.Threading.Tasks;
using Application.Restaurant.DayMeals.Commands.Create;
using Application.Restaurant.DayMeals.Commands.Delete;
using Application.Restaurant.DayMeals.Commands.Edit;
using Application.Restaurant.DayMeals.Queries.Details;
using Application.Restaurant.DayMeals.Queries.Search;
using Application.Common;
using Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[AuthorizeAdministrator]
public class DayMealsController : ApiController
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<DayMealsSearchResponseModel>> Search(
        [FromQuery] DayMealsSearchQuery query)
        => await this.Send(query);

    [HttpGet]
    [Route(Id)]
    [AllowAnonymous]
    public async Task<ActionResult<DayMealDetailsResponseModel?>> Details(
        [FromRoute] DayMealDetailsQuery query)
        => await this.Send(query);

    [HttpPost]
    public async Task<ActionResult<int>> Create(
        DayMealCreateCommand command)
        => await this.Send(command);

    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult<int>> Edit(
        int id, DayMealEditCommand command)
        => await this.Send(command.SetId(id));

    [HttpDelete]
    [Route(Id)]
    public async Task<ActionResult> Delete(
        [FromRoute] DayMealDeleteCommand command)
        => await this.Send(command);
}