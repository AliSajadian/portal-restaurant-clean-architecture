namespace Portal.Application.Restaurant.GuestDayMealJunctions.Commands.Create;

using System.Collections.Generic;
using FluentAssertions;
using FluentValidation.TestHelper;
using Xunit;

using static Portal.Domain.Restaurant.Models.ModelConstants.GuestDayMealJunction;

public class GuestDayMealJunctionCreateCommandValidatorSpecs
{
    private readonly GuestDayMealJunctionCreateCommandValidator validator = new();
    private static readonly string InvalidMinQty = new('t', MinQty - 1);
    private static readonly string InvalidMaxQty = new('t', MaxQty + 1);
    private static readonly string ValidMinQty = new('t', MinQty);
    private static readonly string ValidMaxQty = new('t', MaxQty);


    [Theory]
    [MemberData(nameof(InvalidData))]
    public void ShouldHaveValidationErrorIfNameHaveInvalidLength(
        short qty)
    {
        var testResult = this.validator.TestValidate(new GuestDayMealJunctionCreateCommand
        {
            Qty = qty,
        });

        testResult.IsValid.Should().BeFalse();
        testResult.ShouldHaveValidationErrorFor(a => a.Qty);
    }

    [Theory]
    [MemberData(nameof(ValidData))]
    public void ShouldNotHaveValidationErrorIfNameHaveValidLength(
        short qty)
    {
        var testResult = this.validator.TestValidate(new GuestDayMealJunctionCreateCommand
        {
            Qty = qty,
        });

        testResult.IsValid.Should().BeTrue();
        testResult.ShouldNotHaveValidationErrorFor(a => a.Qty);
    }

    public static IEnumerable<object[]> InvalidData()
    {
        yield return new object[] { InvalidMinQty };
        yield return new object[] { InvalidMaxQty };
    }

    public static IEnumerable<object[]> ValidData()
    {
        yield return new object[] { ValidMinQty };
        yield return new object[] { ValidMaxQty };
    }
}