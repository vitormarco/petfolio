using Petfolio.Communication.Enums;

namespace Petfolio.Communication.Requests;

public class RequestPetJson
{
    public string Name { get; set; } = string.Empty;
    public DateTime BirthDay { get; set; }
    public SpeciesType Specie { get; set; }
    public string Breed { get; set; } = string.Empty;
    public double Weight { get; set; }
    public GenderType Gender { get; set; }
}
 