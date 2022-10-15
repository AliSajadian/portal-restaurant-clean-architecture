namespace Portal.Application.Restaurant.Meals.Queries.Search;

using System.Collections.Generic;
using Application.Common.Models;
using Common;

public class MealsSearchResponseModel : PaginatedResponseModel<MealResponseModel>
{
    internal MealsSearchResponseModel(
        IEnumerable<MealResponseModel> models,
        int page,
        int totalPages)
        : base(models, page, totalPages)
    {
    }
}