using Petfolio.Communication.Enums;
using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pets.GetAll;

public class GetAllPetsUseCase
{
    public ResponseAllPetJson Execute()
    {
        return new ResponseAllPetJson
        {
            Pets = new List<ResponseShortPetJson>
            {
                new ResponseShortPetJson
                {
                    Id = 1,
                    Name = "Dinho",
                    Type = SpeciesType.Feline,
                },
                new ResponseShortPetJson
                {
                    Id = 2,
                    Name = "Snowbell",
                    Type = SpeciesType.Feline,
                },
                new ResponseShortPetJson
                {
                    Id = 3,
                    Name = "Floki",
                    Type = SpeciesType.Canine,
                },
                new ResponseShortPetJson
                {
                    Id = 4,
                    Name = "Ghost",
                    Type = SpeciesType.Canine,
                },
                new ResponseShortPetJson
                {
                    Id = 5,
                    Name = "Pantera",
                    Type = SpeciesType.Feline,
                },
            }
        };
    }
}
