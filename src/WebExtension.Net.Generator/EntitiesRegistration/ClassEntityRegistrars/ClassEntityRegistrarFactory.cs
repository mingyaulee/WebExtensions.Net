using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.EntitiesRegistration.ClassEntityRegistrars
{
    public class ClassEntityRegistrarFactory
    {
        private readonly TypeClassEntityRegistrar typeClassEntityRegistrar;
        private readonly EventTypeClassEntityRegistrar eventTypeClassEntityRegistrar;
        private readonly EnumClassEntityRegistrar enumClassEntityRegistrar;
        private readonly StringFormatClassEntityRegistrar stringFormatClassEntityRegistrar;
        private readonly ArrayClassEntityRegistrar arrayClassEntityRegistrar;
        private readonly MultiTypeClassEntityRegistrar multiTypeClassEntityRegistrar;

        public ClassEntityRegistrarFactory(
            TypeClassEntityRegistrar typeClassEntityRegistrar,
            EventTypeClassEntityRegistrar eventTypeClassEntityRegistrar,
            EnumClassEntityRegistrar enumClassEntityRegistrar,
            StringFormatClassEntityRegistrar stringFormatClassEntityRegistrar,
            ArrayClassEntityRegistrar arrayClassEntityRegistrar,
            MultiTypeClassEntityRegistrar multiTypeClassEntityRegistrar)
        {
            this.typeClassEntityRegistrar = typeClassEntityRegistrar;
            this.eventTypeClassEntityRegistrar = eventTypeClassEntityRegistrar;
            this.enumClassEntityRegistrar = enumClassEntityRegistrar;
            this.stringFormatClassEntityRegistrar = stringFormatClassEntityRegistrar;
            this.arrayClassEntityRegistrar = arrayClassEntityRegistrar;
            this.multiTypeClassEntityRegistrar = multiTypeClassEntityRegistrar;
        }

        public BaseClassEntityRegistrar? GetClassEntityRegistrar(TypeDefinition typeDefinition)
        {
            if (typeDefinition.Type == ObjectType.Object)
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

            return null;
        }
    }
}
