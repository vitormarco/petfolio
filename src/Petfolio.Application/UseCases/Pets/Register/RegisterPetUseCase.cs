using Petfolio.Communication.Requests;
using Petfolio.Communication.Responses;
using Petfolio.Exception.ExceptionBase;

namespace Petfolio.Application.UseCases.Pets.Register;

public class RegisterPetUseCase
{
    public ResponseRegisteredPetJson Execute(RequestPetJson request)
    {
        Validate(request);

        return new ResponseRegisteredPetJson
        {
            Id = 7,
            Name = request.Name
        };
    }

    private void Validate(RequestPetJson request)
    {
        var validator = new RegisterPetValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors
                .Select(error => error.ErrorMessage)
                .ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
