using WebExtension.Net.Generator.Models;
using WebExtension.Net.Generator.Repositories;

namespace WebExtension.Net.Generator.EntitiesRegistration.ClassEntityRegistrars
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
