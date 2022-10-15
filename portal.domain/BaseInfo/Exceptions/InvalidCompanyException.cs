namespace Portal.Domain.BaseInfo.Exceptions;

using Common;

public class InvalidCompanyException : BaseDomainException
{
    public InvalidCompanyException()
    {
    }

    public InvalidCompanyException(string error) => this.Error = error;
}