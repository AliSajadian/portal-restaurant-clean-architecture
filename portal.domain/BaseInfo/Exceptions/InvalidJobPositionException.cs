namespace Portal.Domain.BaseInfo.Exceptions;

using Common;

public class InvalidJobPositionException : BaseDomainException
{
    public InvalidJobPositionException()
    {
    }

    public InvalidJobPositionException(string error) => this.Error = error;
}