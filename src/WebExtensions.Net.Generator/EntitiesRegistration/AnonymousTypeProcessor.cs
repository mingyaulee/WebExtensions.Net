using System;
using System.Collections.Generic;
using System.Linq;
using WebExtensions.Net.Generator.Extensions;
using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Models.Entities;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.EntitiesRegistration
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
            Process(new[] { className }, typeDefinition, namespaceEntity);
        }

        public void Reset()
        {
            typesToRegister.Clear();
            typeReferencesProcessed.Clear();
        }

        public void Complete()
        {
            var namespaceGroups = typesToRegister.Values
                .GroupBy(typeRegistrationInfo => typeRegistrationInfo.NamespaceEntity.FullFormattedName);
            foreach (var namespaceGroupAnonymousTypes in namespaceGroups)
            {
                ProcessNamespaceGroupAnonymousTypes(namespaceGroupAnonymousTypes);
            }
        }

        private void ProcessNamespaceGroupAnonymousTypes(IEnumerable<AnonymousTypeEntityRegistrationInfo> namespaceGroupAnonymousTypes)
        {
            ResolveDuplicateNamesInNamespaceGroup(namespaceGroupAnonymousTypes);
            var namespaceAnonymousTypes = namespaceGroupAnonymousTypes
                .OrderBy(typeRegistrationInfo => typeRegistrationInfo.NameHierarchy.Count())
                .ToList();

            foreach (var anonymousTypeRegistrationInfo in namespaceAnonymousTypes)
            {
                if (!IsObjectType(anonymousTypeRegistrationInfo.TypeReference))
                {
                    anonymousTypeRegistrationInfo.TypeReference.Type = ObjectType.Object;
                }
                anonymousTypeRegistrationInfo.TypeReference.Ref = anonymousTypeRegistrar.RegisterType(anonymousTypeRegistrationInfo);
                ClearTypeReferenceProperties(anonymousTypeRegistrationInfo.TypeReference);
            }
        }

        private static void ResolveDuplicateNamesInNamespaceGroup(IEnumerable<AnonymousTypeEntityRegistrationInfo> namespaceGroupAnonymousTypes)
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
        }

        private static void ClearTypeReferenceProperties(TypeReference typeReference)
        {
            typeReference.ArrayItems = null;
            typeReference.ArrayMaximumItems = null;
            typeReference.ArrayMinumumItems = null;
            typeReference.EnumValues = null;
            typeReference.Extend = null;
            typeReference.FunctionParameters = null;
            typeReference.FunctionReturns = null;
            typeReference.IntegerMaximum = null;
            typeReference.IntegerMinimum = null;
            typeReference.ObjectFunctions = null;
            typeReference.ObjectProperties = null;
            typeReference.StringFormat = null;
            typeReference.StringPattern = null;
            typeReference.TypeChoices = null;
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

            TryHandleSingleTypeChoice(typeReference);

            if (typeReference.Ref is null && IsObjectType(typeReference) && ShouldRegisterObjectType(typeReference))
            {
                if (typeReference.Type == ObjectType.EventTypeObject)
                {
                    nameHierarchy = SetNameSuffix(nameHierarchy, registrationOptions.EventTypeNameSuffix);
                }

                if (typesToRegister.ContainsKey(typeReference))
                {
                    ThrowIfNameHierarchyDifferent(nameHierarchy, typesToRegister[typeReference].NameHierarchy);
                    return;
                }

                typesToRegister.Add(typeReference, new AnonymousTypeEntityRegistrationInfo(nameHierarchy, typeReference, namespaceEntity));
            }

            Process(SetNameSuffix(nameHierarchy, registrationOptions.ArrayItemTypeNameSuffix), typeReference.ArrayItems, namespaceEntity);
            ProcessFunctionParameters(nameHierarchy, typeReference.FunctionParameters, namespaceEntity);
            var functionReturnTypeName = typeReference.Type == ObjectType.PropertyGetterFunction ? nameHierarchy : SetNameSuffix(nameHierarchy, registrationOptions.FunctionReturnTypeNameSuffix);
            Process(functionReturnTypeName, typeReference.FunctionReturns, namespaceEntity);
            ProcessFunctions(nameHierarchy, typeReference.ObjectFunctions, namespaceEntity);
            ProcessProperties(nameHierarchy, typeReference.ObjectProperties, namespaceEntity);
            ProcessTypeChoices(nameHierarchy, typeReference.TypeChoices, namespaceEntity);
        }

        private static bool IsObjectType(TypeReference typeReference)
        {
            return typeReference.Type == ObjectType.Object ||
                typeReference.Type == ObjectType.ApiObject||
                typeReference.Type == ObjectType.EventTypeObject ||
                typeReference.TypeChoices != null;
        }

        private static bool ShouldRegisterObjectType(TypeReference typeReference)
        {
            if (typeReference is TypeDefinition typeDefinition && !string.IsNullOrEmpty(typeDefinition.Id))
            {
                return false;
            }

            return
                typeReference.ObjectProperties?.Any(propertyDefinitionPair => !propertyDefinitionPair.Value.IsUnsupported) ??
                typeReference.ObjectFunctions?.Any(functionDefinition => !functionDefinition.IsUnsupported) ??
                typeReference.TypeChoices?.Any(typeChoice => !typeChoice.IsUnsupported) ??
                false;
        }

        private static void TryHandleSingleTypeChoice(TypeReference typeReference)
        {
            if (typeReference.TypeChoices is null)
            {
                return;
            }

            if (typeReference.TypeChoices.All(typeChoice => typeChoice.Type == ObjectType.Boolean))
            {
                typeReference.Type = ObjectType.Boolean;
                typeReference.TypeChoices = null;
                return;
            }

            if (typeReference.TypeChoices.Count() == 1)
            {
                var typeChoice = typeReference.TypeChoices.Single();
                typeReference.TypeChoices = null;
                typeReference.Type = typeChoice.Type;
                typeReference.ArrayItems = typeChoice.ArrayItems;
                typeReference.ArrayMaximumItems = typeChoice.ArrayMaximumItems;
                typeReference.ArrayMinumumItems = typeChoice.ArrayMinumumItems;
                typeReference.Deprecated ??= typeChoice.Deprecated;
                typeReference.EnumValues = typeChoice.EnumValues;
                typeReference.Extend = typeChoice.Extend;
                typeReference.FunctionParameters = typeChoice.FunctionParameters;
                typeReference.FunctionReturns = typeChoice.FunctionReturns;
                typeReference.IntegerMaximum = typeChoice.IntegerMaximum;
                typeReference.IntegerMinimum = typeChoice.IntegerMinimum;
                typeReference.IsUnsupported = typeChoice.IsUnsupported;
                typeReference.ObjectFunctions = typeChoice.ObjectFunctions;
                typeReference.ObjectProperties = typeChoice.ObjectProperties;
                typeReference.Ref = typeChoice.Ref;
                typeReference.StringFormat = typeChoice.StringFormat;
                typeReference.StringPattern = typeChoice.StringPattern;
            }
        }

        private static void ThrowIfNameHierarchyDifferent(IEnumerable<string> nameHierarchy, IEnumerable<string> registeredNameHierarchy)
        {
            var currentNamePaths = string.Join(',', nameHierarchy);
            var registeredNamePaths = string.Join(',', registeredNameHierarchy);
            if (registeredNamePaths != currentNamePaths)
            {
                throw new InvalidOperationException($"A registered type reference has more than one name hierarchy, [{registeredNamePaths}] and [{currentNamePaths}].");
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
            var functionReturnTypeName = functionDefinition.Type == ObjectType.PropertyGetterFunction ? functionName : functionName + registrationOptions.FunctionReturnTypeNameSuffix;
            Process(ConcatName(nameHierarchy, functionReturnTypeName), functionDefinition.FunctionReturns, namespaceEntity);
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

        private void ProcessTypeChoices(IEnumerable<string> nameHierarchy, IEnumerable<TypeDefinition>? typeChoices, NamespaceEntity namespaceEntity)
        {
            if (typeChoices is null)
            {
                return;
            }

            var typeChoiceIndex = 1;
            foreach (var typeChoice in typeChoices)
            {
                Process(SetNameSuffix(nameHierarchy, registrationOptions.TypeChoicesTypeNameSuffix + typeChoiceIndex++), typeChoice, namespaceEntity);
            }
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
