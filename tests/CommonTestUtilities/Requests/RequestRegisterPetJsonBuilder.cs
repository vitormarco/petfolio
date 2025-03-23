using Bogus;
using Petfolio.Communication.Enums;
using Petfolio.Communication.Requests;

namespace CommonTestUtilities.Requests;

public static class RequestRegisterPetJsonBuilder
{
    public static RequestPetJson Build()
    {
        return new Faker<RequestPetJson>()
                    .RuleFor(request => request.Name, faker => faker.Name.FirstName())
                    .RuleFor(request => request.BirthDay, faker => faker.Date.Past())
                    .RuleFor(request => request.Specie, faker => faker.PickRandom<SpecieType>())
                    .RuleFor(request => request.Breed, faker => faker.Name.Random.String())
                    .RuleFor(request => request.Weight, faker => faker.Random.Double(min: 1, max: 60))
                    .RuleFor(request => request.Gender, faker => faker.PickRandom<GenderType>())
                    .RuleFor(request => request.FurColor, faker => faker.Lorem.Text())
                    .RuleFor(request => request.ReproductiveStatus, faker => faker.PickRandom<ReproductiveStatusType>());
    }
}