namespace Portal.Domain.Restaurant.Exceptions;

using Common;

public class InvalidDayMealException : BaseDomainException
{
    public InvalidDayMealException()
    {
    }

    public InvalidDayMealException(string error) => this.Error = error;
}