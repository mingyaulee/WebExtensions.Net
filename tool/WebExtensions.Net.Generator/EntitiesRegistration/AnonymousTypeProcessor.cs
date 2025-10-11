using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using WebExtensions.Net.Generator.Extensions;
using WebExtensions.Net.Generator.Helpers;
using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Models.Entities;
using WebExtensions.Net.Generator.Models.Schema;

namespace WebExtensions.Net.Generator.EntitiesRegistration;

public class AnonymousTypeProcessor(RegistrarFactory registrarFactory, RegistrationOptions registrationOptions)
{
    private readonly RegistrarFactory registrarFactory = registrarFactory;
    private readonly RegistrationOptions registrationOptions = registrationOptions;
    private readonly Dictionary<TypeReference, AnonymousTypeEntityRegistrationInfo> typesToRegister = [];
    private readonly HashSet<string> typeReferencesProcessed = [];

    public void ProcessTypeDefinition(string className, TypeDefinition typeDefinition, NamespaceEntity namespaceEntity)
        => Process([className], typeDefinition, namespaceEntity);

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
            anonymousTypeRegistrationInfo.TypeReference.Ref = registrarFactory.AnonymousTypeRegistrar.RegisterType(anonymousTypeRegistrationInfo);
            ClearTypeReferenceProperties(anonymousTypeRegistrationInfo.TypeReference);

            foreach (var otherTypeReference in anonymousTypeRegistrationInfo.OtherReferences)
            {
                otherTypeReference.Type = anonymousTypeRegistrationInfo.TypeReference.Type;
                otherTypeReference.Ref = anonymousTypeRegistrationInfo.TypeReference.Ref;
                ClearTypeReferenceProperties(otherTypeReference);
            }
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
            if (duplicateNameTypes.Length == 0)
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
            var typeEntity = registrarFactory.TypeEntityRegistrar.GetTypeEntity(typeReference.Ref, namespaceEntity);
            if (typeReferencesProcessed.Add(typeEntity.NamespaceQualifiedId))
            {
                ProcessTypeDefinitionWithExtensions(typeEntity.FormattedName, typeEntity.Definition, typeEntity.Extensions, typeEntity.NamespaceEntity);
            }
            return;
        }

        TryHandleSingleTypeChoice(typeReference);
        TryHandleCallbackParametersCombination(nameHierarchy, typeReference);

        if (typeReference.Ref is null && IsObjectType(typeReference) && ShouldRegisterObjectType(typeReference))
        {
            if (typeReference.Type == ObjectType.EventTypeObject)
            {
                nameHierarchy = SetNameSuffix(nameHierarchy, registrationOptions.EventTypeNameSuffix);
            }

            if (typesToRegister.TryGetValue(typeReference, out var typeEntityRegistrationInfo))
            {
                ThrowIfNameHierarchyDifferent(nameHierarchy, typeEntityRegistrationInfo.NameHierarchy);
                return;
            }

            typesToRegister.Add(typeReference, new AnonymousTypeEntityRegistrationInfo(nameHierarchy, typeReference, namespaceEntity));
        }

        ProcessArrayItem(nameHierarchy, typeReference.ArrayItems, namespaceEntity);
        ProcessFunctionParameters(nameHierarchy, typeReference.FunctionParameters, namespaceEntity);
        Process(SetNameSuffix(nameHierarchy, registrationOptions.FunctionReturnTypeNameSuffix), typeReference.FunctionReturns, namespaceEntity);
        ProcessFunctions(nameHierarchy, typeReference.ObjectFunctions, namespaceEntity, typeReference.Type);
        ProcessProperties(nameHierarchy, typeReference.ObjectProperties, namespaceEntity);
        if (ShouldProcessTypeChoices(typeReference))
        {
            ProcessTypeChoices(nameHierarchy, typeReference.TypeChoices, namespaceEntity);
        }
    }

    private static bool IsObjectType(TypeReference typeReference)
        => typeReference.Type == ObjectType.Object ||
            typeReference.Type == ObjectType.ApiObject ||
            typeReference.Type == ObjectType.EventTypeObject ||
            typeReference.Type == ObjectType.CombinedCallbackParameterObject ||
            typeReference.Type == ObjectType.String ||
            typeReference.TypeChoices != null;

    private static bool ShouldRegisterObjectType(TypeReference typeReference)
    {
        if (typeReference is TypeDefinition typeDefinition && !string.IsNullOrEmpty(typeDefinition.Id))
        {
            return false;
        }

        return typeReference.Type == ObjectType.String
            ? typeReference.EnumValues?.Any() ??
                false
            : typeReference.ObjectProperties?.Any(propertyDefinitionPair => !propertyDefinitionPair.Value.IsUnsupported) ??
            typeReference.ObjectFunctions?.Any(functionDefinition => !functionDefinition.IsUnsupported) ??
            typeReference.TypeChoices?.Any(typeChoice => !typeChoice.IsUnsupported) ??
            false;
    }

    private static bool ShouldProcessTypeChoices(TypeReference typeReference)
        => typeReference.TypeChoices is not null &&
!
            // When all type choices are enum, it will be handled by EnumClassEntityRegistrar
            typeReference.TypeChoices.All(IsEnumString);

    private static bool IsEnumString(TypeDefinition typeDefinition)
        => typeDefinition.Type == ObjectType.String && typeDefinition.EnumValues is not null;

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

    private void TryHandleCallbackParametersCombination(IEnumerable<string> nameHierarchy, TypeReference typeReference)
    {
        if (typeReference.FunctionParameters is null || registrationOptions.CombineCallbackParameter is null)
        {
            return;
        }

        var namePath = string.Join('.', nameHierarchy);
        if (registrationOptions.CombineCallbackParameter.TryGetValue(namePath, out var name))
        {
            var parameters = typeReference.FunctionParameters;
            typeReference.FunctionParameters =
            [
                new ParameterDefinition()
                {
                    Name = name,
                    Type = ObjectType.CombinedCallbackParameterObject,
                    ObjectProperties = parameters.ToDictionary(
                        parameter => parameter.Name ?? throw new InvalidOperationException("Function parameter should have a name."),
                        SerializationHelper.DeserializeTo<PropertyDefinition>),
                    Deprecated = parameters.All(parameter => parameter.IsDeprecated) ? "True" : null
                }
            ];
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

    private void ProcessArrayItem(IEnumerable<string> nameHierarchy, TypeReference? arrayItems, NamespaceEntity namespaceEntity)
    {
        if (arrayItems is null)
        {
            return;
        }

        var nameHierarchyList = nameHierarchy.ToList();
        if (nameHierarchyList.Count > 0 && TryGetSingularName(nameHierarchyList[^1], out var singularName))
        {
            nameHierarchyList[^1] = singularName;
            Process(nameHierarchyList, arrayItems, namespaceEntity);
        }
        else
        {
            Process(SetNameSuffix(nameHierarchy, registrationOptions.ArrayItemTypeNameSuffix), arrayItems, namespaceEntity);
        }
    }

    private void ProcessFunctions(IEnumerable<string> nameHierarchy, IEnumerable<FunctionDefinition>? functionDefinitions, NamespaceEntity namespaceEntity, ObjectType objectType)
    {
        if (functionDefinitions is null)
        {
            return;
        }

        if (objectType == ObjectType.EventTypeObject)
        {
            var addListenerFunctionDefinitions = new List<FunctionDefinition>();
            foreach (var functionDefinition in functionDefinitions)
            {
                ProcessEventFunction(nameHierarchy, functionDefinition, namespaceEntity, addListenerFunctionDefinitions);
            }
        }
        else
        {
            foreach (var functionDefinition in functionDefinitions)
            {
                ProcessFunction(nameHierarchy, functionDefinition, namespaceEntity, true);
            }
        }
    }

    private void ProcessFunction(IEnumerable<string> nameHierarchy, FunctionDefinition functionDefinition, NamespaceEntity namespaceEntity, bool addFunctionNameToHierarchy)
    {
        if (functionDefinition.Name is null)
        {
            throw new InvalidOperationException("Function definition should have a name.");
        }

        if (addFunctionNameToHierarchy)
        {
            var functionName = functionDefinition.Name.ToCapitalCase();
            ProcessFunctionParameters(ConcatName(nameHierarchy, functionName), functionDefinition.FunctionParameters, namespaceEntity);
            Process(ConcatName(nameHierarchy, functionName + registrationOptions.FunctionReturnTypeNameSuffix), functionDefinition.FunctionReturns, namespaceEntity);
        }
        else
        {
            ProcessFunctionParameters(nameHierarchy, functionDefinition.FunctionParameters, namespaceEntity);
            Process(ConcatName(nameHierarchy, registrationOptions.FunctionReturnTypeNameSuffix), functionDefinition.FunctionReturns, namespaceEntity);
        }
    }

    private void ProcessEventFunction(IEnumerable<string> nameHierarchy, FunctionDefinition functionDefinition, NamespaceEntity namespaceEntity, List<FunctionDefinition> addListenerFunctionDefinitions)
    {
        if (functionDefinition.Name == "addListener")
        {
            addListenerFunctionDefinitions.Add(functionDefinition);
            ProcessFunction(nameHierarchy, functionDefinition, namespaceEntity, false);
        }
        else
        {
            var functionParametersCount = functionDefinition.FunctionParameters!.Count();
            var addListenerFunctionDefinition = addListenerFunctionDefinitions.Single(addListenerFunctionDefinition => addListenerFunctionDefinition.FunctionParameters?.Count() == functionParametersCount);
            foreach (var (functionParameter, addListenerFunctionParameter) in functionDefinition.FunctionParameters!.Zip(addListenerFunctionDefinition.FunctionParameters!))
            {
                if (typesToRegister.TryGetValue(addListenerFunctionParameter, out var registrationInfo))
                {
                    registrationInfo.OtherReferences.Add(functionParameter);
                }

                if (functionParameter.FunctionParameters is not null)
                {
                    foreach (var (nestedFunctionParameter, addListenerNestedFunctionParameter) in functionParameter.FunctionParameters!.Zip(addListenerFunctionParameter.FunctionParameters!))
                    {
                        if (typesToRegister.TryGetValue(addListenerNestedFunctionParameter, out var nestedRegistrationInfo))
                        {
                            nestedRegistrationInfo.OtherReferences.Add(nestedFunctionParameter);
                        }
                    }
                }
            }
        }
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
                if (nameHierarchy.Count() > 2)
                {
                    // in a class method's parameter the name is optional
                    continue;
                }
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
        => Process(ConcatName(nameHierarchy, propertyName.ToCapitalCase()), propertyDefinition, namespaceEntity);

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
    private void ProcessTypeDefinitionWithExtensions(string className, TypeDefinition typeDefinition, IList<TypeDefinition> extensions, NamespaceEntity namespaceEntity)
    {
        if (extensions.Count > 0)
        {
            var enumChoice = typeDefinition.TypeChoices?.FirstOrDefault(IsEnumString);
            foreach(var extension in extensions)
            {
                var enumChoiceExtension = IsEnumString(extension) ? extension : extension.TypeChoices?.FirstOrDefault(IsEnumString);
                if (enumChoiceExtension?.EnumValues?.Any() ?? false)
                {
                    if (typeDefinition.EnumValues is not null)
                    {
                        typeDefinition.EnumValues = [.. typeDefinition.EnumValues, .. enumChoiceExtension.EnumValues];
                    }
                    else if (enumChoice is not null)
                    {
                        enumChoice.EnumValues = [.. (enumChoice.EnumValues ?? []), .. enumChoiceExtension.EnumValues];
                    }
                    else
                    {
                        enumChoice = SerializationHelper.DeserializeTo<TypeDefinition>(enumChoiceExtension);
                        typeDefinition.TypeChoices = (typeDefinition.TypeChoices ?? [])
                            .Concat([enumChoice]);
                    }
                }
            }
        }

        Process([className], typeDefinition, namespaceEntity);
    }

    private static string[] SetNameSuffix(IEnumerable<string> nameHierarchy, string suffix)
    {
        var lastIndex = nameHierarchy.Count() - 1;
        return [.. nameHierarchy.Select((name, index) => index == lastIndex ? name + suffix : name)];
    }

    private static string[] ConcatName(IEnumerable<string> nameHierarchy, string name)
        => [.. nameHierarchy, name];

    private static readonly string[] IgnoreWords = ["Css", "Js"];
    private static readonly string[] SimplePlurals = ["Cookies", "Devices", "Files", "Hostnames", "Languages", "Resources", "Rules", "Schemes", "Scopes", "Stores", "Types"];
    private static bool TryGetSingularName(string name, [NotNullWhen(true)] out string? singularName)
    {
        if (Array.IndexOf(IgnoreWords, name) > -1)
        {
            singularName = null;
            return false;
        }

        if (Array.Exists(SimplePlurals, name.EndsWith))
        {
            singularName = name[..^1];
            return true;
        }

        if (name.EndsWith("ies"))
        {
            singularName = name[..^3] + "y";
            return true;
        }
        else if (name.EndsWith("es"))
        {
            singularName = name[..^2];
            return true;
        }
        else if (name.EndsWith('s'))
        {
            singularName = name[..^1];
            return true;
        }

        singularName = null;
        return false;
    }
}
