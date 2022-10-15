namespace Portal.Application.Restaurant.GuestDayMeals.Commands.Create;

using System.Collections.Generic;
using FluentAssertions;
using FluentValidation.TestHelper;
using Xunit;

using static Domain.Common.Models.ModelConstants.Common;

public class GuestDayMealCreateCommandValidatorSpecs
{
    private readonly GuestDayMealCreateCommandValidator validator = new();
    private static readonly string InvalidMinDescription = new('t', MinDescriptionLength - 1);
    private static readonly string InvalidMaxDescription = new('t', MaxDescriptionLength + 1);
    private static readonly string ValidMinDescription = new('t', MinDescriptionLength);
    private static readonly string ValidMaxDescription = new('t', MaxDescriptionLength);


    [Theory]
    [MemberData(nameof(InvalidData))]
    public void ShouldHaveValidationErrorIfNameHaveInvalidLength(
        string description)
    {
        var testResult = this.validator.TestValidate(new GuestDayMealCreateCommand
        {
            Description = description,
        });

        testResult.IsValid.Should().BeFalse();
        testResult.ShouldHaveValidationErrorFor(a => a.Description);
    }

    [Theory]
    [MemberData(nameof(ValidData))]
    public void ShouldNotHaveValidationErrorIfNameHaveValidLength(
        string description)
    {
        var testResult = this.validator.TestValidate(new GuestDayMealCreateCommand
        {
            Description = description,
        });

        testResult.IsValid.Should().BeTrue();
        testResult.ShouldNotHaveValidationErrorFor(a => a.Description);
    }

    public static IEnumerable<object[]> InvalidData()
    {
        yield return new object[] { InvalidMinDescription };
        yield return new object[] { InvalidMaxDescription };
    }

    public static IEnumerable<object[]> ValidData()
    {
        yield return new object[] { ValidMinDescription };
        yield return new object[] { ValidMaxDescription };
    }
}