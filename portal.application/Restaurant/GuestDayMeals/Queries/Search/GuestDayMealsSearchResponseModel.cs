namespace Portal.Application.Restaurant.GuestDayMeals.Queries.Search;

using System.Collections.Generic;
using Application.Common.Models;
using Common;

public class GuestDayMealsSearchResponseModel : PaginatedResponseModel<GuestDayMealResponseModel>
{
    internal GuestDayMealsSearchResponseModel(
        IEnumerable<GuestDayMealResponseModel> models,
        int page,
        int totalPages)
        : base(models, page, totalPages)
    {
    }
}