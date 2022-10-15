namespace Portal.Application.Restaurant.GuestDayMealJunctions.Queries.Search;

using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Restaurant.Models.GuestDayMealJunctions;
using Domain.Restaurant.Specifications.GuestDayMealJunctions;
using Domain.Common;
using MediatR;

public class GuestDayMealJunctionsSearchQuery : IRequest<GuestDayMealJunctionsSearchResponseModel>
{
    private const int GuestDayMealJunctionsPerPage = 10;

    public string? Date { get; init; }

    public int Page { get; init; } = 1;

    public class GuestDayMealJunctionsSearchQueryHandler : IRequestHandler<GuestDayMealJunctionsSearchQuery, GuestDayMealJunctionsSearchResponseModel>
    {
        private readonly IGuestDayMealJunctionQueryRepository guestDayMealRepository;

        public GuestDayMealJunctionsSearchQueryHandler(IGuestDayMealJunctionQueryRepository guestDayMealRepository)
            => this.guestDayMealRepository = guestDayMealRepository;

        public async Task<GuestDayMealJunctionsSearchResponseModel> Handle(
            GuestDayMealJunctionsSearchQuery request,
            CancellationToken cancellationToken)
        {
            var specification = this.GetGuestDayMealJunctionSpecification(request);

            var skip = (request.Page - 1) * GuestDayMealJunctionsPerPage;

            var companiesListing = await this.guestDayMealRepository.GetGuestDayMealJunctionsListing(
                specification,
                skip,
                take: GuestDayMealJunctionsPerPage,
                cancellationToken);

            var totalGuestDayMealJunctions = await this.guestDayMealRepository.Total(
                specification,
                cancellationToken);

            var totalPages = (int)Math.Ceiling((double)totalGuestDayMealJunctions / GuestDayMealJunctionsPerPage);

            return new GuestDayMealJunctionsSearchResponseModel(companiesListing, request.Page, totalPages);
        }

        private Specification<GuestDayMealJunction> GetGuestDayMealJunctionSpecification(
            GuestDayMealJunctionsSearchQuery request)
            => new GuestDayMealJunctionByDateSpecification(request.Date);
    }
}