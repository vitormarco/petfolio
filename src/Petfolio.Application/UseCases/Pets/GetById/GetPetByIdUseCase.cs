using Petfolio.Communication.Enums;
using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pets.GetById;

public class GetPetByIdUseCase
{
    public ResponsePetJson Execute(int id)
    {
        return new ResponsePetJson 
        {
            Id = id,
            Name = "Dinho",
            Type = SpecieType.Feline,
            BirthDay = new DateTime(year: 2009, month: 1, day: 1),
        };
    }
}
