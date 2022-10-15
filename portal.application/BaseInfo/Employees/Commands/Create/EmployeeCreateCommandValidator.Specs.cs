namespace Portal.Application.BaseInfo.Employees.Commands.Create;

using System.Collections.Generic;
using FluentAssertions;
using FluentValidation.TestHelper;
using Xunit;

using static Domain.BaseInfo.Models.ModelConstants.Employee;
using static Domain.Common.Models.ModelConstants.Common;

public class EmployeeCreateCommandValidatorSpecs
{
    private readonly EmployeeCreateCommandValidator validator = new();

    private static readonly string InvalidMinPersonnelCodeLength = new('t', MinPersonnelCodeLength - 1);
    private static readonly string InvalidMinFirstNameLength = new('t', MinNameLength - 1);
    private static readonly string InvalidMinLastNameLength = new('t', MinNameLength - 1);

    private static readonly string InvalidMaxPersonnelCodeLength = new('t', MaxPersonnelCodeLength + 1);
    private static readonly string InvalidMaxFirstNameLength = new('t', MaxNameLength + 1);
    private static readonly string InvalidMaxLastNameLength = new('t', MaxNameLength + 1);

    private static readonly string ValidMinPersonnelCodeLength = new('t', MinPersonnelCodeLength);
    private static readonly string ValidMinFirstNameLength = new('t', MinNameLength);
    private static readonly string ValidMinLastNameLength = new('t', MinNameLength);

    private static readonly string ValidMaxPersonnelCodeLength = new('t', MaxPersonnelCodeLength);
    private static readonly string ValidMaxFirstNameLength = new('t', MaxNameLength);
    private static readonly string ValidMaxLastNameLength = new('t', MaxNameLength);

    [Theory]
    [MemberData(nameof(InvalidData))]
    public void ShouldHaveValidationErrorIfNameAndDescriptionHaveInvalidLength(
        string personelCode,
        string firstName,
        string lastName
        // string phone,
        // string email
        )
    {
        var testResult = this.validator.TestValidate(new EmployeeCreateCommand
        {
            PersonelCode = personelCode,
            FirstName = firstName,
            LastName = lastName,
            // Phone = phone,
            // Email = email
        });

        testResult.IsValid.Should().BeFalse();
        testResult.ShouldHaveValidationErrorFor(b => b.PersonelCode);
        testResult.ShouldHaveValidationErrorFor(b => b.FirstName);
        testResult.ShouldHaveValidationErrorFor(b => b.LastName);
        // testResult.ShouldHaveValidationErrorFor(b => b.Phone);
        // testResult.ShouldHaveValidationErrorFor(b => b.Email);
    }

    [Theory]
    [MemberData(nameof(ValidData))]
    public void ShouldNotHaveValidationErrorIfNameAndDescriptionHaveValidLength(
        string personelCode,
        string firstName,
        string lastName
        // string phone,
        // string email
        )
    {
        var testResult = this.validator.TestValidate(new EmployeeCreateCommand
        {
            PersonelCode = personelCode,
            FirstName = firstName,
            LastName = lastName,
            // Phone = phone,
            // Email = email
        });

        testResult.IsValid.Should().BeTrue();
        testResult.ShouldNotHaveValidationErrorFor(b => b.PersonelCode);
        testResult.ShouldNotHaveValidationErrorFor(b => b.FirstName);
        testResult.ShouldNotHaveValidationErrorFor(b => b.LastName);
        // testResult.ShouldNotHaveValidationErrorFor(b => b.Phone);
        // testResult.ShouldNotHaveValidationErrorFor(b => b.Email);
    }

    public static IEnumerable<object[]> InvalidData()
    {
        yield return new object[] { InvalidMinPersonnelCodeLength, InvalidMinFirstNameLength, InvalidMinLastNameLength };
        yield return new object[] { InvalidMaxPersonnelCodeLength, InvalidMaxFirstNameLength, InvalidMaxLastNameLength };
    }

    public static IEnumerable<object[]> ValidData()
    {
        yield return new object[] { ValidMinPersonnelCodeLength, ValidMinFirstNameLength, ValidMinLastNameLength };
        yield return new object[] { ValidMaxPersonnelCodeLength, ValidMaxFirstNameLength, ValidMaxLastNameLength };
    }
}