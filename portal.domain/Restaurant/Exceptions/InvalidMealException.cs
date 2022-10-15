namespace Portal.Domain.Restaurant.Exceptions;

using Common;

public class InvalidMealException : BaseDomainException
{
    public InvalidMealException()
    {
    }

    public InvalidMealException(string error) => this.Error = error;
}