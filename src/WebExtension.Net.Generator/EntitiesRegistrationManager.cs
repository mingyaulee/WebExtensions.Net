using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Helpers;
using WebExtension.Net.Generator.Models;
using WebExtension.Net.Generator.Models.Entities;
using WebExtension.Net.Generator.Models.Schema;
using WebExtension.Net.Generator.Repositories;

namespace WebExtension.Net.Generator
{
    public class EntitiesRegistrationManager
    {
        private readonly EntitiesContext entitiesContext;
        private readonly ILogger logger;
        private readonly RegistrationOptions registrationOption;

        public EntitiesRegistrationManager(EntitiesContext entitiesContext, ILogger logger, RegistrationOptions registrationOptions)
        {
            this.entitiesContext = entitiesContext;
            this.logger = logger;
            this.registrationOption = registrationOptions;
        }

        public void RegisterEntities(IEnumerable<NamespaceDefinition> namespaceDefinitions)
        {
            RegisterNamespaceEntities(namespaceDefinitions);
            RegisterTypeEntitiesAsClassEntities();
        }

        private void RegisterNamespaceEntities(IEnumerable<NamespaceDefinition> namespaceDefinitions)
        {
            var apiClassList = new List<ClassEntity>();
            foreach (var namespaceDefinition in namespaceDefinitions)
            {
                var namespaceEntity = RegisterNamespace(namespaceDefinition);
                if (namespaceEntity is null)
                {
                    continue;
                }

                if (registrationOption.ExcludeNamespaces.Contains(namespaceEntity.Name))
                {
                    logger.LogWarning($"Skipped namespace '{namespaceEntity.Name}'.");
                    continue;
                }

                if (!registrationOption.IncludeNamespaces.Contains(namespaceEntity.Name))
                {
                    logger.LogError($"Namespace '{namespaceEntity.Name}' is not recognized.");
                    continue;
                }

                RegisterNamespaceTypesAsTypeEntities(namespaceDefinition.Types, namespaceEntity);
                var classEntity = RegisterNamespaceAsApiClassEntity(namespaceDefinition, namespaceEntity);
                if (classEntity is not null)
                {
                    apiClassList.Add(classEntity);
                }
            }
            RegisterRootApiAsApiClassEntity(apiClassList);
        }

        private NamespaceEntity? RegisterNamespace(NamespaceDefinition namespaceDefinition)
        {
            if (namespaceDefinition.Namespace is null)
            {
                logger.LogInformation($"Namespace is null for namespace definition in source '{namespaceDefinition.Source?.HttpUrl}'");
                return null;
            }
            return entitiesContext.Namespaces.RegisterNamespace(namespaceDefinition.Namespace, namespaceDefinition);
        }

        private void RegisterNamespaceTypesAsTypeEntities(IEnumerable<TypeDefinition>? typeDefinitions, NamespaceEntity namespaceEntity)
        {
            if (typeDefinitions is null)
            {
                return;
            }

            foreach (var typeDefinition in typeDefinitions)
            {
                if (!string.IsNullOrEmpty(typeDefinition.Id))
                {
                    entitiesContext.Types.RegisterType(typeDefinition.Id, typeDefinition, namespaceEntity);
                }
                else if (!string.IsNullOrEmpty(typeDefinition.Extend))
                {
                    entitiesContext.Types.RegisterTypeExtension(typeDefinition.Extend, typeDefinition, namespaceEntity);
                }
                else
                {
                    logger.LogError($"Type definition in namespace '{namespaceEntity.Name}' must have an ID or extends another type. {JsonSerializer.Serialize(typeDefinition)}");
                }
            }
        }

        private ClassEntity? RegisterNamespaceAsApiClassEntity(NamespaceDefinition namespaceDefinition, NamespaceEntity namespaceEntity)
        {
            if (namespaceDefinition.Events is null && namespaceDefinition.Functions is null && namespaceDefinition.Properties is null)
            {
                return null;
            }

            var apiClassName = namespaceEntity.FormattedName + registrationOption.ApiClassNamePostfix;
            var classEntity = entitiesContext.Classes.RegisterClass(ClassEntityType.ApiClass, apiClassName, namespaceEntity);
            classEntity.Description = namespaceDefinition.Description;
            classEntity.BaseClassName = $"{registrationOption.ApiClassBaseClassName}";
            classEntity.ImplementInterface = true;

            if (namespaceDefinition.Events is not null)
            {
                classEntity.Events.AddRange(namespaceDefinition.Events);
            }

            if (namespaceDefinition.Functions is not null)
            {
                RegisterFunctionsToClassEntity(namespaceDefinition.Functions, classEntity);
            }

            if (namespaceDefinition.Properties is not null)
            {
                foreach (var propertyDefinitionPair in namespaceDefinition.Properties)
                {
                    RegisterNamespacePropertyToClassEntity(propertyDefinitionPair.Key, propertyDefinitionPair.Value, classEntity);
                }
            }

            return classEntity;
        }

        private static void RegisterNamespacePropertyToClassEntity(string propertyName, PropertyDefinition propertyDefinition, ClassEntity classEntity)
        {
            if (!propertyDefinition.IsConstant)
            {
                // If this is not a constant property, convert it to a function
                classEntity.Functions.Add(new FunctionDefinition()
                {
                    Name = propertyName,
                    Type = ObjectType.PropertyGetterFunction,
                    Async = "true",
                    FunctionReturns = SerializationHelper.DeserializeTo<FunctionReturnDefinition>(propertyDefinition)
                });
            }
            else
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
                classEntity.Properties.Add(propertyName, clonePropertyDefinition);
            }
        }

        private static void RegisterFunctionsToClassEntity(IEnumerable<FunctionDefinition> functionDefinitions, ClassEntity classEntity)
        {
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
                        foreach (var parameterCombination in parametersCombinations)
                        {
                            var newFunctionDefinition = SerializationHelper.DeserializeTo<FunctionDefinition>(functionDefinition);
                            newFunctionDefinition.FunctionParameters = parameterCombination;
                            classEntity.Functions.Add(newFunctionDefinition);
                        }
                        continue;
                    }
                }

                classEntity.Functions.Add(functionDefinition);
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

        private void RegisterRootApiAsApiClassEntity(IEnumerable<ClassEntity> classEntities)
        {
            var namespaceEntity = new NamespaceEntity(string.Empty);
            var rootClassEntity = entitiesContext.Classes.RegisterClass(ClassEntityType.ApiRootClass, registrationOption.RootApiClassName, namespaceEntity);
            rootClassEntity.Description = registrationOption.RootApiClassDescription;
            rootClassEntity.ImplementInterface = true;
            rootClassEntity.UsingRelativeNamespaces.AddRange(classEntities.Select(classEntity => classEntity.NamespaceEntity.FormattedName));

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
                    Ref = classEntity.FormattedName
                };
                rootClassEntity.Properties.Add(classEntity.NamespaceEntity.Name, propertyDefinition);
            }
        }

        private void RegisterTypeEntitiesAsClassEntities()
        {
            var typeEntities = entitiesContext.Types.GetAllTypes();
            foreach (var typeEntity in typeEntities)
            {
                if (typeEntity.Definition.Type == ObjectType.Object)
                {
                    RegisterTypeEntityAsTypeClassEntity(typeEntity);
                }
                else if (typeEntity.Definition.Type == ObjectType.String && typeEntity.Definition.EnumValues is not null)
                {
                    RegisterTypeEntityAsEnumEntity(typeEntity);
                }
                else if (typeEntity.Definition.Type == ObjectType.String && !string.IsNullOrEmpty(typeEntity.Definition.StringFormat))
                {
                    RegisterTypeEntityAsStringFormatClassEntity(typeEntity);
                }
                else if (typeEntity.Definition.Type == ObjectType.Array && typeEntity.Definition.ArrayItems is not null)
                {
                    RegisterTypeEntityAsArrayClassEntity(typeEntity);
                }
                else if (typeEntity.Definition.TypeChoices is not null)
                {
                    RegisterTypeEntityAsMultitypeClassEntity(typeEntity);
                }
            }
        }

        private void RegisterTypeEntityAsTypeClassEntity(TypeEntity typeEntity)
        {
            var classEntity = entitiesContext.Classes.RegisterClass(ClassEntityType.TypeClass, typeEntity.FormattedName, typeEntity.NamespaceEntity);
            classEntity.TypeDefinition = typeEntity.Definition;
            classEntity.Description = typeEntity.Definition.Description;
            classEntity.BaseClassName = registrationOption.ObjectTypeClassBaseClassName;

            RegisterTypeDefinitionToClassEntity(typeEntity.Definition, classEntity);

            foreach (var typeExtension in typeEntity.Extensions)
            {
                RegisterTypeDefinitionToClassEntity(typeExtension, classEntity);
            }
        }

        private static void RegisterTypeDefinitionToClassEntity(TypeDefinition typeDefinition, ClassEntity classEntity)
        {
            if (typeDefinition.ObjectFunctions is not null)
            {
                RegisterFunctionsToClassEntity(typeDefinition.ObjectFunctions, classEntity);
            }

            if (typeDefinition.ObjectProperties is not null)
            {
                foreach (var propertyDefinition in typeDefinition.ObjectProperties)
                {
                    if (propertyDefinition.Value.IsUnsupported)
                    {
                        continue;
                    }
                    classEntity.Properties.Add(propertyDefinition);
                }
            }
        }

        private void RegisterTypeEntityAsEnumEntity(TypeEntity typeEntity)
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

        private void RegisterTypeEntityAsStringFormatClassEntity(TypeEntity typeEntity)
        {
            var classEntity = entitiesContext.Classes.RegisterClass(ClassEntityType.StringFormatClass, typeEntity.FormattedName, typeEntity.NamespaceEntity);
            classEntity.TypeDefinition = typeEntity.Definition;
            classEntity.Description = typeEntity.Definition.Description;
            classEntity.BaseClassName = registrationOption.StringFormatClassBaseClassName;
        }

        private void RegisterTypeEntityAsArrayClassEntity(TypeEntity typeEntity)
        {
            var classEntity = entitiesContext.Classes.RegisterClass(ClassEntityType.ArrayClass, typeEntity.FormattedName, typeEntity.NamespaceEntity);
            classEntity.TypeDefinition = typeEntity.Definition;
            classEntity.Description = typeEntity.Definition.Description;
            classEntity.BaseClassName = registrationOption.ArrayClassBaseClassName;
        }

        private void RegisterTypeEntityAsMultitypeClassEntity(TypeEntity typeEntity)
        {
            var classEntity = entitiesContext.Classes.RegisterClass(ClassEntityType.MultitypeClass, typeEntity.FormattedName, typeEntity.NamespaceEntity);
            classEntity.TypeDefinition = typeEntity.Definition;
            classEntity.Description = typeEntity.Definition.Description;
        }
    }
}
