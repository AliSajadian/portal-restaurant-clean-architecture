namespace Portal.Application.Restaurant.GuestDayMealJunctions.Queries.Search;

using System.Collections.Generic;
using Application.Common.Models;
using Common;

public class GuestDayMealJunctionsSearchResponseModel : PaginatedResponseModel<GuestDayMealJunctionResponseModel>
{
    internal GuestDayMealJunctionsSearchResponseModel(
        IEnumerable<GuestDayMealJunctionResponseModel> models,
        int page,
        int totalPages)
        : base(models, page, totalPages)
    {
    }
}