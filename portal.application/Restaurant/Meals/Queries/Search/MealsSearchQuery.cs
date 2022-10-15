namespace Portal.Application.Restaurant.Meals.Queries.Search;

using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Restaurant.Models.Meals;
using Domain.Restaurant.Specifications.Meals;
using Domain.Common;
using MediatR;

public class MealsSearchQuery : IRequest<MealsSearchResponseModel>
{
    private const int MealsPerPage = 10;

    public string? Name { get; init; }

    public int Page { get; init; } = 1;

    public class MealsSearchQueryHandler : IRequestHandler<MealsSearchQuery, MealsSearchResponseModel>
    {
        private readonly IMealQueryRepository mealRepository;

        public MealsSearchQueryHandler(IMealQueryRepository mealRepository)
            => this.mealRepository = mealRepository;

        public async Task<MealsSearchResponseModel> Handle(
            MealsSearchQuery request,
            CancellationToken cancellationToken)
        {
            var specification = this.GetMealSpecification(request);

            var skip = (request.Page - 1) * MealsPerPage;

            var companiesListing = await this.mealRepository.GetMealsListing(
                specification,
                skip,
                take: MealsPerPage,
                cancellationToken);

            var totalMeals = await this.mealRepository.Total(
                specification,
                cancellationToken);

            var totalPages = (int)Math.Ceiling((double)totalMeals / MealsPerPage);

            return new MealsSearchResponseModel(companiesListing, request.Page, totalPages);
        }

        private Specification<Meal> GetMealSpecification(
            MealsSearchQuery request)
            => new MealByNameSpecification(request.Name);
    }
}