namespace Portal.Domain.BaseInfo.Exceptions;

using Common;

public class InvalidDepartmentException : BaseDomainException
{
    public InvalidDepartmentException()
    {
    }

    public InvalidDepartmentException(string error) => this.Error = error;
}