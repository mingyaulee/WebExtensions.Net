using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Helpers;
using WebExtension.Net.Generator.Models.ClrTypes;
using WebExtension.Net.Generator.Models.Entities;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.ClrTypeTranslators
{
    public class FunctionDefinitionTranslator
    {
        private readonly ClrTypeStore clrTypeStore;

        public FunctionDefinitionTranslator(ClrTypeStore clrTypeStore)
        {
            this.clrTypeStore = clrTypeStore;
        }

        public ClrMethodInfo TranslateFunctionDefinition(FunctionDefinition functionDefinition, NamespaceEntity namespaceEntity, ClrTypeInfo clrTypeInfo)
        {
            if (functionDefinition.Name is null)
            {
                throw new InvalidOperationException("Function definition should have a name.");
            }

            var parameterDefinitions = functionDefinition.FunctionParameters?.ToList() ?? new List<ParameterDefinition>();
            var returnDefinition = GetReturnDefinition(functionDefinition, parameterDefinitions);

            var methodParameters = parameterDefinitions.Select(parameterDefinition =>
            {
                var clrParameterInfo = TranslateParameterDefinition(parameterDefinition, namespaceEntity);
                clrTypeInfo.AddRequiredNamespaces(clrParameterInfo.ParameterType.ReferenceNamespaces);
                return clrParameterInfo;
            }).ToArray();
            var methodReturnType = GetReturnType(returnDefinition, namespaceEntity);
            if (methodReturnType is not null)
            {
                clrTypeInfo.AddRequiredNamespaces(methodReturnType.ReferenceNamespaces);
            }

            var methodInfo = new ClrMethodInfo()
            {
                Name = functionDefinition.Name,
                PublicName = functionDefinition.Name.ToCapitalCase(),
                Description = functionDefinition.Description,
                DeclaringType = clrTypeInfo,
                Parameters = methodParameters,
                Return = new ClrMethodReturnInfo()
                {
                    Description = returnDefinition?.Description,
                    HasReturnType = methodReturnType is not null,
                    ReturnType = methodReturnType
                },
                IsObsolete = functionDefinition.IsDeprecated,
                ObsoleteMessage = functionDefinition.Deprecated,
                Metadata = new Dictionary<string, object>()
            };

            if (functionDefinition.Type == ObjectType.PropertyGetterFunction)
            {
                methodInfo.Metadata.Add(Constants.MethodMetadata.IsPropertyGetterMethod, true);
            }

            return methodInfo;
        }

        private static FunctionReturnDefinition? GetReturnDefinition(FunctionDefinition functionDefinition, List<ParameterDefinition> parameterDefinitions)
        {
            var returnDefinition = functionDefinition.FunctionReturns;
            if (returnDefinition is null && !string.IsNullOrEmpty(functionDefinition.Async))
            {
                var callbackParameter = parameterDefinitions.Find(parameter => functionDefinition.Async.Equals(parameter.Name) && parameter.Type == ObjectType.Function);
                if (callbackParameter is not null)
                {
                    if (callbackParameter.FunctionParameters is null || !callbackParameter.FunctionParameters.Any())
                    {
                        parameterDefinitions.Remove(callbackParameter);
                    }
                    else if (callbackParameter.FunctionParameters.Count() == 1)
                    {
                        parameterDefinitions.Remove(callbackParameter);
                        var callbackParameterType = callbackParameter.FunctionParameters.Single();
                        returnDefinition = SerializationHelper.DeserializeTo<FunctionReturnDefinition>(callbackParameterType);
                    }
                    else
                    {
                        // multiple callback result is not supported yet
                    }
                }
            }
            return returnDefinition;
        }

        private ClrTypeInfo? GetReturnType(FunctionReturnDefinition? returnDefinition, NamespaceEntity namespaceEntity)
        {
            if (returnDefinition is null)
            {
                return null;
            }

            var returnClrType = clrTypeStore.GetClrType(returnDefinition, namespaceEntity);
            if (returnClrType.FullName == typeof(object).FullName)
            {
                var type = typeof(JsonElement);
                returnClrType = (ClrTypeInfo)returnClrType.Clone();
                returnClrType.CSharpName = type.Name;
#pragma warning disable CS8601, CS8604 // Type should not have these properties as null
                returnClrType.Id = type.FullName;
                returnClrType.Namespace = type.Namespace;
                returnClrType.ReferenceNamespaces.Add(type.Namespace);
#pragma warning restore CS8601, CS8604
            }
            return returnClrType;
        }

        private ClrParameterInfo TranslateParameterDefinition(ParameterDefinition parameterDefinition, NamespaceEntity namespaceEntity)
        {
            if (parameterDefinition.Name is null)
            {
                throw new InvalidOperationException("Parameter definition should have a name.");
            }

            var parameterType = clrTypeStore.GetClrType(parameterDefinition, namespaceEntity);
            if (parameterDefinition.IsOptional && !parameterType.IsNullable)
            {
                parameterType = parameterType.MakeNullable();
            }

            return new ClrParameterInfo()
            {
                Name = parameterDefinition.Name,
                Description = parameterDefinition.Description,
                ParameterType = parameterType,
                IsObsolete = parameterDefinition.IsDeprecated,
                ObsoleteMessage = parameterDefinition.Deprecated
            };
        }
    }
}
