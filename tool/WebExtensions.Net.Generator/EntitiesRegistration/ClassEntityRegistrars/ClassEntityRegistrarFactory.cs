using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.EntitiesRegistration.ClassEntityRegistrars;

public class ClassEntityRegistrarFactory(IServiceProvider serviceProvider)
{
    private readonly TypeClassEntityRegistrar typeClassEntityRegistrar = serviceProvider.GetRequiredService<TypeClassEntityRegistrar>();
    private readonly EventTypeClassEntityRegistrar eventTypeClassEntityRegistrar = serviceProvider.GetRequiredService<EventTypeClassEntityRegistrar>();
    private readonly CombinedCallbackParameterClassEntityRegistrar combinedCallbackParameterClassEntityRegistrar = serviceProvider.GetRequiredService<CombinedCallbackParameterClassEntityRegistrar>();
    private readonly EnumClassEntityRegistrar enumClassEntityRegistrar = serviceProvider.GetRequiredService<EnumClassEntityRegistrar>();
    private readonly StringFormatClassEntityRegistrar stringFormatClassEntityRegistrar = serviceProvider.GetRequiredService<StringFormatClassEntityRegistrar>();
    private readonly ArrayClassEntityRegistrar arrayClassEntityRegistrar = serviceProvider.GetRequiredService<ArrayClassEntityRegistrar>();
    private readonly MultiTypeClassEntityRegistrar multiTypeClassEntityRegistrar = serviceProvider.GetRequiredService<MultiTypeClassEntityRegistrar>();
    private readonly EmptyClassEntityRegistrar emptyClassEntityRegistrar = serviceProvider.GetRequiredService<EmptyClassEntityRegistrar>();

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
        => typeDefinition.Type is ObjectType.Object or ObjectType.ApiObject;

    private static bool IsEnumClassEntity(TypeDefinition typeDefinition)
    {
        if (typeDefinition.Type == ObjectType.String && typeDefinition.EnumValues is not null)
        {
            return true;
        }

        return typeDefinition.TypeChoices is not null && typeDefinition.TypeChoices.All(IsEnumClassEntity);
    }

    private static bool IsStringFormatClassEntity(TypeDefinition typeDefinition)
    {
        if (typeDefinition.Type == ObjectType.String && !string.IsNullOrEmpty(typeDefinition.StringFormat))
        {
            return true;
        }

        return typeDefinition.Type == ObjectType.String && !string.IsNullOrEmpty(typeDefinition.StringPattern);
    }

    private static bool IsArrayClassEntity(TypeDefinition typeDefinition)
        => typeDefinition.Type == ObjectType.Array && typeDefinition.ArrayItems is not null;
}
