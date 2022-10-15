namespace Portal.Application.Restaurant.DayMeals.Queries.Search;

using System.Collections.Generic;
using Application.Common.Models;
using Common;

public class DayMealsSearchResponseModel : PaginatedResponseModel<DayMealResponseModel>
{
    internal DayMealsSearchResponseModel(
        IEnumerable<DayMealResponseModel> models,
        int page,
        int totalPages)
        : base(models, page, totalPages)
    {
    }
}