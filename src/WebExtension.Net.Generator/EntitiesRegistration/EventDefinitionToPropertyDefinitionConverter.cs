﻿using System;
using System.Collections.Generic;
using System.Linq;
using WebExtension.Net.Generator.Helpers;
using WebExtension.Net.Generator.Models;
using WebExtension.Net.Generator.Models.Entities;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.EntitiesRegistration
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

        public PropertyDefinition Convert(string eventName, EventDefinition eventDefinition, NamespaceEntity namespaceEntity)
        {
            if (eventDefinition.FunctionParameters is not null || eventDefinition.ExtraParameters is not null)
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
                Description = eventDefinition.Description,
                IsUnsupported = eventDefinition.IsUnsupported,
                Deprecated = eventDefinition.Deprecated
            };
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