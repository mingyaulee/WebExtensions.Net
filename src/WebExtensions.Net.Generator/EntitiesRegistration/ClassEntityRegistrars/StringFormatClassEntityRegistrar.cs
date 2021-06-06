using WebExtension.Net.Generator.Models;
using WebExtension.Net.Generator.Repositories;

namespace WebExtension.Net.Generator.EntitiesRegistration.ClassEntityRegistrars
{
    public class StringFormatClassEntityRegistrar : BaseClassEntityRegistrar
    {
        private readonly RegistrationOptions registrationOptions;

        public StringFormatClassEntityRegistrar(EntitiesContext entitiesContext, RegistrationOptions registrationOptions) : base(entitiesContext)
        {
            this.registrationOptions = registrationOptions;
        }

        protected override ClassType GetClassType() => ClassType.StringFormatClass;
        protected override string? GetBaseClassName() => registrationOptions.StringFormatClassBaseClassName;
    }
}
