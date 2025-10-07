using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Repositories;

namespace WebExtensions.Net.Generator.EntitiesRegistration.ClassEntityRegistrars
{
    public class CombinedCallbackParameterClassEntityRegistrar(EntitiesContext entitiesContext, RegistrationOptions registrationOptions) : BaseClassEntityRegistrar(entitiesContext)
    {
        private readonly RegistrationOptions registrationOptions = registrationOptions;

        protected override ClassType GetClassType() => ClassType.CombinedCallbackParameterClass;
        protected override bool ShouldSortProperties() => false;
        protected override string? GetBaseClassName() => registrationOptions.CombinedCallbackParameterClassBaseClassName;
    }
}
