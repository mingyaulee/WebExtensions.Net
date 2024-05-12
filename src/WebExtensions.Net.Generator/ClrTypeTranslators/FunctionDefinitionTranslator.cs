using System;
using System.Collections.Generic;
using System.Linq;
using WebExtensions.Net.Generator.Extensions;
using WebExtensions.Net.Generator.Helpers;
using WebExtensions.Net.Generator.Models.ClrTypes;
using WebExtensions.Net.Generator.Models.Entities;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.ClrTypeTranslators
{
    public class FunctionDefinitionTranslator
    {
        private readonly ClrTypeStore clrTypeStore;

        public FunctionDefinitionTranslator(ClrTypeStore clrTypeStore)
        {
            this.clrTypeStore = clrTypeStore;
        }

        public IEnumerable<ClrMethodInfo> TranslateFunctionDefinition(FunctionDefinition functionDefinition, NamespaceEntity namespaceEntity, ClrTypeInfo clrTypeInfo)
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

            var firstNonOptionalParameterIndex = Array.FindIndex(methodParameters, parameter => !parameter.IsOptional);
            if (firstNonOptionalParameterIndex > 0)
            {
                for (var i = 0; i < firstNonOptionalParameterIndex; i++)
                {
                    // The parameter from the main methodInfo is no longer optional because we are creating another overload without the optional parameter
                    methodParameters[i].IsOptional = false;
                    var methodOverloadParameters = methodParameters.Skip(i + 1).ToArray();
                    var methodOverloadInfo = (ClrMethodInfo)methodInfo.Clone();
                    methodOverloadInfo.Parameters = methodOverloadParameters;
                    yield return methodOverloadInfo;
                }
            }

            yield return methodInfo;
        }

        private static FunctionReturnDefinition? GetReturnDefinition(FunctionDefinition functionDefinition, List<ParameterDefinition> parameterDefinitions)
        {
            if (functionDefinition.FunctionReturns is not null)
            {
                return functionDefinition.FunctionReturns;
            }

            if (string.IsNullOrEmpty(functionDefinition.Async))
            {
                return null;
            }

            var callbackParameter = parameterDefinitions.Find(parameter => functionDefinition.Async.Equals(parameter.Name) && parameter.Type == ObjectType.Function);
            if (callbackParameter is null)
            {
                return null;
            }

            if (callbackParameter.FunctionParameters is null || !callbackParameter.FunctionParameters.Any())
            {
                parameterDefinitions.Remove(callbackParameter);
                return null;
            }

            if (callbackParameter.FunctionParameters.Count() > 1)
            {
                // do not handle callback with multiple parameters
                return null;
            }

            parameterDefinitions.Remove(callbackParameter);
            var callbackParameterType = callbackParameter.FunctionParameters.Single();
            return SerializationHelper.DeserializeTo<FunctionReturnDefinition>(callbackParameterType);
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
                returnClrType = returnClrType.MakeJsonElement();
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
                IsOptional = parameterDefinition.IsOptional,
                IsObsolete = parameterDefinition.IsDeprecated,
                ObsoleteMessage = parameterDefinition.Deprecated
            };
        }
    }
}
