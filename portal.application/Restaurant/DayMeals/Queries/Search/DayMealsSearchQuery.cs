namespace Portal.Application.Restaurant.DayMeals.Queries.Search;

using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Restaurant.Models.DayMeals;
using Domain.Restaurant.Specifications.DayMeals;
using Domain.Common;
using MediatR;

public class DayMealsSearchQuery : IRequest<DayMealsSearchResponseModel>
{
    private const int DayMealsPerPage = 10;

    public string? Date { get; init; }

    public int Page { get; init; } = 1;

    public class DayMealsSearchQueryHandler : IRequestHandler<DayMealsSearchQuery, DayMealsSearchResponseModel>
    {
        private readonly IDayMealQueryRepository dayMealRepository;

        public DayMealsSearchQueryHandler(IDayMealQueryRepository dayMealRepository)
            => this.dayMealRepository = dayMealRepository;

        public async Task<DayMealsSearchResponseModel> Handle(
            DayMealsSearchQuery request,
            CancellationToken cancellationToken)
        {
            var specification = this.GetDayMealSpecification(request);

            var skip = (request.Page - 1) * DayMealsPerPage;

            var companiesListing = await this.dayMealRepository.GetDayMealsListing(
                specification,
                skip,
                take: DayMealsPerPage,
                cancellationToken);

            var totalDayMeals = await this.dayMealRepository.Total(
                specification,
                cancellationToken);

            var totalPages = (int)Math.Ceiling((double)totalDayMeals / DayMealsPerPage);

            return new DayMealsSearchResponseModel(companiesListing, request.Page, totalPages);
        }

        private Specification<DayMeal> GetDayMealSpecification(
            DayMealsSearchQuery request)
            => new DayMealByDateSpecification(request.Date);
    }
}