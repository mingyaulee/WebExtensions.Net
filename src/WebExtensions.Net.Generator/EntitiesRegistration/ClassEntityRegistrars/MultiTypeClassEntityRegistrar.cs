using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Repositories;

namespace WebExtensions.Net.Generator.EntitiesRegistration.ClassEntityRegistrars
{
    public class MultiTypeClassEntityRegistrar : BaseClassEntityRegistrar
    {
        private readonly RegistrationOptions registrationOptions;

        public MultiTypeClassEntityRegistrar(EntitiesContext entitiesContext, RegistrationOptions registrationOptions) : base(entitiesContext)
        {
            this.registrationOptions = registrationOptions;
        }

        protected override ClassType GetClassType() => ClassType.MultitypeClass;
        protected override string? GetBaseClassName() => registrationOptions.MultiTypeClassBaseClassName;
    }
}
