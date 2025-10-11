using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using WebExtensions.Net.Generator.Helpers;
using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Models.Entities;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.EntitiesRegistration;

public class NamespaceApiToTypeDefinitionConverter(EventDefinitionToPropertyDefinitionConverter eventDefinitionToPropertyDefinitionConverter, RegistrationOptions registrationOptions)
{
    private readonly EventDefinitionToPropertyDefinitionConverter eventDefinitionToPropertyDefinitionConverter = eventDefinitionToPropertyDefinitionConverter;
    private readonly RegistrationOptions registrationOptions = registrationOptions;

    public TypeDefinition Convert(NamespaceDefinition namespaceDefinition, NamespaceEntity namespaceEntity) => new()
    {
        Id = namespaceEntity.FormattedName + registrationOptions.ApiClassNameSuffix,
        Description = namespaceDefinition.Description,
        Deprecated = namespaceDefinition.Deprecated,
        Type = ObjectType.Object,
        ObjectFunctions = namespaceDefinition.Functions,
        ObjectProperties = GetNamespaceApiPropertyDefinitions(namespaceDefinition, namespaceEntity),
    };

    private Dictionary<string, PropertyDefinition>? GetNamespaceApiPropertyDefinitions(NamespaceDefinition namespaceDefinition, NamespaceEntity namespaceEntity)
    {
        var properties = new Dictionary<string, PropertyDefinition>();

        if (namespaceDefinition.Properties is not null)
        {
            foreach (var propertyDefinitionPair in namespaceDefinition.Properties)
            {
                var propertyName = propertyDefinitionPair.Key;
                var propertyDefinition = propertyDefinitionPair.Value;
                if (propertyDefinition.IsConstant)
                {
                    properties.Add(propertyName, GetConstantPropertyDefinition(propertyDefinition));
                }
                else
                {
                    properties.Add(propertyName, propertyDefinition);
                }
            }
        }

        if (namespaceDefinition.Events is not null)
        {
            foreach (var eventDefinition in namespaceDefinition.Events)
            {
                if (eventDefinition.Name is null)
                {
                    throw new InvalidOperationException("Event definition should have a Name.");
                }

                var propertyDefinition = eventDefinitionToPropertyDefinitionConverter.Convert(eventDefinition, namespaceEntity);
                properties.Add(eventDefinition.Name, propertyDefinition);
            }
        }

        return properties.Count != 0 ? properties : null;
    }

    private static PropertyDefinition GetConstantPropertyDefinition(PropertyDefinition propertyDefinition)
    {
        var clonePropertyDefinition = SerializationHelper.DeserializeTo<PropertyDefinition>(propertyDefinition);
        if (clonePropertyDefinition.ConstantValue.HasValue)
        {
            clonePropertyDefinition.Type = clonePropertyDefinition.ConstantValue.Value.ValueKind switch
            {
                JsonValueKind.Number => clonePropertyDefinition.ConstantValue.Value.ToString()?.Contains('.') ?? false ? ObjectType.Number : ObjectType.Integer,
                JsonValueKind.False => ObjectType.Boolean,
                JsonValueKind.True => ObjectType.Boolean,
                JsonValueKind.String => ObjectType.String,
                _ => ObjectType.Object
            };
        }
        return clonePropertyDefinition;
    }
}
