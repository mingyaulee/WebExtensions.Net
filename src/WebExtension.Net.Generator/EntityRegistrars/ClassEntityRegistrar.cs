using System;
using System.Collections.Generic;
using System.Linq;
using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Helpers;
using WebExtension.Net.Generator.Models;
using WebExtension.Net.Generator.Models.Entities;
using WebExtension.Net.Generator.Models.Schema;
using WebExtension.Net.Generator.Repositories;

namespace WebExtension.Net.Generator.EntityRegistrars
{
    public class ClassEntityRegistrar
    {
        private readonly EntitiesContext entitiesContext;
        private readonly RegistrationOptions registrationOptions;

        public ClassEntityRegistrar(EntitiesContext entitiesContext, RegistrationOptions registrationOptions)
        {
            this.entitiesContext = entitiesContext;
            this.registrationOptions = registrationOptions;
        }

        public ClassEntity RegisterNamespaceApi(TypeDefinition namespaceApiTypeDefinition, NamespaceEntity namespaceEntity)
        {
            if (namespaceApiTypeDefinition.Id is null)
            {
                throw new InvalidOperationException("Namespace Api should have an Id.");
            }

            var classEntity = entitiesContext.Classes.RegisterClass(ClassEntityType.ApiClass, namespaceApiTypeDefinition.Id, namespaceEntity);
            classEntity.TypeDefinition = namespaceApiTypeDefinition;
            classEntity.Description = namespaceApiTypeDefinition.Description;
            classEntity.BaseClassName = $"{registrationOptions.ApiClassBaseClassName}";
            classEntity.ImplementInterface = true;

            if (namespaceApiTypeDefinition.ObjectEvents is not null)
            {
                classEntity.Events.AddRange(namespaceApiTypeDefinition.ObjectEvents);
            }

            if (namespaceApiTypeDefinition.ObjectFunctions is not null)
            {
                AddFunctionsToClassEntity(namespaceApiTypeDefinition.ObjectFunctions, classEntity);
            }

            if (namespaceApiTypeDefinition.ObjectProperties is not null)
            {
                AddPropertiesToClassEntity(namespaceApiTypeDefinition.ObjectProperties, classEntity);
            }

            return classEntity;
        }

        public void RegisterRootApi(IEnumerable<ClassEntity> classEntities)
        {
            var namespaceEntity = new NamespaceEntity(string.Empty);
            var rootClassEntity = entitiesContext.Classes.RegisterClass(ClassEntityType.ApiRootClass, registrationOptions.RootApiClassName, namespaceEntity);
            rootClassEntity.Description = registrationOptions.RootApiClassDescription;
            rootClassEntity.ImplementInterface = true;

            var apiProperties = new List<KeyValuePair<string, PropertyDefinition>>();
            foreach (var classEntity in classEntities.OrderBy(classEntity => classEntity.FormattedName))
            {
                var description = string.Join(" ", classEntity.NamespaceEntity.NamespaceDefinitions
                    .Select(namespaceDefinition => namespaceDefinition.Description)
                    .Where(namespaceDescription => !string.IsNullOrEmpty(namespaceDescription)));
                var permissions = string.Join(", ", classEntity.NamespaceEntity.NamespaceDefinitions
                    .SelectMany(namespaceDefinition => namespaceDefinition.Permissions ?? Enumerable.Empty<string>())
                    .Where(permission => !string.IsNullOrEmpty(permission)));
                if (!string.IsNullOrEmpty(permissions))
                {
                    description += $"<br>Requires manifest permission {permissions}.";
                }

                var propertyDefinition = new PropertyDefinition()
                {
                    Description = description,
                    Type = ObjectType.Object,
                    Ref = classEntity.NamespaceQualifiedId
                };
                apiProperties.Add(KeyValuePair.Create(classEntity.NamespaceEntity.Name, propertyDefinition));
            }
            AddPropertiesToClassEntity(apiProperties, rootClassEntity);
        }

        public void RegisterTypeEntity(TypeEntity typeEntity)
        {
            if (typeEntity.Definition.Type == ObjectType.Object)
            {
                RegisterTypeClassEntity(typeEntity);
            }
            else if (typeEntity.Definition.Type == ObjectType.String && typeEntity.Definition.EnumValues is not null)
            {
                RegisterEnumEntity(typeEntity);
            }
            else if (typeEntity.Definition.Type == ObjectType.String && !string.IsNullOrEmpty(typeEntity.Definition.StringFormat))
            {
                RegisterStringFormatClassEntity(typeEntity);
            }
            else if (typeEntity.Definition.Type == ObjectType.Array && typeEntity.Definition.ArrayItems is not null)
            {
                RegisterArrayClassEntity(typeEntity);
            }
            else if (typeEntity.Definition.TypeChoices is not null)
            {
                RegisterMultitypeClassEntity(typeEntity);
            }
        }

        private void RegisterTypeClassEntity(TypeEntity typeEntity)
        {
            var classEntity = entitiesContext.Classes.RegisterClass(ClassEntityType.TypeClass, typeEntity.FormattedName, typeEntity.NamespaceEntity);
            classEntity.TypeDefinition = typeEntity.Definition;
            classEntity.Description = typeEntity.Definition.Description;
            classEntity.BaseClassName = registrationOptions.ObjectTypeClassBaseClassName;

            var typeFunctions = new List<FunctionDefinition>();
            var typeProperties = new List<KeyValuePair<string, PropertyDefinition>>();

            if (typeEntity.Definition.ObjectFunctions is not null)
            {
                typeFunctions.AddRange(typeEntity.Definition.ObjectFunctions);
            }

            if (typeEntity.Definition.ObjectProperties is not null)
            {
                typeProperties.AddRange(typeEntity.Definition.ObjectProperties);
            }

            foreach (var typeExtension in typeEntity.Extensions)
            {
                if (typeExtension.ObjectFunctions is not null)
                {
                    typeFunctions.AddRange(typeExtension.ObjectFunctions);
                }

                if (typeExtension.ObjectProperties is not null)
                {
                    typeProperties.AddRange(typeExtension.ObjectProperties);
                }
            }

            AddFunctionsToClassEntity(typeFunctions, classEntity);
            AddPropertiesToClassEntity(typeProperties, classEntity);
        }

        private void RegisterEnumEntity(TypeEntity typeEntity)
        {
            var enumEntity = entitiesContext.Enums.RegisterEnum(typeEntity.FormattedName, typeEntity.NamespaceEntity);
            enumEntity.Description = typeEntity.Definition.Description;
            enumEntity.Deprecated = typeEntity.Definition.Deprecated;
            enumEntity.IsDeprecated = typeEntity.Definition.IsDeprecated;

            if (typeEntity.Definition.EnumValues is not null)
            {
                foreach (var enumValueDefinition in typeEntity.Definition.EnumValues)
                {
                    enumEntity.EnumValues.Add(enumValueDefinition);
                }
            }
        }

        private void RegisterStringFormatClassEntity(TypeEntity typeEntity)
        {
            var classEntity = entitiesContext.Classes.RegisterClass(ClassEntityType.StringFormatClass, typeEntity.FormattedName, typeEntity.NamespaceEntity);
            classEntity.TypeDefinition = typeEntity.Definition;
            classEntity.Description = typeEntity.Definition.Description;
            classEntity.BaseClassName = registrationOptions.StringFormatClassBaseClassName;
        }

        private void RegisterArrayClassEntity(TypeEntity typeEntity)
        {
            var classEntity = entitiesContext.Classes.RegisterClass(ClassEntityType.ArrayClass, typeEntity.FormattedName, typeEntity.NamespaceEntity);
            classEntity.TypeDefinition = typeEntity.Definition;
            classEntity.Description = typeEntity.Definition.Description;
            classEntity.BaseClassName = registrationOptions.ArrayClassBaseClassName;
        }

        private void RegisterMultitypeClassEntity(TypeEntity typeEntity)
        {
            var classEntity = entitiesContext.Classes.RegisterClass(ClassEntityType.MultitypeClass, typeEntity.FormattedName, typeEntity.NamespaceEntity);
            classEntity.TypeDefinition = typeEntity.Definition;
            classEntity.Description = typeEntity.Definition.Description;
        }

        private static void AddFunctionsToClassEntity(IEnumerable<FunctionDefinition> functionDefinitions, ClassEntity classEntity)
        {
            functionDefinitions = functionDefinitions.OrderBy(function => function.Name);
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
                ProcessTypeReferenceRelativeNamespace(function, classEntity);
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

        private static void AddPropertiesToClassEntity(IEnumerable<KeyValuePair<string, PropertyDefinition>> propertyDefinitionPairs, ClassEntity classEntity)
        {
            propertyDefinitionPairs = propertyDefinitionPairs.OrderBy(propertyDefinitionPair => propertyDefinitionPair.Key);
            foreach (var propertyDefinitionPair in propertyDefinitionPairs)
            {
                if (propertyDefinitionPair.Value.IsUnsupported)
                {
                    continue;
                }

                ProcessTypeReferenceRelativeNamespace(propertyDefinitionPair.Value, classEntity);
                classEntity.Properties.Add(propertyDefinitionPair);
            }
        }

        private static void ProcessTypeReferencesRelativeNamespace(IEnumerable<TypeReference?>? typeReferences, ClassEntity classEntity)
        {
            if (typeReferences is null)
            {
                return;
            }

            foreach (var typeReference in typeReferences)
            {
                ProcessTypeReferenceRelativeNamespace(typeReference, classEntity);
            }
        }

        private static void ProcessTypeReferenceRelativeNamespace(TypeReference? typeReference, ClassEntity classEntity)
        {
            if (typeReference is null)
            {
                return;
            }

            if (typeReference.Ref is not null && typeReference.Ref.Contains('.'))
            {
                var namespaceSeparatorIndex = typeReference.Ref.LastIndexOf('.');
                classEntity.UsingRelativeNamespaces.Add(typeReference.Ref[..namespaceSeparatorIndex].ToCapitalCase());
            }

            ProcessTypeReferenceRelativeNamespace(typeReference.ArrayItems, classEntity);
            ProcessTypeReferencesRelativeNamespace(typeReference.FunctionParameters, classEntity);
            ProcessTypeReferenceRelativeNamespace(typeReference.FunctionReturns, classEntity);
            ProcessTypeReferencesRelativeNamespace(typeReference.ObjectFunctions, classEntity);
            ProcessTypeReferencesRelativeNamespace(typeReference.ObjectProperties?.Select(property => property.Value), classEntity);
            ProcessTypeReferencesRelativeNamespace(typeReference.TypeChoices, classEntity);
        }
    }
}
