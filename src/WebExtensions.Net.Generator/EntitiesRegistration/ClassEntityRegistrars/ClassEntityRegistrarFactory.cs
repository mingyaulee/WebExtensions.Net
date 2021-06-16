using System;
using Microsoft.Extensions.DependencyInjection;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.EntitiesRegistration.ClassEntityRegistrars
{
    public class ClassEntityRegistrarFactory
    {
        private readonly TypeClassEntityRegistrar typeClassEntityRegistrar;
        private readonly EventTypeClassEntityRegistrar eventTypeClassEntityRegistrar;
        private readonly CombinedCallbackParameterClassEntityRegistrar combinedCallbackParameterClassEntityRegistrar;
        private readonly EnumClassEntityRegistrar enumClassEntityRegistrar;
        private readonly StringFormatClassEntityRegistrar stringFormatClassEntityRegistrar;
        private readonly ArrayClassEntityRegistrar arrayClassEntityRegistrar;
        private readonly MultiTypeClassEntityRegistrar multiTypeClassEntityRegistrar;
        private readonly EmptyClassEntityRegistrar emptyClassEntityRegistrar;

        public ClassEntityRegistrarFactory(IServiceProvider serviceProvider)
        {
            typeClassEntityRegistrar = serviceProvider.GetRequiredService<TypeClassEntityRegistrar>();
            eventTypeClassEntityRegistrar = serviceProvider.GetRequiredService<EventTypeClassEntityRegistrar>();
            combinedCallbackParameterClassEntityRegistrar = serviceProvider.GetRequiredService<CombinedCallbackParameterClassEntityRegistrar>();
            enumClassEntityRegistrar = serviceProvider.GetRequiredService<EnumClassEntityRegistrar>();
            stringFormatClassEntityRegistrar = serviceProvider.GetRequiredService<StringFormatClassEntityRegistrar>();
            arrayClassEntityRegistrar = serviceProvider.GetRequiredService<ArrayClassEntityRegistrar>();
            multiTypeClassEntityRegistrar = serviceProvider.GetRequiredService<MultiTypeClassEntityRegistrar>();
            emptyClassEntityRegistrar = serviceProvider.GetRequiredService<EmptyClassEntityRegistrar>();
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
            else if (typeDefinition.Type == ObjectType.CombinedCallbackParameterObject)
            {
                return combinedCallbackParameterClassEntityRegistrar;
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
