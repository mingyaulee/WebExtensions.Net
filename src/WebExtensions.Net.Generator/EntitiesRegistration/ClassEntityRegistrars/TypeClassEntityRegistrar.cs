using WebExtension.Net.Generator.Models;
using WebExtension.Net.Generator.Repositories;

namespace WebExtension.Net.Generator.EntitiesRegistration.ClassEntityRegistrars
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
