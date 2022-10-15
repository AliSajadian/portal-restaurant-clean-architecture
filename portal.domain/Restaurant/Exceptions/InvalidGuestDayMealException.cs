namespace Portal.Domain.Restaurant.Exceptions;

using Common;

public class InvalidGuestDayMealException : BaseDomainException
{
    public InvalidGuestDayMealException()
    {
    }

    public InvalidGuestDayMealException(string error) => this.Error = error;
}