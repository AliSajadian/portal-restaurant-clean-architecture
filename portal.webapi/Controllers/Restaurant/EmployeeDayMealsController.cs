namespace Portal.Web.Controllers;

using System.Threading.Tasks;
using Application.Restaurant.EmployeeDayMeals.Commands.Create;
using Application.Restaurant.EmployeeDayMeals.Commands.Delete;
using Application.Restaurant.EmployeeDayMeals.Commands.Edit;
using Application.Restaurant.EmployeeDayMeals.Queries.Details;
using Application.Restaurant.EmployeeDayMeals.Queries.Search;
using Application.Common;
using Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[AuthorizeAdministrator]
public class EmployeeDayMealsController : ApiController
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<EmployeeDayMealsSearchResponseModel>> Search(
        [FromQuery] EmployeeDayMealsSearchQuery query)
        => await this.Send(query);

    [HttpGet]
    [Route(Id)]
    [AllowAnonymous]
    public async Task<ActionResult<EmployeeDayMealDetailsResponseModel?>> Details(
        [FromRoute] EmployeeDayMealDetailsQuery query)
        => await this.Send(query);

    [HttpPost]
    public async Task<ActionResult<int>> Create(
        EmployeeDayMealCreateCommand command)
        => await this.Send(command);

    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult<int>> Edit(
        int id, EmployeeDayMealEditCommand command)
        => await this.Send(command.SetId(id));

    [HttpDelete]
    [Route(Id)]
    public async Task<ActionResult> Delete(
        [FromRoute] EmployeeDayMealDeleteCommand command)
        => await this.Send(command);
}