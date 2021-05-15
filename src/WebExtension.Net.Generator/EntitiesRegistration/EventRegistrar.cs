using System;
using System.Collections.Generic;
using System.Linq;
using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Helpers;
using WebExtension.Net.Generator.Models.Entities;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.EntitiesRegistration
{
    public class EventRegistrar
    {
        private readonly TypeEntityRegistrar typeEntityRegistrar;

        public EventRegistrar(TypeEntityRegistrar typeEntityRegistrar)
        {
            this.typeEntityRegistrar = typeEntityRegistrar;
        }

        public PropertyDefinition ConvertEventDefinitionToPropertyDefinition(string eventName, EventDefinition eventDefinition, NamespaceEntity namespaceEntity)
        {
            var eventTypeName = "events.Event";
            if (eventDefinition.FunctionParameters is not null || eventDefinition.ExtraParameters is not null)
            {
                // Register event as a new class
                eventTypeName = $"{eventName.ToCapitalCase()}Event";
                RegisterEventTypeEntity(eventTypeName, eventDefinition, namespaceEntity);
            }

            return new PropertyDefinition()
            {
                Ref = eventTypeName,
                Description = eventDefinition.Description,
                IsUnsupported = eventDefinition.IsUnsupported,
                Deprecated = eventDefinition.Deprecated
            };
        }

        private void RegisterEventTypeEntity(string className, EventDefinition eventDefinition, NamespaceEntity namespaceEntity)
        {
            var functionDefinitions = new List<FunctionDefinition>();
            var eventTypeEntity = typeEntityRegistrar.GetTypeEntity("events.Event", namespaceEntity);

            functionDefinitions.AddRange(GetEventFunctionDefinitions(eventDefinition, eventTypeEntity, "addListener"));
            functionDefinitions.AddRange(GetEventFunctionDefinitions(eventDefinition, eventTypeEntity, "hasListener"));
            functionDefinitions.AddRange(GetEventFunctionDefinitions(eventDefinition, eventTypeEntity, "removeListener"));

            var typeDefinition = new TypeDefinition()
            {
                Id = className,
                Description = eventDefinition.Description,
                Type = ObjectType.EventTypeObject,
                ObjectFunctions = functionDefinitions
            };

            typeEntityRegistrar.RegisterNamespaceType(typeDefinition, namespaceEntity);
        }

        private static IEnumerable<FunctionDefinition> GetEventFunctionDefinitions(EventDefinition eventDefinition, TypeEntity baseEventTypeEntity, string functionName)
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
            if (functionName != "addListener")
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
