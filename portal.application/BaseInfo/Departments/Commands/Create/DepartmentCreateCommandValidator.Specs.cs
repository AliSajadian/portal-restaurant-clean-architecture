namespace Portal.Application.BaseInfo.Departments.Commands.Create;

using System.Collections.Generic;
using FluentAssertions;
using FluentValidation.TestHelper;
using Xunit;

// using static Domain.BaseInfo.Models.ModelConstants.Common;
using static Domain.Common.Models.ModelConstants.Common;

public class DepartmentCreateCommandValidatorSpecs
{
    private readonly DepartmentCreateCommandValidator validator = new();
    private static readonly string InvalidMinNameLength = new('t', MinNameLength - 1);
    private static readonly string InvalidMaxNameLength = new('t', MaxNameLength + 1);
    private static readonly string ValidMinNameLength = new('t', MinNameLength);
    private static readonly string ValidMaxNameLength = new('t', MaxNameLength);


    [Theory]
    [MemberData(nameof(InvalidData))]
    public void ShouldHaveValidationErrorIfNameHaveInvalidLength(
        string name)
    {
        var testResult = this.validator.TestValidate(new DepartmentCreateCommand
        {
            Name = name,
        });

        testResult.IsValid.Should().BeFalse();
        testResult.ShouldHaveValidationErrorFor(a => a.Name);
    }

    [Theory]
    [MemberData(nameof(ValidData))]
    public void ShouldNotHaveValidationErrorIfNameHaveValidLength(
        string name)
    {
        var testResult = this.validator.TestValidate(new DepartmentCreateCommand
        {
            Name = name,
        });

        testResult.IsValid.Should().BeTrue();
        testResult.ShouldNotHaveValidationErrorFor(a => a.Name);
    }

    public static IEnumerable<object[]> InvalidData()
    {
        yield return new object[] { InvalidMinNameLength };
        yield return new object[] { InvalidMaxNameLength };
    }

    public static IEnumerable<object[]> ValidData()
    {
        yield return new object[] { ValidMinNameLength };
        yield return new object[] { ValidMaxNameLength };
    }
}