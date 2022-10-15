namespace Portal.Domain.BaseInfo.Exceptions;

using Common;

public class InvalidEmployeeException : BaseDomainException
{
    public InvalidEmployeeException()
    {
    }

    public InvalidEmployeeException(string error) => this.Error = error;
}