using FluentValidation;
using Petfolio.Communication.Requests;
using Petfolio.Exception;

namespace Petfolio.Application.UseCases.Pets.Register;

public class RegisterPetValidator : AbstractValidator<RequestPetJson>
{
    public RegisterPetValidator()
    {
        RuleFor(pet => pet.Name)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.NAME_REQUIRED);
        RuleFor(pet => pet.BirthDay)
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage(ResourceErrorMessages.BIRTHDAY_CANNOT_BE_IN_FUTURE);
        RuleFor(pet => pet.Specie)
            .IsInEnum()
            .WithMessage(ResourceErrorMessages.SPECIE_TYPE_INVALID);
        RuleFor(pet => pet.Breed)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.BREED_REQUIRED);
        RuleFor(pet => pet.Weight)
            .GreaterThan(0)
            .WithMessage(ResourceErrorMessages.WEIGHT_MUST_BE_GREATER_THAN_ZERO);
        RuleFor(pet => pet.Gender)
            .IsInEnum()
            .WithMessage(ResourceErrorMessages.GENDER_TYPE_INVALID);
        RuleFor(pet => pet.FurColor)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.FUR_COLOR_IS_REQUIRED);
        RuleFor(pet => pet.ReproductiveStatus)
            .IsInEnum()
            .WithMessage(ResourceErrorMessages.REPRODUCTIVE_STATUS_INVALID);
        RuleFor(pet => pet.Size)
            .IsInEnum()
            .WithMessage(ResourceErrorMessages.SIZE_INVALID)
            .When(pet => pet.Size.HasValue);
    }
}