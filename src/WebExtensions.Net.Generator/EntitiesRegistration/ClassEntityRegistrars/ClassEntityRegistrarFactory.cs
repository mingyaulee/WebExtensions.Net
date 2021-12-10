using System;
using System.Linq;
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
            if (IsTypeClassEntity(typeDefinition))
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
            else if (IsEnumClassEntity(typeDefinition))
            {
                return enumClassEntityRegistrar;
            }
            else if (IsStringFormatClassEntity(typeDefinition))
            {
                return stringFormatClassEntityRegistrar;
            }
            else if (IsArrayClassEntity(typeDefinition))
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

        private static bool IsTypeClassEntity(TypeDefinition typeDefinition)
        {
            return typeDefinition.Type == ObjectType.Object || typeDefinition.Type == ObjectType.ApiObject;
        }

        private static bool IsEnumClassEntity(TypeDefinition typeDefinition)
        {
            if (typeDefinition.Type == ObjectType.String && typeDefinition.EnumValues is not null)
            {
                return true;
            }

            if (typeDefinition.TypeChoices is not null && typeDefinition.TypeChoices.All(IsEnumClassEntity))
            {
                return true;
            }

            return false;
        }

        private static bool IsStringFormatClassEntity(TypeDefinition typeDefinition)
        {
            if (typeDefinition.Type == ObjectType.String && !string.IsNullOrEmpty(typeDefinition.StringFormat))
            {
                return true;
            }

            if (typeDefinition.Type == ObjectType.String && !string.IsNullOrEmpty(typeDefinition.StringPattern))
            {
                return true;
            }
            
            return false;
        }

        private static bool IsArrayClassEntity(TypeDefinition typeDefinition)
        {
            return typeDefinition.Type == ObjectType.Array && typeDefinition.ArrayItems is not null;
        }
    }
}
