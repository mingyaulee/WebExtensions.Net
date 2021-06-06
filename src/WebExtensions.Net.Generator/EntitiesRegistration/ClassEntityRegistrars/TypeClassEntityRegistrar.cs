using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Repositories;

namespace WebExtensions.Net.Generator.EntitiesRegistration.ClassEntityRegistrars
{
    public class TypeClassEntityRegistrar : BaseClassEntityRegistrar
    {
        private readonly RegistrationOptions registrationOptions;

        public TypeClassEntityRegistrar(EntitiesContext entitiesContext, RegistrationOptions registrationOptions) : base(entitiesContext)
        {
            this.registrationOptions = registrationOptions;
        }

        protected override ClassType GetClassType() => ClassType.TypeClass;
        protected override string? GetBaseClassName() => registrationOptions.ObjectTypeClassBaseClassName;
    }
}
