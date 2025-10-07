using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Repositories;

namespace WebExtensions.Net.Generator.EntitiesRegistration.ClassEntityRegistrars
{
    public class EmptyClassEntityRegistrar(EntitiesContext entitiesContext) : BaseClassEntityRegistrar(entitiesContext)
    {
        protected override ClassType GetClassType() => ClassType.EmptyClass;
    }
}
