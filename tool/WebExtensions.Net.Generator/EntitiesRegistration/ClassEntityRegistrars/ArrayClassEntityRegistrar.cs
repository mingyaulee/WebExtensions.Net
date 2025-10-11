using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Repositories;

namespace WebExtensions.Net.Generator.EntitiesRegistration.ClassEntityRegistrars;

public class ArrayClassEntityRegistrar(EntitiesContext entitiesContext, RegistrationOptions registrationOptions) : BaseClassEntityRegistrar(entitiesContext)
{
    private readonly RegistrationOptions registrationOptions = registrationOptions;

    protected override ClassType GetClassType() => ClassType.ArrayClass;
    protected override string? GetBaseClassName() => registrationOptions.ArrayClassBaseClassName;
}
