namespace Portal.Application.Restaurant.GuestDayMeals.Queries.Search;

using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Restaurant.Models.GuestDayMeals;
using Domain.Restaurant.Specifications.GuestDayMeals;
using Domain.Common;
using MediatR;

public class GuestDayMealsSearchQuery : IRequest<GuestDayMealsSearchResponseModel>
{
    private const int GuestDayMealsPerPage = 10;

    public string? Date { get; init; }

    public int Page { get; init; } = 1;

    public class GuestDayMealsSearchQueryHandler : IRequestHandler<GuestDayMealsSearchQuery, GuestDayMealsSearchResponseModel>
    {
        private readonly IGuestDayMealQueryRepository guestDayMealRepository;

        public GuestDayMealsSearchQueryHandler(IGuestDayMealQueryRepository guestDayMealRepository)
            => this.guestDayMealRepository = guestDayMealRepository;

        public async Task<GuestDayMealsSearchResponseModel> Handle(
            GuestDayMealsSearchQuery request,
            CancellationToken cancellationToken)
        {
            var specification = this.GetGuestDayMealSpecification(request);

            var skip = (request.Page - 1) * GuestDayMealsPerPage;

            var companiesListing = await this.guestDayMealRepository.GetGuestDayMealsListing(
                specification,
                skip,
                take: GuestDayMealsPerPage,
                cancellationToken);

            var totalGuestDayMeals = await this.guestDayMealRepository.Total(
                specification,
                cancellationToken);

            var totalPages = (int)Math.Ceiling((double)totalGuestDayMeals / GuestDayMealsPerPage);

            return new GuestDayMealsSearchResponseModel(companiesListing, request.Page, totalPages);
        }

        private Specification<GuestDayMeal> GetGuestDayMealSpecification(
            GuestDayMealsSearchQuery request)
            => new GuestDayMealByDateSpecification(request.Date);
    }
}