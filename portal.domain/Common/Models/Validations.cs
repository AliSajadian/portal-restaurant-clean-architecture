namespace Portal.Domain.Common.Models;

using System.Linq;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

public static class Validations
{
    public static void AgainstEmptyString<TException>(string value, string name = "Value")
        where TException : BaseDomainException, new()
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            return;
        }

        ThrowException<TException>($"{name} cannot be null or empty.");
    }

    public static void ForStringLength<TException>(string value, int minLength, int maxLength, string name = "Value")
        where TException : BaseDomainException, new()
    {
        AgainstEmptyString<TException>(value, name);

        if (minLength <= value.Length && value.Length <= maxLength)
        {
            return;
        }

        ThrowException<TException>($"{name} must have between {minLength} and {maxLength} symbols.");
    }

    public static void ForStringNumeric<TException>(string value, string name = "Value")
        where TException : BaseDomainException, new()
    {
        AgainstEmptyString<TException>(value, name);

        if(value.All(char.IsDigit))
        {
            return;
        }

        ThrowException<TException>($"{name} must be numeric.");
    }

    public static void AgainstOutOfRange<TException>(int number, int min, int max, string name = "Value")
        where TException : BaseDomainException, new()
    {
        AgainstEmptyString<TException>(number.ToString(), name);

        if (min <= number && number <= max)
        {
            return;
        }

        ThrowException<TException>($"{name} must be between {min} and {max}.");
    }

    public static void AgainstOutOfRangeNullable<TException>(int? number, int min, int max, string name = "Value")
        where TException : BaseDomainException, new()
    {
        AgainstEmptyString<TException>(number.ToString() ?? "", name);

        if (min <= number && number <= max)
        {
            return;
        }

        ThrowException<TException>($"{name} must be between {min} and {max}.");
    }

    public static void AgainstOutOfRange<TException>(decimal number, decimal min, decimal max, string name = "Value")
        where TException : BaseDomainException, new()
    {
        if (min <= number && number <= max)
        {
            return;
        }

        ThrowException<TException>($"{name} must be between {min} and {max}.");
    }

    public static void ForStringPhone<TException>(string value, string name = "Value")
        where TException : BaseDomainException, new()
    {
        AgainstEmptyString<TException>(value, name);
        var phoneNumber = value.Trim()
                               .Replace(" ", "")
                               .Replace("-", "")
                               .Replace("(", "")
                               .Replace(")", "");

        if(Regex.Match(phoneNumber, @"^(\+[0-9]{9})$").Success)
        {
            return;
        }

        ThrowException<TException>($"{name} must be a phone number ");
    }

    public static void ForStringEmail<TException>(string value, string name = "Value")
        where TException : BaseDomainException, new()
    {
        AgainstEmptyString<TException>(value, name);
        var email = value.Trim();

        if(new EmailAddressAttribute().IsValid(email))
        {
            return;
        }

        ThrowException<TException>($"{name} must be an email ");
    }
    private static void ThrowException<TException>(string message)
        where TException : BaseDomainException, new()
    {
        var exception = new TException
        {
            Error = message
        };

        throw exception;
    }
}