using CommonTestUtilities.Requests;
using FluentValidation;
using Petfolio.Application.UseCases.Pets.Register;
using Petfolio.Communication.Enums;
using Petfolio.Exception;
using Shouldly;

namespace Validators.Tests.Pets.Register;

public class RegisterPetValidatorTests
{
    [Fact]
    public void Success()
    {
        // Arrange
        var validator = new RegisterPetValidator();
        var request = RequestRegisterPetJsonBuilder.Build();

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeTrue();
    }

    [Theory]
    [InlineData("      ")]
    [InlineData("")]
    [InlineData(null)]
    public void Error_Name_Empty(string? name)
    {
        // Arrange
        var validator = new RegisterPetValidator();
        var request = RequestRegisterPetJsonBuilder.Build();
        request.Name = name ?? string.Empty;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeFalse();
        result
            .Errors
            .ShouldSatisfyAllConditions(
                e => e.ShouldHaveSingleItem(),
                e => e.ShouldContain(
                        message => message
                                    .ErrorMessage
                                    .Equals(ResourceErrorMessages.NAME_REQUIRED)
                    )
            );
    }

    [Fact]
    public void Error_Birthday_Future()
    {
        // Arrange
        var validator = new RegisterPetValidator();
        var request = RequestRegisterPetJsonBuilder.Build();
        request.BirthDay = DateTime.UtcNow.AddDays(1);

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeFalse();
        result
            .Errors
            .ShouldSatisfyAllConditions(
                e => e.ShouldHaveSingleItem(),
                e => e.ShouldContain(
                       message => message
                                    .ErrorMessage
                                    .Equals(ResourceErrorMessages.BIRTHDAY_CANNOT_BE_IN_FUTURE)
                    )
            );
    }

    [Fact]
    public void Error_Specie_Invalid()
    {
        // Arrange
        var validator = new RegisterPetValidator();
        var request = RequestRegisterPetJsonBuilder.Build();
        request.Specie = (SpecieType)999;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeFalse();
        result
            .Errors
            .ShouldSatisfyAllConditions(
                e => e.ShouldHaveSingleItem(),
                e => e.ShouldContain(
                        message => message
                                    .ErrorMessage
                                    .Equals(ResourceErrorMessages.SPECIE_TYPE_INVALID)
                     )
            );
    }

    [Fact]
    public void Error_Breed_Required()
    {
        // Arrange
        var validator = new RegisterPetValidator();
        var request = RequestRegisterPetJsonBuilder.Build();
        request.Breed = string.Empty;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeFalse();
        result
            .Errors
            .ShouldSatisfyAllConditions(
                e => e.ShouldHaveSingleItem(),
                e => e.ShouldContain(
                        message => message
                                    .ErrorMessage
                                    .Equals(ResourceErrorMessages.BREED_REQUIRED)
                     )
            );
    }

    [Fact]
    public void Error_Weight_Invalid()
    {
        // Arrange
        var validator = new RegisterPetValidator();
        var request = RequestRegisterPetJsonBuilder.Build();
        request.Weight = -10;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeFalse();
        result
            .Errors
            .ShouldSatisfyAllConditions(
                e => e.ShouldHaveSingleItem(),
                e => e.ShouldContain(
                        message => message
                                    .ErrorMessage
                                    .Equals(ResourceErrorMessages.WEIGHT_MUST_BE_GREATER_THAN_ZERO)
                    )
            );
    }

    [Fact]
    public void Error_Gender_Invalid()
    {
        // Arrange
        var validator = new RegisterPetValidator();
        var request = RequestRegisterPetJsonBuilder.Build();
        request.Gender = (GenderType)99;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeFalse();
        result
            .Errors
            .ShouldSatisfyAllConditions(
                e => e.ShouldHaveSingleItem(),
                e => e.ShouldContain(
                        message => message
                                    .ErrorMessage
                                    .Equals(ResourceErrorMessages.GENDER_TYPE_INVALID)
                    )
            );
    }

    [Fact]
    public void Error_Reproductive_Status_Type_Invalid()
    {
        // Arrange
        var validator = new RegisterPetValidator();
        var request = RequestRegisterPetJsonBuilder.Build();
        request.ReproductiveStatus = (ReproductiveStatusType)99;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeFalse();
        result
           .Errors
           .ShouldSatisfyAllConditions(
               e => e.ShouldHaveSingleItem(),
               e => e.ShouldContain(
                        message => message
                                    .ErrorMessage
                                    .Equals(ResourceErrorMessages.REPRODUCTIVE_STATUS_INVALID)
                   )
           );
    }

    [Fact]
    public void Error_Size_Invalid()
    {
        // Arrange
        var validator = new RegisterPetValidator();
        var request = RequestRegisterPetJsonBuilder.Build();
        request.Size = (SizeType)999;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeFalse();
        result
            .Errors
            .ShouldSatisfyAllConditions(
                e => e.ShouldHaveSingleItem(),
                e => e.ShouldContain(
                        message => message.ErrorMessage.Equals(ResourceErrorMessages.SIZE_INVALID)
                    )
            );

    }
}
