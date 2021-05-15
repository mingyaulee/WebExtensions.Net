using WebExtension.Net.Generator.Models;
using WebExtension.Net.Generator.Repositories;

namespace WebExtension.Net.Generator.EntitiesRegistration.ClassEntityRegistrars
{
    public class EventTypeClassEntityRegistrar : BaseClassEntityRegistrar
    {
        public EventTypeClassEntityRegistrar(EntitiesContext entitiesContext) : base(entitiesContext)
        {
        }

        protected override ClassType GetClassType() => ClassType.TypeClass;
        protected override string? GetBaseClassName() => $"{Constants.RelativeNamespaceToken}.Events.Event";
    }
}
