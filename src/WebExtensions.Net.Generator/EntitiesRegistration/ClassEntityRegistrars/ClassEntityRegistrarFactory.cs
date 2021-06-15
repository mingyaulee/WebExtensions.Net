using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.EntitiesRegistration.ClassEntityRegistrars
{
    public class ClassEntityRegistrarFactory
    {
        private readonly TypeClassEntityRegistrar typeClassEntityRegistrar;
        private readonly EventTypeClassEntityRegistrar eventTypeClassEntityRegistrar;
        private readonly EnumClassEntityRegistrar enumClassEntityRegistrar;
        private readonly StringFormatClassEntityRegistrar stringFormatClassEntityRegistrar;
        private readonly ArrayClassEntityRegistrar arrayClassEntityRegistrar;
        private readonly MultiTypeClassEntityRegistrar multiTypeClassEntityRegistrar;
        private readonly EmptyClassEntityRegistrar emptyClassEntityRegistrar;

        public ClassEntityRegistrarFactory(
            TypeClassEntityRegistrar typeClassEntityRegistrar,
            EventTypeClassEntityRegistrar eventTypeClassEntityRegistrar,
            EnumClassEntityRegistrar enumClassEntityRegistrar,
            StringFormatClassEntityRegistrar stringFormatClassEntityRegistrar,
            ArrayClassEntityRegistrar arrayClassEntityRegistrar,
            MultiTypeClassEntityRegistrar multiTypeClassEntityRegistrar,
            EmptyClassEntityRegistrar emptyClassEntityRegistrar)
        {
            this.typeClassEntityRegistrar = typeClassEntityRegistrar;
            this.eventTypeClassEntityRegistrar = eventTypeClassEntityRegistrar;
            this.enumClassEntityRegistrar = enumClassEntityRegistrar;
            this.stringFormatClassEntityRegistrar = stringFormatClassEntityRegistrar;
            this.arrayClassEntityRegistrar = arrayClassEntityRegistrar;
            this.multiTypeClassEntityRegistrar = multiTypeClassEntityRegistrar;
            this.emptyClassEntityRegistrar = emptyClassEntityRegistrar;
        }

        public BaseClassEntityRegistrar? GetClassEntityRegistrar(TypeDefinition typeDefinition)
        {
            if (typeDefinition.Type == ObjectType.Object || typeDefinition.Type == ObjectType.ApiObject)
            {
                return typeClassEntityRegistrar;
            }
            else if (typeDefinition.Type == ObjectType.EventTypeObject)
            {
                return eventTypeClassEntityRegistrar;
            }
            else if (typeDefinition.Type == ObjectType.String && typeDefinition.EnumValues is not null)
            {
                return enumClassEntityRegistrar;
            }
            else if (typeDefinition.Type == ObjectType.String && (!string.IsNullOrEmpty(typeDefinition.StringFormat) || !string.IsNullOrEmpty(typeDefinition.StringPattern)))
            {
                return stringFormatClassEntityRegistrar;
            }
            else if (typeDefinition.Type == ObjectType.Array && typeDefinition.ArrayItems is not null)
            {
                return arrayClassEntityRegistrar;
            }
            else if (typeDefinition.TypeChoices is not null)
            {
                return multiTypeClassEntityRegistrar;
            }
            else if (typeDefinition.Type == ObjectType.String)
            {
                return emptyClassEntityRegistrar;
            }

            return null;
        }
    }
}
