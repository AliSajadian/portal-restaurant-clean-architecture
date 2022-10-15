namespace Portal.Web.Controllers;

using System.Threading.Tasks;
using Application.BaseInfo.Companies.Commands.Create;
using Application.BaseInfo.Companies.Commands.Delete;
using Application.BaseInfo.Companies.Commands.Edit;
using Application.BaseInfo.Companies.Queries.Details;
using Application.BaseInfo.Companies.Queries.Search;
using Application.Common;
using Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[AuthorizeAdministrator]
public class CompaniesController : ApiController
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<CompaniesSearchResponseModel>> Search(
        [FromQuery] CompaniesSearchQuery query)
        => await this.Send(query);

    [HttpGet]
    [Route(Id)]
    [AllowAnonymous]
    public async Task<ActionResult<CompanyDetailsResponseModel?>> Details(
        [FromRoute] CompanyDetailsQuery query)
        => await this.Send(query);

    [HttpPost]
    public async Task<ActionResult<int>> Create(
        CompanyCreateCommand command)
        => await this.Send(command);

    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult<int>> Edit(
        int id, CompanyEditCommand command)
        => await this.Send(command.SetId(id));

    [HttpDelete]
    [Route(Id)]
    public async Task<ActionResult> Delete(
        [FromRoute] CompanyDeleteCommand command)
        => await this.Send(command);
}