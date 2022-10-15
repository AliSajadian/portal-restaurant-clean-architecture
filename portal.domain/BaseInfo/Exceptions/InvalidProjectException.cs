namespace Portal.Domain.BaseInfo.Exceptions;

using Common;

public class InvalidProjectException : BaseDomainException
{
    public InvalidProjectException()
    {
    }

    public InvalidProjectException(string error) => this.Error = error;
}