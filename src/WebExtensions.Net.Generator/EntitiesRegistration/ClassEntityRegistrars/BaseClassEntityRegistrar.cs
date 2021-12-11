using System.Collections.Generic;
using System.Linq;
using WebExtensions.Net.Generator.Extensions;
using WebExtensions.Net.Generator.Helpers;
using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Models.Entities;
using WebExtensions.Net.Generator.Models.Schema;
using WebExtensions.Net.Generator.Repositories;

namespace WebExtensions.Net.Generator.EntitiesRegistration.ClassEntityRegistrars
{
    public abstract class BaseClassEntityRegistrar
    {
        private readonly EntitiesContext entitiesContext;

        protected BaseClassEntityRegistrar(EntitiesContext entitiesContext)
        {
            this.entitiesContext = entitiesContext;
        }

        protected abstract ClassType GetClassType();
        protected virtual string? GetBaseClassName() => null;
        protected virtual bool ShouldImplementInterface() => false;
        protected virtual bool ShouldSortProperties() => true;

        public virtual ClassEntity RegisterClass(TypeEntity typeEntity)
        {
            var classEntity = RegisterClassInternal(typeEntity);
            var classFunctions = new List<FunctionDefinition>();
            var classProperties = new List<KeyValuePair<string, PropertyDefinition>>();

            AddClassFunctions(typeEntity, classFunctions);
            AddClassProperties(typeEntity, classProperties);

            classFunctions = classFunctions.OrderBy(classFunction => classFunction.Name).ToList();
            if (ShouldSortProperties())
            {
                classProperties = classProperties.OrderBy(propertyDefinitionPair => propertyDefinitionPair.Key).ToList();
            }

            AddFunctionsToClassEntity(classFunctions, classEntity);
            AddPropertiesToClassEntity(classProperties, classEntity);

            return classEntity;
        }

        protected virtual ClassEntity RegisterClassInternal(TypeEntity typeEntity)
        {
            var classEntity = entitiesContext.Classes.RegisterClass(GetClassType(), typeEntity.FormattedName, typeEntity.Definition, typeEntity.NamespaceEntity);
            classEntity.BaseClassName = GetBaseClassName();
            classEntity.ImplementInterface = ShouldImplementInterface();
            return classEntity;
        }

        protected virtual void AddClassFunctions(TypeEntity typeEntity, List<FunctionDefinition> classFunctions)
        {
            if (typeEntity.Definition.ObjectFunctions is not null)
            {
                classFunctions.AddRange(typeEntity.Definition.ObjectFunctions);
            }

            var typeExtensionFunctions = typeEntity.Extensions
                .Where(typeExtension => typeExtension.ObjectFunctions is not null)
                .SelectMany(typeExtension => typeExtension.ObjectFunctions!);
            classFunctions.AddRange(typeExtensionFunctions);
        }

        protected virtual void AddClassProperties(TypeEntity typeEntity, List<KeyValuePair<string, PropertyDefinition>> classProperties)
        {
            if (typeEntity.Definition.ObjectProperties is not null)
            {
                classProperties.AddRange(typeEntity.Definition.ObjectProperties);
            }

            var typeExtensionProperties = typeEntity.Extensions
                .Where(typeExtension => typeExtension.ObjectProperties is not null)
                .SelectMany(typeExtension => typeExtension.ObjectProperties!);
            classProperties.AddRange(typeExtensionProperties);
        }

        private static void AddPropertiesToClassEntity(IEnumerable<KeyValuePair<string, PropertyDefinition>> propertyDefinitionPairs, ClassEntity classEntity)
        {
            foreach (var propertyDefinitionPair in propertyDefinitionPairs)
            {
                if (propertyDefinitionPair.Value.IsUnsupported)
                {
                    continue;
                }

                classEntity.Properties.Add(propertyDefinitionPair);
            }
        }

        private static void AddFunctionsToClassEntity(IEnumerable<FunctionDefinition> functionDefinitions, ClassEntity classEntity)
        {
            var functions = new List<FunctionDefinition>();
            foreach (var functionDefinition in functionDefinitions)
            {
                if (functionDefinition.IsUnsupported)
                {
                    continue;
                }

                if (functionDefinition.FunctionParameters is not null)
                {
                    var parametersCombinations = GetParametersCombinations(functionDefinition.FunctionParameters.Where(functionParameter => !functionParameter.IsUnsupported));
                    if (parametersCombinations.Count() > 1)
                    {
                        functions.AddRange(GetFunctionDefinitionsFromParameterCombinations(functionDefinition, parametersCombinations));
                        continue;
                    }
                }

                functions.Add(functionDefinition);
            }

            foreach (var function in functions)
            {
                classEntity.Functions.Add(function);
            }
        }

        private static IEnumerable<IEnumerable<ParameterDefinition>> GetParametersCombinations(IEnumerable<ParameterDefinition> parameterDefinitions)
        {
            if (!parameterDefinitions.Any())
            {
                // return 1 combination of no parameters
                return new[] { Enumerable.Empty<ParameterDefinition>() };
            }
            var parameters = parameterDefinitions.Select(parameterDefinition =>
            {
                if (parameterDefinition.TypeChoices is not null)
                {
                    return parameterDefinition.TypeChoices.Select(typeChoice =>
                    {
                        var subParameterDefinition = SerializationHelper.DeserializeTo<ParameterDefinition>(typeChoice);
                        subParameterDefinition.Name = parameterDefinition.Name;
                        subParameterDefinition.Description = parameterDefinition.Description;
                        subParameterDefinition.Optional = parameterDefinition.Optional;
                        subParameterDefinition.Default = parameterDefinition.Default;
                        return subParameterDefinition;
                    });
                }
                return new[] { parameterDefinition };
            }).ToArray();
            return parameters.GetCombinations();
        }

        private static IEnumerable<FunctionDefinition> GetFunctionDefinitionsFromParameterCombinations(FunctionDefinition functionDefinition, IEnumerable<IEnumerable<ParameterDefinition>> parametersCombinations)
        {
            var functionDefinitions = new List<FunctionDefinition>();
            foreach (var parameterCombination in parametersCombinations)
            {
                var newFunctionDefinition = SerializationHelper.DeserializeTo<FunctionDefinition>(functionDefinition);
                newFunctionDefinition.FunctionParameters = parameterCombination;
                functionDefinitions.Add(newFunctionDefinition);
            }
            return functionDefinitions;
        }
    }
}
