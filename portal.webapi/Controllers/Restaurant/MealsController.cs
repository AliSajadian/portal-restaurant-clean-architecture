namespace Portal.Web.Controllers;

using System.Threading.Tasks;
using Application.Restaurant.Meals.Commands.Create;
using Application.Restaurant.Meals.Commands.Delete;
using Application.Restaurant.Meals.Commands.Edit;
using Application.Restaurant.Meals.Queries.Details;
using Application.Restaurant.Meals.Queries.Search;
using Application.Common;
using Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[AuthorizeAdministrator]
public class MealsController : ApiController
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<MealsSearchResponseModel>> Search(
        [FromQuery] MealsSearchQuery query)
        => await this.Send(query);

    [HttpGet]
    [Route(Id)]
    [AllowAnonymous]
    public async Task<ActionResult<MealDetailsResponseModel?>> Details(
        [FromRoute] MealDetailsQuery query)
        => await this.Send(query);

    [HttpPost]
    public async Task<ActionResult<int>> Create(
        MealCreateCommand command)
        => await this.Send(command);

    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult<int>> Edit(
        int id, MealEditCommand command)
        => await this.Send(command.SetId(id));

    [HttpDelete]
    [Route(Id)]
    public async Task<ActionResult> Delete(
        [FromRoute] MealDeleteCommand command)
        => await this.Send(command);
}