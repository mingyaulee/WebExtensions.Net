using WebExtension.Net.Generator.Models;
using WebExtension.Net.Generator.Repositories;

namespace WebExtension.Net.Generator.EntitiesRegistration.ClassEntityRegistrars
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
