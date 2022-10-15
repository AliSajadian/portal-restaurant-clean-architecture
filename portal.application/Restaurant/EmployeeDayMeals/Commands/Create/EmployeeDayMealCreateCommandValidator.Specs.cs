namespace Portal.Application.Restaurant.EmployeeDayMeals.Commands.Create;

using System.Collections.Generic;
using FluentAssertions;
using FluentValidation.TestHelper;
using Xunit;


public class EmployeeDayMealCreateCommandValidatorSpecs
{
    // private readonly EmployeeDayMealCreateCommandValidator validator = new();
    // private static readonly string InvalidMinTotalNo = new('t', MinTotalNo - 1);
    // private static readonly string InvalidMaxTotalNo = new('t', MaxTotalNo + 1);
    // private static readonly string ValidMinTotalNo = new('t', MinTotalNo);
    // private static readonly string ValidMaxTotalNo = new('t', MaxTotalNo);


    // [Theory]
    // [MemberData(nameof(InvalidData))]
    // public void ShouldHaveValidationErrorIfNameHaveInvalidLength(
    //     int totalNo)
    // {
    //     var testResult = this.validator.TestValidate(new EmployeeDayMealCreateCommand
    //     {
    //         TotalNo = totalNo,
    //     });

    //     testResult.IsValid.Should().BeFalse();
    //     testResult.ShouldHaveValidationErrorFor(a => a.TotalNo);
    // }

    // [Theory]
    // [MemberData(nameof(ValidData))]
    // public void ShouldNotHaveValidationErrorIfNameHaveValidLength(
    //     int totalNo)
    // {
    //     var testResult = this.validator.TestValidate(new EmployeeDayMealCreateCommand
    //     {
    //         TotalNo = totalNo,
    //     });

    //     testResult.IsValid.Should().BeTrue();
    //     testResult.ShouldNotHaveValidationErrorFor(a => a.TotalNo);
    // }

    // public static IEnumerable<object[]> InvalidData()
    // {
    //     yield return new object[] { InvalidMinTotalNo };
    //     yield return new object[] { InvalidMaxTotalNo };
    // }

    // public static IEnumerable<object[]> ValidData()
    // {
    //     yield return new object[] { ValidMinTotalNo };
    //     yield return new object[] { ValidMaxTotalNo };
    // }
}