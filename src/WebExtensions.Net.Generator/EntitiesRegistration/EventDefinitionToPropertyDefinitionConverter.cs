using System;
using System.Collections.Generic;
using System.Linq;
using WebExtensions.Net.Generator.Helpers;
using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Models.Entities;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.EntitiesRegistration
{
    public class EventDefinitionToPropertyDefinitionConverter
    {
        private readonly RegistrationOptions registrationOptions;
        private readonly TypeEntityRegistrar typeEntityRegistrar;

        public EventDefinitionToPropertyDefinitionConverter(RegistrationOptions registrationOptions, TypeEntityRegistrar typeEntityRegistrar)
        {
            this.registrationOptions = registrationOptions;
            this.typeEntityRegistrar = typeEntityRegistrar;
        }

        public PropertyDefinition Convert(EventDefinition eventDefinition, NamespaceEntity namespaceEntity)
        {
            if (ShouldCreateEventTypeObject(eventDefinition))
            {
                return new PropertyDefinition()
                {
                    Type = ObjectType.EventTypeObject,
                    Description = eventDefinition.Description,
                    IsUnsupported = eventDefinition.IsUnsupported,
                    Deprecated = eventDefinition.Deprecated,
                    ObjectFunctions = GetEventFunctions(eventDefinition, namespaceEntity)
                };
            }

            return new PropertyDefinition()
            {
                Ref = registrationOptions.BaseEventTypeName,
                Type = ObjectType.EventTypeObject,
                Description = eventDefinition.Description,
                IsUnsupported = eventDefinition.IsUnsupported,
                Deprecated = eventDefinition.Deprecated
            };
        }

        private static bool ShouldCreateEventTypeObject(EventDefinition eventDefinition)
        {
            return (eventDefinition.FunctionParameters is not null && eventDefinition.FunctionParameters.Any()) ||
                (eventDefinition.ExtraParameters is not null && eventDefinition.ExtraParameters.Any());
        }

        private IEnumerable<FunctionDefinition> GetEventFunctions(EventDefinition eventDefinition, NamespaceEntity namespaceEntity)
        {
            var functionDefinitions = new List<FunctionDefinition>();
            var baseEventTypeEntity = typeEntityRegistrar.GetTypeEntity(registrationOptions.BaseEventTypeName, namespaceEntity);

            functionDefinitions.AddRange(GetEventFunctionDefinitions(eventDefinition, baseEventTypeEntity, "addListener", false));
            functionDefinitions.AddRange(GetEventFunctionDefinitions(eventDefinition, baseEventTypeEntity, "hasListener", true));
            functionDefinitions.AddRange(GetEventFunctionDefinitions(eventDefinition, baseEventTypeEntity, "removeListener", true));

            return functionDefinitions;
        }

        private static IEnumerable<FunctionDefinition> GetEventFunctionDefinitions(EventDefinition eventDefinition, TypeEntity baseEventTypeEntity, string functionName, bool useBaseFunctionDescription)
        {
            var eventFunctionDefinitions = new List<FunctionDefinition>();
            var baseEventFunction = baseEventTypeEntity.Definition?.ObjectFunctions?.SingleOrDefault(functionDefinition => functionDefinition.Name == functionName);
            if (baseEventFunction is null)
            {
                throw new InvalidOperationException($"Failed to locate '{functionName}' function in type entity '{baseEventTypeEntity.NamespaceQualifiedId}'.");
            }

            var baseEventFunctionParameter = baseEventFunction.FunctionParameters?.SingleOrDefault();
            if (baseEventFunctionParameter is null)
            {
                throw new InvalidOperationException($"'{functionName}' function should have one parameter.");
            }

            var functionParameters = new List<ParameterDefinition>();
            var functionParameter = SerializationHelper.DeserializeTo<ParameterDefinition>(eventDefinition);

            functionParameter.Name = baseEventFunctionParameter.Name;
            if (useBaseFunctionDescription)
            {
                functionParameter.Description = baseEventFunctionParameter.Description;
            }
            functionParameters.Add(functionParameter);

            var clonedEventFunction = SerializationHelper.DeserializeTo<FunctionDefinition>(baseEventFunction);
            clonedEventFunction.FunctionParameters = functionParameters.ToArray();
            eventFunctionDefinitions.Add(clonedEventFunction);

            if (eventDefinition.ExtraParameters is not null)
            {
                functionParameters.AddRange(eventDefinition.ExtraParameters);

                var extraParameterEventFunction = SerializationHelper.DeserializeTo<FunctionDefinition>(baseEventFunction);
                extraParameterEventFunction.FunctionParameters = functionParameters.ToArray();
                eventFunctionDefinitions.Add(extraParameterEventFunction);
            }

            return eventFunctionDefinitions;
        }
    }
}
