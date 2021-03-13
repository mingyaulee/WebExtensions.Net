using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Models;

namespace WebExtension.Net.Generator.Parsers
{
    public class ApiDefinitionParser
    {
        private readonly ILogger logger;

        public ApiDefinitionParser(ILogger logger)
        {
            this.logger = logger;
        }

        public IEnumerable<ApiDefinition> ParseApiDefinitions(JsonElement jsonApiDefinitionArray)
        {
            foreach (var jsonApiDefinition in jsonApiDefinitionArray.EnumerateArray())
            {
                var apiDefinition = new ApiDefinition(jsonApiDefinition);
                ParseCommonDefinition(apiDefinition, jsonApiDefinition, name: "namespace");

                if (jsonApiDefinition.TryGetProperty("types", out var jsonTypeDefinitionArray))
                {
                    apiDefinition.Types = ParseTypes(jsonTypeDefinitionArray).ToArray();
                }

                if (jsonApiDefinition.TryGetProperty("functions", out var jsonFunctionDefinitionArray))
                {
                    apiDefinition.Functions = ParseFunctions(jsonFunctionDefinitionArray).ToArray();
                }

                foreach (var function in apiDefinition.Functions)
                {
                    function.FunctionAccessor = $"{apiDefinition.Name}.{function.Name}";
                }

                yield return apiDefinition;
            }
        }

        private IEnumerable<TypeDefinition> ParseTypes(JsonElement jsonTypeDefinitionArray)
        {
            foreach (var jsonTypeDefinition in jsonTypeDefinitionArray.EnumerateArray())
            {
                var definition = ParseType(jsonTypeDefinition);
                if (definition is null)
                {
                    logger.LogWarning("Unknown type " + jsonTypeDefinition);
                    continue;
                }
                yield return definition;
            }
        }

        private TypeDefinition? ParseType(JsonElement jsonTypeDefinition)
        {
            var type = jsonTypeDefinition.GetStringProperty("type");
            if (string.IsNullOrEmpty(type))
            {
                if (jsonTypeDefinition.TryGetProperty("$extend", out _))
                {
                    type = "object";
                }
            }
            switch (type)
            {
                case "object":
                    var classDefinition = new ClassDefinition();
                    ParseCommonDefinition(classDefinition, jsonTypeDefinition, name: "id");
                    classDefinition.ExtendsClass = jsonTypeDefinition.GetStringProperty("$extend");

                    if (jsonTypeDefinition.TryGetProperty("properties", out var jsonPropertyDefinitionObject))
                    {
                        classDefinition.Properties = ParseProperties(jsonPropertyDefinitionObject);
                    }

                    if (jsonTypeDefinition.TryGetProperty("functions", out var jsonFunctionDefinitionArray))
                    {
                        classDefinition.Functions = ParseFunctions(jsonFunctionDefinitionArray).ToArray();
                    }

                    return classDefinition;

                case "string":
                    if (jsonTypeDefinition.TryGetProperty("enum", out var jsonEnumValues))
                    {
                        var enumDefinition = new EnumDefinition();
                        ParseCommonDefinition(enumDefinition, jsonTypeDefinition, name: "id");
                        enumDefinition.Values = ParseEnumValues(jsonEnumValues);
                        return enumDefinition;
                    }
                    var stringDefinition = new StringFormatDefinition();
                    ParseCommonDefinition(stringDefinition, jsonTypeDefinition, name: "id");
                    stringDefinition.Format = jsonTypeDefinition.GetStringProperty("format");
                    stringDefinition.Pattern = jsonTypeDefinition.GetStringProperty("pattern");
                    return stringDefinition;

                case "array":
                    var listDefinition = new ListDefinition();
                    ParseCommonDefinition(listDefinition, jsonTypeDefinition, name: "id");
                    var innerType = ParseTypeReference(jsonTypeDefinition.GetProperty("items"));
                    if (innerType is null)
                    {
                        return null;
                    }

                    listDefinition.InnerType = innerType;
                    return listDefinition;

                default:
                    var typeReference = ParseTypeReference(jsonTypeDefinition);
                    if (typeReference != null && typeReference.ChoicesType != null)
                    {
                        var multiTypeDefinition = new MultiTypeDefinition();
                        ParseCommonDefinition(multiTypeDefinition, jsonTypeDefinition, name: "id");
                        multiTypeDefinition.TypeReferences = typeReference.ChoicesType;
                        return multiTypeDefinition;
                    }
                    return null;
            }
        }

        private IEnumerable<PropertyDefinition> ParseProperties(JsonElement jsonPropertyDefinitionObject)
        {
            foreach (var jsonProperty in jsonPropertyDefinitionObject.EnumerateObject())
            {
                var jsonPropertyDefinition = jsonProperty.Value;
                var propertyDefinition = new PropertyDefinition();
                ParseCommonDefinition(propertyDefinition, jsonPropertyDefinition);
                propertyDefinition.Name = jsonProperty.Name;
                propertyDefinition.Type = ParseTypeReference(jsonPropertyDefinition);
                propertyDefinition.Optional = jsonPropertyDefinition.GetBooleanProperty("optional");
                yield return propertyDefinition;
            }
        }

        private IEnumerable<FunctionDefinition> ParseFunctions(JsonElement jsonFunctionDefinitionArray)
        {
            foreach (var jsonFunctionDefinition in jsonFunctionDefinitionArray.EnumerateArray())
            {
                var functionDefinition = new FunctionDefinition();
                ParseCommonDefinition(functionDefinition, jsonFunctionDefinition);
                foreach (var jsonParameterDefinition in jsonFunctionDefinition.GetProperty("parameters").EnumerateArray())
                {
                    var parameterName = jsonParameterDefinition.GetProperty("name").GetString();
                    if (parameterName == "callback")
                    {
                        if (jsonParameterDefinition.TryGetProperty("parameters", out var jsonCallbackParametersArray))
                        {
                            var jsonCallbackParameters = jsonCallbackParametersArray.EnumerateArray();
                            var callbackParametersCount = jsonCallbackParameters.Count();
                            if (callbackParametersCount > 1)
                            {
                                logger.LogWarning("There is more than 1 callback parameter, only the first is handled");
                            }
                            if (callbackParametersCount >= 1)
                            {
                                var jsonCallbackParameter = jsonCallbackParameters.First();
                                functionDefinition.ReturnType = ParseTypeReference(jsonCallbackParameter);
                            }
                        }
                    }
                    else
                    {
                        var parameterDefinition = new ParameterDefinition();
                        parameterDefinition.TypeReference = ParseTypeReference(jsonParameterDefinition);
                        ParseCommonDefinition(parameterDefinition, jsonParameterDefinition);
                        parameterDefinition.Optional = jsonParameterDefinition.GetBooleanProperty("optional");
                        functionDefinition.Parameters.Add(parameterDefinition);
                    }
                }

                if (jsonFunctionDefinition.TryGetProperty("returns", out var returnTypeDefinition))
                {
                    if (functionDefinition.ReturnType != null)
                    {
                        logger.LogWarning($"Callback return type for function definition {functionDefinition.Name} is overwritten by explicit return type defined");
                    }
                    functionDefinition.ReturnType = ParseTypeReference(returnTypeDefinition);
                }

                yield return functionDefinition;
            }
        }

        private IEnumerable<EnumValueDefinition> ParseEnumValues(JsonElement jsonEnumValuesArray)
        {
            foreach (var jsonEnumValue in jsonEnumValuesArray.EnumerateArray())
            {
                var enumValue = new EnumValueDefinition();
                if (jsonEnumValue.ValueKind == JsonValueKind.Object)
                {
                    ParseCommonDefinition(enumValue, jsonEnumValue);
                }
                else
                {
                    enumValue.Name = jsonEnumValue.GetString();
                }
                yield return enumValue;
            }
        }

        private void ParseCommonDefinition(ICommonDefinition commonDefinition, JsonElement jsonDefinition, string name = "name")
        {
            commonDefinition.Name = jsonDefinition.GetStringProperty(name);
            commonDefinition.Description = jsonDefinition.GetStringProperty("description");
            commonDefinition.Unsupported = jsonDefinition.GetBooleanProperty("unsupported");
            if (jsonDefinition.TryGetProperty("deprecated", out var deprecatedProperty))
            {
                if (deprecatedProperty.ValueKind == JsonValueKind.String)
                {
                    commonDefinition.DeprecatedMessage = jsonDefinition.GetStringProperty("deprecated");
                    commonDefinition.Deprecated = true;
                }
                else
                {
                    commonDefinition.Deprecated = true;
                }
            }
        }

        private TypeReference? ParseTypeReference(JsonElement type)
        {
            var typeReference = new TypeReference()
            {
                Type = type.GetStringProperty("type"),
                Reference = type.GetStringProperty("$ref")
            };
            if (typeReference.Type == "array")
            {
                if (type.TryGetProperty("items", out var itemType))
                {
                    typeReference.ArrayItemType = ParseTypeReference(itemType);
                }
            }
            if (typeReference.Type is null && typeReference.Reference is null)
            {
                if (type.TryGetProperty("choices", out var choicesArray))
                {
                    typeReference.ChoicesType = choicesArray.EnumerateArray().Select(ParseTypeReference).Cast<TypeReference>().ToArray();
                }
                else
                {
                    return null;
                }
            }
            return typeReference;
        }
    }
}
