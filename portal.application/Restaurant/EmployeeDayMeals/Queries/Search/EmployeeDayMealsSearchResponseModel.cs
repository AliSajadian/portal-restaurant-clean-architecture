namespace Portal.Application.Restaurant.EmployeeDayMeals.Queries.Search;

using System.Collections.Generic;
using Application.Common.Models;
using Common;

public class EmployeeDayMealsSearchResponseModel : PaginatedResponseModel<EmployeeDayMealResponseModel>
{
    internal EmployeeDayMealsSearchResponseModel(
        IEnumerable<EmployeeDayMealResponseModel> models,
        int page,
        int totalPages)
        : base(models, page, totalPages)
    {
    }
}