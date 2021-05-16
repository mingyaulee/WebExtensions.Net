using System;
using System.Collections.Generic;
using System.Linq;
using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Models;
using WebExtension.Net.Generator.Models.Entities;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.EntitiesRegistration
{
    public class AnonymousTypeProcessor
    {
        private readonly AnonymousTypeRegistrar anonymousTypeRegistrar;
        private readonly TypeEntityRegistrar typeEntityRegistrar;
        private readonly RegistrationOptions registrationOptions;
        private readonly IDictionary<TypeReference, AnonymousTypeEntityRegistrationInfo> typesToRegister;
        private readonly ISet<string> typeReferencesProcessed;

        public AnonymousTypeProcessor(AnonymousTypeRegistrar anonymousTypeRegistrar, TypeEntityRegistrar typeEntityRegistrar, RegistrationOptions registrationOptions)
        {
            this.anonymousTypeRegistrar = anonymousTypeRegistrar;
            this.typeEntityRegistrar = typeEntityRegistrar;
            this.registrationOptions = registrationOptions;
            typesToRegister = new Dictionary<TypeReference, AnonymousTypeEntityRegistrationInfo>();
            typeReferencesProcessed = new HashSet<string>();
        }

        public void ProcessTypeDefinition(string className, TypeDefinition typeDefinition, NamespaceEntity namespaceEntity)
        {
            ProcessFunctions(new[] { className }, typeDefinition.ObjectFunctions, namespaceEntity);
            ProcessProperties(new[] { className }, typeDefinition.ObjectProperties, namespaceEntity);
        }

        public void Reset()
        {
            typesToRegister.Clear();
            typeReferencesProcessed.Clear();
        }

        public void Complete()
        {
            var namespaceGroups = typesToRegister.Values
                .GroupBy(typeRegistrationInfo => typeRegistrationInfo.NamespaceEntity.FormattedName);
            foreach (var namespaceGroupAnonymousTypes in namespaceGroups)
            {
                ProcessNamespaceGroupAnonymousTypes(namespaceGroupAnonymousTypes);
            }
        }

        private void ProcessNamespaceGroupAnonymousTypes(IEnumerable<AnonymousTypeEntityRegistrationInfo> namespaceGroupAnonymousTypes)
        {
            while (true)
            {
                var duplicateNameTypes = namespaceGroupAnonymousTypes.GroupBy(typeRegistrationInfo => typeRegistrationInfo.NameHierarchy.Last())
                                .Where(duplicateNameGroup => duplicateNameGroup.Count() > 1)
                                .SelectMany(duplicateNameGroup => duplicateNameGroup)
                                .ToArray();
                if (!duplicateNameTypes.Any())
                {
                    break;
                }

                foreach (var duplicateNameType in duplicateNameTypes)
                {
                    duplicateNameType.NameHierarchy = SetNameSuffix(duplicateNameType.NameHierarchy.SkipLast(1), duplicateNameType.NameHierarchy.Last());
                }
            }
            var namespaceAnonymousTypes = namespaceGroupAnonymousTypes
                .OrderBy(typeRegistrationInfo => typeRegistrationInfo.NameHierarchy.Count())
                .ToList();

            foreach (var anonymousTypeRegistrationInfo in namespaceAnonymousTypes)
            {
                // only register anonymous event type for now
                if (anonymousTypeRegistrationInfo.TypeReference.Type != ObjectType.EventTypeObject)
                {
                    continue;
                }
                anonymousTypeRegistrationInfo.TypeReference.Ref = anonymousTypeRegistrar.RegisterType(anonymousTypeRegistrationInfo);
            }
        }

        private void ProcessFunctions(IEnumerable<string> nameHierarchy, IEnumerable<FunctionDefinition>? functionDefinitions, NamespaceEntity namespaceEntity)
        {
            if (functionDefinitions is null)
            {
                return;
            }

            foreach (var functionDefinition in functionDefinitions)
            {
                ProcessFunction(nameHierarchy, functionDefinition, namespaceEntity);
            }
        }

        private void ProcessFunction(IEnumerable<string> nameHierarchy, FunctionDefinition functionDefinition, NamespaceEntity namespaceEntity)
        {
            if (functionDefinition.Name is null)
            {
                throw new InvalidOperationException("Function definition should have a name.");
            }

            var functionName = functionDefinition.Name.ToCapitalCase();
            ProcessFunctionParameters(ConcatName(nameHierarchy, functionName), functionDefinition.FunctionParameters, namespaceEntity);
            Process(ConcatName(nameHierarchy, functionName + "ReturnType"), functionDefinition.FunctionReturns, namespaceEntity);
        }

        private void ProcessFunctionParameters(IEnumerable<string> nameHierarchy, IEnumerable<ParameterDefinition>? parameterDefinitions, NamespaceEntity namespaceEntity)
        {
            if (parameterDefinitions is null)
            {
                return;
            }

            foreach (var parameterDefinition in parameterDefinitions)
            {
                if (parameterDefinition.Name is null)
                {
                    throw new InvalidOperationException("Function parameter should have a name.");
                }

                var parameterName = parameterDefinition.Name.ToCapitalCase();
                Process(ConcatName(nameHierarchy, parameterName), parameterDefinition, namespaceEntity);
            }
        }

        private void ProcessProperties(IEnumerable<string> nameHierarchy, IDictionary<string, PropertyDefinition>? propertyDefinitionPairs, NamespaceEntity namespaceEntity)
        {
            if (propertyDefinitionPairs is null)
            {
                return;
            }

            foreach (var propertyDefinitionPair in propertyDefinitionPairs)
            {
                ProcessProperty(nameHierarchy, propertyDefinitionPair.Key, propertyDefinitionPair.Value, namespaceEntity);
            }
        }

        private void ProcessProperty(IEnumerable<string> nameHierarchy, string propertyName, PropertyDefinition propertyDefinition, NamespaceEntity namespaceEntity)
        {
            Process(ConcatName(nameHierarchy, propertyName.ToCapitalCase()), propertyDefinition, namespaceEntity);
        }

        private void Process(IEnumerable<string> nameHierarchy, TypeReference? typeReference, NamespaceEntity namespaceEntity)
        {
            if (typeReference is null || typeReference.IsUnsupported)
            {
                return;
            }

            if (typeReference.Ref is not null)
            {
                var typeEntity = typeEntityRegistrar.GetTypeEntity(typeReference.Ref, namespaceEntity);
                if (typeReferencesProcessed.Add(typeEntity.NamespaceQualifiedId))
                {
                    ProcessTypeDefinition(typeEntity.FormattedName, typeEntity.Definition, typeEntity.NamespaceEntity);
                }
                return;
            }

            if (typeReference.Ref is null && IsObjectType(typeReference) && ShouldRegisterObjectType(typeReference))
            {
                if (typeReference.Type == ObjectType.EventTypeObject)
                {
                    nameHierarchy = SetNameSuffix(nameHierarchy, registrationOptions.EventTypeNameSuffix);
                }

                if (typesToRegister.ContainsKey(typeReference))
                {
                    var currentNamePaths = string.Join(',', nameHierarchy);
                    var registeredNamePaths = string.Join(',', typesToRegister[typeReference].NameHierarchy);
                    if (registeredNamePaths != currentNamePaths)
                    {
                        throw new InvalidOperationException($"A registered type reference has more than one name hierarchy, [{registeredNamePaths}] and [{currentNamePaths}].");
                    }
                    return;
                }

                typesToRegister.Add(typeReference, new AnonymousTypeEntityRegistrationInfo(nameHierarchy, typeReference, namespaceEntity));
            }

            Process(SetNameSuffix(nameHierarchy, "ArrayItem"), typeReference.ArrayItems, namespaceEntity);
            ProcessFunctionParameters(nameHierarchy, typeReference.FunctionParameters, namespaceEntity);
            Process(SetNameSuffix(nameHierarchy, "ReturnType"), typeReference.FunctionReturns, namespaceEntity);
            ProcessFunctions(nameHierarchy, typeReference.ObjectFunctions, namespaceEntity);
            ProcessProperties(nameHierarchy, typeReference.ObjectProperties, namespaceEntity);
            if (typeReference.TypeChoices is not null)
            {
                foreach (var typeChoice in typeReference.TypeChoices)
                {
                    Process(SetNameSuffix(nameHierarchy, "Type"), typeChoice, namespaceEntity);
                }
            }
        }

        private static bool IsObjectType(TypeReference typeReference)
        {
            return typeReference.Type == ObjectType.Object || typeReference.Type == ObjectType.EventTypeObject;
        }

        private static bool ShouldRegisterObjectType(TypeReference typeReference)
        {
            return typeReference.ObjectProperties?.Any() ?? typeReference.ObjectFunctions?.Any() ?? false;
        }

        private static IEnumerable<string> SetNameSuffix(IEnumerable<string> nameHierarchy, string suffix)
        {
            var lastIndex = nameHierarchy.Count() - 1;
            return nameHierarchy.Select((name, index) => index == lastIndex ? name + suffix : name).ToArray();
        }

        private static IEnumerable<string> ConcatName(IEnumerable<string> nameHierarchy, string name)
        {
            return nameHierarchy.Concat(new[] { name }).ToArray();
        }
    }
}
