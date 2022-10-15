namespace Portal.Domain.Restaurant.Exceptions;

using Common;

public class InvalidGuestDayMealJunctionException : BaseDomainException
{
    public InvalidGuestDayMealJunctionException()
    {
    }

    public InvalidGuestDayMealJunctionException(string error) => this.Error = error;
}