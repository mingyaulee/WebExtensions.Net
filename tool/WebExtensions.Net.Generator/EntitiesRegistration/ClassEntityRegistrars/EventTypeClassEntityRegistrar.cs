using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Repositories;

namespace WebExtensions.Net.Generator.EntitiesRegistration.ClassEntityRegistrars
{
    public class EventTypeClassEntityRegistrar(EntitiesContext entitiesContext) : BaseClassEntityRegistrar(entitiesContext)
    {
        protected override ClassType GetClassType() => ClassType.TypeClass;
        protected override string? GetBaseClassName() => $"{Constants.RelativeNamespaceToken}.Events.Event";
    }
}
