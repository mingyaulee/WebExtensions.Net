using WebExtension.Net.Generator.Models;
using WebExtension.Net.Generator.Repositories;

namespace WebExtension.Net.Generator.EntitiesRegistration.ClassEntityRegistrars
{
    public class ArrayClassEntityRegistrar : BaseClassEntityRegistrar
    {
        private readonly RegistrationOptions registrationOptions;

        public ArrayClassEntityRegistrar(EntitiesContext entitiesContext, RegistrationOptions registrationOptions) : base(entitiesContext)
        {
            this.registrationOptions = registrationOptions;
        }

        protected override ClassType GetClassType() => ClassType.ArrayClass;
        protected override string? GetBaseClassName() => registrationOptions.ArrayClassBaseClassName;
    }
}
