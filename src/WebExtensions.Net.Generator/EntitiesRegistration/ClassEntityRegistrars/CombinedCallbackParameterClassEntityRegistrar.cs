using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Repositories;

namespace WebExtensions.Net.Generator.EntitiesRegistration.ClassEntityRegistrars
{
    public class CombinedCallbackParameterClassEntityRegistrar : BaseClassEntityRegistrar
    {
        private readonly RegistrationOptions registrationOptions;

        public CombinedCallbackParameterClassEntityRegistrar(EntitiesContext entitiesContext, RegistrationOptions registrationOptions) : base(entitiesContext)
        {
            this.registrationOptions = registrationOptions;
        }

        protected override ClassType GetClassType() => ClassType.CombinedCallbackParameterClass;
        protected override bool ShouldSortProperties() => false;
        protected override string? GetBaseClassName() => registrationOptions.CombinedCallbackParameterClassBaseClassName;
    }
}
