namespace Portal.Domain.Restaurant.Exceptions;

using Common;

public class InvalidEmployeeDayMealException : BaseDomainException
{
    public InvalidEmployeeDayMealException()
    {
    }

    public InvalidEmployeeDayMealException(string error) => this.Error = error;
}