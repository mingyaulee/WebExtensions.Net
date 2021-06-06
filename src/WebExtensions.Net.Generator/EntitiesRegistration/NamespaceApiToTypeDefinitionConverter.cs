using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using WebExtensions.Net.Generator.Helpers;
using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Models.Entities;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.EntitiesRegistration
{
    public class NamespaceApiToTypeDefinitionConverter
    {
        private readonly EventDefinitionToPropertyDefinitionConverter eventDefinitionToPropertyDefinitionConverter;
        private readonly RegistrationOptions registrationOptions;

        public NamespaceApiToTypeDefinitionConverter(EventDefinitionToPropertyDefinitionConverter eventDefinitionToPropertyDefinitionConverter, RegistrationOptions registrationOptions)
        {
            this.eventDefinitionToPropertyDefinitionConverter = eventDefinitionToPropertyDefinitionConverter;
            this.registrationOptions = registrationOptions;
        }

        public TypeDefinition Convert(NamespaceDefinition namespaceDefinition, NamespaceEntity namespaceEntity)
        {
            return new TypeDefinition()
            {
                Id = namespaceEntity.FormattedName + registrationOptions.ApiClassNamePostfix,
                Description = namespaceDefinition.Description,
                Type = ObjectType.Object,
                ObjectFunctions = GetNamespaceApiFunctionDefinitions(namespaceDefinition),
                ObjectProperties = GetNamespaceApiPropertyDefinitions(namespaceDefinition, namespaceEntity),
            };
        }

        private static IEnumerable<FunctionDefinition>? GetNamespaceApiFunctionDefinitions(NamespaceDefinition namespaceDefinition)
        {
            var functions = new List<FunctionDefinition>();

            if (namespaceDefinition.Functions is not null)
            {
                functions.AddRange(namespaceDefinition.Functions);
            }

            if (namespaceDefinition.Properties is not null)
            {
                foreach (var propertyDefinitionPair in namespaceDefinition.Properties)
                {
                    var propertyName = propertyDefinitionPair.Key;
                    var propertyDefinition = propertyDefinitionPair.Value;
                    if (propertyDefinition.IsConstant)
                    {
                        continue;
                    }

                    // If this is not a constant property, convert it to a function
                    functions.Add(new FunctionDefinition()
                    {
                        Name = propertyName,
                        Description = $"Gets the '{propertyName}' property.",
                        Type = ObjectType.PropertyGetterFunction,
                        Async = "true",
                        FunctionReturns = SerializationHelper.DeserializeTo<FunctionReturnDefinition>(propertyDefinition)
                    });
                }
            }

            return functions.Any() ? functions : null;
        }

        private IDictionary<string, PropertyDefinition>? GetNamespaceApiPropertyDefinitions(NamespaceDefinition namespaceDefinition, NamespaceEntity namespaceEntity)
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

                    var propertyDefinition = eventDefinitionToPropertyDefinitionConverter.Convert(eventDefinition.Name, eventDefinition, namespaceEntity);
                    properties.Add(eventDefinition.Name, propertyDefinition);
                }
            }

            return properties.Any() ? properties : null;
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
}
