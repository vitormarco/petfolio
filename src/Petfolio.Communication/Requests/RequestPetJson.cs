using Petfolio.Communication.Enums;

namespace Petfolio.Communication.Requests;

public class RequestPetJson
{
    public string Name { get; set; } = string.Empty;
    public DateTime BirthDay { get; set; }
    public SpecieType Specie { get; set; }
    public string Breed { get; set; } = string.Empty;
    public double Weight { get; set; }
    public GenderType Gender { get; set; }
    public ReproductiveStatusType ReproductiveStatus { get; set; }
    public string FurColor { get; set; } = string.Empty;
    public SizeType? Size { get; set; }
}
 