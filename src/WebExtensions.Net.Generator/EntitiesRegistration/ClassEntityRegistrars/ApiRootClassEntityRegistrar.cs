using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Repositories;

namespace WebExtensions.Net.Generator.EntitiesRegistration.ClassEntityRegistrars
{
    public class ApiRootClassEntityRegistrar : BaseClassEntityRegistrar
    {
        public ApiRootClassEntityRegistrar(EntitiesContext entitiesContext) : base(entitiesContext)
        {
        }

        protected override ClassType GetClassType() => ClassType.ApiRootClass;
        protected override bool ShouldImplementInterface() => true;
    }
}
