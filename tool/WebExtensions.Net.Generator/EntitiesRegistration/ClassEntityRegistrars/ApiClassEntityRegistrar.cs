using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Repositories;

namespace WebExtensions.Net.Generator.EntitiesRegistration.ClassEntityRegistrars;

public class ApiClassEntityRegistrar(EntitiesContext entitiesContext, RegistrationOptions registrationOptions) : BaseClassEntityRegistrar(entitiesContext)
{
    private readonly RegistrationOptions registrationOptions = registrationOptions;

    protected override ClassType GetClassType() => ClassType.ApiClass;
    protected override string? GetBaseClassName() => registrationOptions.ApiClassBaseClassName;
    protected override bool ShouldImplementInterface() => true;
}
