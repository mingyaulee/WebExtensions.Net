using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Models;

namespace WebExtension.Net.Generator.Translators
{
    public class ApiDefinitionTranslator
    {
        private readonly ILogger logger;

        public ApiDefinitionTranslator(ILogger logger)
        {
            this.logger = logger;
        }

        public string TranslateApiDefinitionRoot(ApiDefinitionRoot apiDefinitionRoot, IEnumerable<ApiDefinition> apiDefinitions)
        {
            var content = new StringBuilder();
            var usingNamespaces = apiDefinitions.Select(apiDefinition => $"using {apiDefinition.GetNamespace()};");
            var apiDefinitionNamePostfix = apiDefinitionRoot.DefinitionClassNamePostfix;
            var apiProperties = apiDefinitions.SelectMany(apiDefinition =>
            {
                return new[]
                {
                    $"",
                    $"private {apiDefinition.GetName()}{apiDefinitionNamePostfix} _{apiDefinition.Name};",
                    $"/// <inheritdoc />",
                    $"public I{apiDefinition.GetName()}{apiDefinitionNamePostfix} {apiDefinition.GetName()}",
                    $"{{",
                    $"    get",
                    $"    {{",
                    $"        if (_{apiDefinition.Name} is null)",
                    $"        {{",
                    $"            _{apiDefinition.Name} = new {apiDefinition.GetName()}{apiDefinitionNamePostfix}(webExtensionJSRuntime);",
                    $"        }}",
                    $"        return _{apiDefinition.Name};",
                    $"    }}",
                    $"}}"
                };
            });
            content.AppendLine($"{string.Join(Environment.NewLine, usingNamespaces)}");
            content.AppendLine($"");
            content.AppendLine($"namespace {apiDefinitionRoot.RootNamespace}");
            content.AppendLine($"{{");
            content.AppendLine($"    /// <inheritdoc />");
            content.AppendLine($"    public class {apiDefinitionRoot.Name} : I{apiDefinitionRoot.Name}");
            content.AppendLine($"    {{");
            content.AppendLine($"        private readonly WebExtensionJSRuntime webExtensionJSRuntime;");
            content.AppendLine($"        /// <summary>Creates a new instance of {apiDefinitionRoot.Name}.</summary>");
            content.AppendLine($"        public {apiDefinitionRoot.Name}(WebExtensionJSRuntime webExtensionJSRuntime)");
            content.AppendLine($"        {{");
            content.AppendLine($"            this.webExtensionJSRuntime = webExtensionJSRuntime;");
            content.AppendLine($"        }}");
            content.AppendLine($"");
            content.AppendLine($"        {string.Join($"{Environment.NewLine}        ", apiProperties)}");
            content.AppendLine($"    }}");
            content.AppendLine($"}}");

            return content.ToString();
        }

        public string TranslateApiDefinitionRootInterface(ApiDefinitionRoot apiDefinitionRoot, IEnumerable<ApiDefinition> apiDefinitions)
        {
            var content = new StringBuilder();
            var usingNamespaces = apiDefinitions.Select(apiDefinition => $"using {apiDefinition.GetNamespace()};");
            var apiProperties = apiDefinitions.SelectMany(apiDefinition => TranslateApiDefinitionRootProperty(apiDefinition, apiDefinitionRoot.DefinitionClassNamePostfix));
            content.AppendLine($"{string.Join(Environment.NewLine, usingNamespaces)}");
            content.AppendLine($"");
            content.AppendLine($"namespace {apiDefinitionRoot.RootNamespace}");
            content.AppendLine($"{{");
            content.AppendLine($"    /// <summary>{apiDefinitionRoot.Description}</summary>");
            content.AppendLine($"    public interface I{apiDefinitionRoot.Name}");
            content.AppendLine($"    {{");
            content.AppendLine($"        {string.Join($"{Environment.NewLine}        ", apiProperties)}");
            content.AppendLine($"    }}");
            content.AppendLine($"}}");

            return content.ToString();
        }

        private IEnumerable<string> TranslateApiDefinitionRootProperty(ApiDefinition apiDefinition, string definitionPostfix)
        {
            yield return $"/// <summary>";
            foreach (var description in apiDefinition.GetDescription())
            {
                yield return $"/// {description}";
            }
            if (apiDefinition.Permissions.Any())
            {
                yield return $"/// Requires manifest permission {string.Join(", ", apiDefinition.Permissions)}.";
            }
            yield return $"/// </summary>";
            yield return $"I{apiDefinition.GetName()}{definitionPostfix} {apiDefinition.GetName()} {{ get; }}";
        }

        public string TranslateApiDefinition(ApiDefinition apiDefinition, string className, string baseClassName)
        {
            logger.LogInformation($"    API Class {className}");
            var content = new StringBuilder();
            var constantProperties = apiDefinition.Properties.Where(property => property.Constant).SelectMany(TranslatePropertyDefinitionForApiDefinition);
            var properties = apiDefinition.Properties.Where(property => !property.Constant).Select(propertyDefinition => new FunctionDefinition()
            {
                Name = propertyDefinition.Name,
                Deprecated = propertyDefinition.Deprecated,
                DeprecatedMessage = propertyDefinition.DeprecatedMessage,
                Description = propertyDefinition.Description,
                Parameters = new List<ParameterDefinition>(),
                ReturnType = propertyDefinition.Type,
                Unsupported = propertyDefinition.Unsupported
            }).SelectMany(TranslatePropertyGetterFunctionDefinition);
            var methods = apiDefinition.Functions.SelectMany(TranslateFunctionDefinition);
            content.AppendLine($"using System;");
            content.AppendLine($"using System.Collections.Generic;");
            content.AppendLine($"using System.Text.Json;");
            content.AppendLine($"using System.Threading.Tasks;");
            content.AppendLine($"");
            content.AppendLine($"namespace {apiDefinition.GetNamespace()}");
            content.AppendLine($"{{");
            content.AppendLine($"    /// <inheritdoc />");
            content.AppendLine($"    public class {className} : {baseClassName}, I{className}");
            content.AppendLine($"    {{");
            content.AppendLine($"        /// <summary>Creates a new instance of {className}.</summary>");
            content.AppendLine($"        /// <param name=\"webExtensionJSRuntime\">Web Extension JS Runtime</param>");
            content.AppendLine($"        public {className}(WebExtensionJSRuntime webExtensionJSRuntime) : base(webExtensionJSRuntime, \"{apiDefinition.Name}\")");
            content.AppendLine($"        {{");
            content.AppendLine($"        }}");
            content.AppendLine($"");
            content.AppendLine($"        {string.Join($"{Environment.NewLine}        ", constantProperties)}");
            content.AppendLine($"        {string.Join($"{Environment.NewLine}        ", properties)}");
            content.AppendLine($"        {string.Join($"{Environment.NewLine}        ", methods)}");
            content.AppendLine($"    }}");
            content.AppendLine($"}}");

            return content.ToString();
        }

        public string TranslateApiDefinitionInterface(ApiDefinition apiDefinition, string className)
        {
            logger.LogInformation($"    API Interface I{className}");
            var content = new StringBuilder();
            var constantProperties = apiDefinition.Properties.Where(property => property.Constant).SelectMany(TranslatePropertyDefinitionInterface);
            var properties = apiDefinition.Properties.Where(property => !property.Constant).Select(propertyDefinition => new FunctionDefinition()
            {
                Name = propertyDefinition.Name,
                Deprecated = propertyDefinition.Deprecated,
                DeprecatedMessage = propertyDefinition.DeprecatedMessage,
                Description = propertyDefinition.Description,
                Parameters = new List<ParameterDefinition>(),
                ReturnType = propertyDefinition.Type,
                Unsupported = propertyDefinition.Unsupported
            }).SelectMany(TranslatePropertyGetterFunctionDefinitionInterface);
            var methods = apiDefinition.Functions.SelectMany(TranslateFunctionDefinitionInterface);
            content.AppendLine($"using System;");
            content.AppendLine($"using System.Collections.Generic;");
            content.AppendLine($"using System.Text.Json;");
            content.AppendLine($"using System.Threading.Tasks;");
            content.AppendLine($"");
            content.AppendLine($"namespace {apiDefinition.GetNamespace()}");
            content.AppendLine($"{{");
            content.AppendLine($"    /// <summary>");
            foreach (var description in apiDefinition.GetDescription())
            {
                content.AppendLine($"    /// {description}");
            }
            content.AppendLine($"    /// </summary>");
            content.AppendLine($"    public interface I{className}");
            content.AppendLine($"    {{");
            content.AppendLine($"        {string.Join($"{Environment.NewLine}        ", constantProperties)}");
            content.AppendLine($"        {string.Join($"{Environment.NewLine}        ", properties)}");
            content.AppendLine($"        {string.Join($"{Environment.NewLine}        ", methods)}");
            content.AppendLine($"    }}");
            content.AppendLine($"}}");

            return content.ToString();
        }

        public string TranslateTypeDefinition(ApiDefinition apiDefinition, TypeDefinition typeDefinition)
        {
            var content = new StringBuilder();
            content.AppendLine($"using System;");
            content.AppendLine($"using System.Collections.Generic;");
            content.AppendLine($"using System.Text.Json;");
            content.AppendLine($"using System.Text.Json.Serialization;");
            content.AppendLine($"using System.Threading.Tasks;");
            content.AppendLine($"");
            content.AppendLine($"namespace {apiDefinition.GetNamespace()}");
            content.AppendLine($"{{");

            if (typeDefinition is ClassDefinition classDefinition)
            {
                logger.LogInformation($"    Class {classDefinition.Name}");
                content.AppendLine(string.Join($"{Environment.NewLine}", TranslateClassDefinition(classDefinition).Select(line => $"    {line}")));
            }
            else if (typeDefinition is EnumDefinition enumDefinition)
            {
                logger.LogInformation($"    Enum {enumDefinition.Name}");
                content.AppendLine(string.Join($"{Environment.NewLine}", TranslateEnumDefinition(enumDefinition).Select(line => $"    {line}")));
            }
            else if (typeDefinition is StringFormatDefinition stringFormatDefinition)
            {
                logger.LogInformation($"    StringFormat {stringFormatDefinition.Name}");
                content.AppendLine(string.Join($"{Environment.NewLine}", TranslateStringFormatDefinition(stringFormatDefinition).Select(line => $"    {line}")));
            }
            else if (typeDefinition is ListDefinition listDefinition)
            {
                logger.LogInformation($"    List {listDefinition.Name}");
                content.AppendLine(string.Join($"{Environment.NewLine}", TranslateListDefinition(listDefinition).Select(line => $"    {line}")));
            }
            else if (typeDefinition is MultiTypeDefinition multiTypeDefinition)
            {
                logger.LogInformation($"    MultiType {multiTypeDefinition.Name}");
                content.AppendLine(string.Join($"{Environment.NewLine}", TranslateMultiTypeDefinition(multiTypeDefinition).Select(line => $"    {line}")));
            }
            content.AppendLine($"}}");
            content.AppendLine($"");
            return content.ToString();
        }

        private IEnumerable<string> TranslateClassDefinition(ClassDefinition classDefinition)
        {
            var properties = classDefinition.Properties.SelectMany(TranslatePropertyDefinition);
            var methods = classDefinition.Functions.SelectMany(TranslateFunctionDefinition);
            if (properties.Any())
            {
                logger.LogInformation($"        Class properties");
            }
            if (methods.Any())
            {
                logger.LogInformation($"        Class methods");
            }
            yield return $"// Class Definition";
            yield return $"/// <summary>";
            foreach (var description in classDefinition.GetDescription())
            {
                yield return $"/// {description}";
            }
            yield return $"/// </summary>";
            if (classDefinition.Deprecated)
            {
                yield return $"[Obsolete(\"{classDefinition.DeprecatedMessage}\")]";
            }
            yield return $"public class {classDefinition.GetName()} : BaseObject";
            yield return $"{{";
            foreach (var propertyLine in properties)
            {
                yield return $"    {propertyLine}";
            }
            foreach (var methodLine in methods)
            {
                yield return $"    {methodLine}";
            }
            yield return $"}}";
        }

        private IEnumerable<string> TranslateEnumDefinition(EnumDefinition enumDefinition)
        {
            var enumValues = enumDefinition.Values.SelectMany(TranslateEnumValueDefinition);
            yield return $"// Enum Definition";
            yield return $"/// <summary>";
            foreach (var description in enumDefinition.GetDescription())
            {
                yield return $"/// {description}";
            }
            yield return $"/// </summary>";
            if (enumDefinition.Deprecated)
            {
                yield return $"[Obsolete(\"{enumDefinition.DeprecatedMessage}\")]";
            }
            yield return $"[JsonConverter(typeof(EnumStringConverter<{enumDefinition.GetName()}>))]";
            yield return $"public enum {enumDefinition.GetName()}";
            yield return $"{{";
            foreach (var enumValueLine in enumValues)
            {
                yield return $"    {enumValueLine}";
            }
            yield return $"}}";
        }

        private IEnumerable<string> TranslateStringFormatDefinition(StringFormatDefinition stringFormatDefinition)
        {
            yield return $"// String Format Definition";
            yield return $"/// <summary>";
            foreach (var description in stringFormatDefinition.GetDescription())
            {
                yield return $"/// {description}";
            }
            yield return $"/// </summary>";
            if (stringFormatDefinition.Deprecated)
            {
                yield return $"[Obsolete(\"{stringFormatDefinition.DeprecatedMessage}\")]";
            }
            yield return $"public class {stringFormatDefinition.GetName()} : BaseStringFormat";
            yield return $"{{";
            yield return $"    private const string pattern = \"{stringFormatDefinition.Format}\";";
            yield return $"    /// <summary>Creates a new instance of {stringFormatDefinition.GetName()}.</summary>";
            yield return $"    public {stringFormatDefinition.GetName()}(string value) : base(value, pattern)";
            yield return $"    {{";
            yield return $"    }}";
            yield return $"}}";
        }

        private IEnumerable<string> TranslateListDefinition(ListDefinition listDefinition)
        {
            if (listDefinition.InnerType is null)
            {
                throw new Exception("List definition inner type should not be null");
            }
            yield return $"// List Definition";
            yield return $"/// <summary>";
            foreach (var description in listDefinition.GetDescription())
            {
                yield return $"/// {description}";
            }
            yield return $"/// </summary>";
            if (listDefinition.Deprecated)
            {
                yield return $"[Obsolete(\"{listDefinition.DeprecatedMessage}\")]";
            }
            yield return $"public class {listDefinition.GetName()} : List<{TranslateTypeReference(listDefinition.InnerType)}>";
            yield return $"{{";
            yield return $"}}";
        }

        private IEnumerable<string> TranslateMultiTypeDefinition(MultiTypeDefinition multiTypeDefinition)
        {
            var constructors = multiTypeDefinition.TypeReferences.Select(TranslateTypeReference).Distinct().SelectMany(typeReferenceName =>
            {
                if (typeReferenceName == "Null")
                {
                    return new[]
                    {
                        $"/// <summary>Creates a new instance of {multiTypeDefinition.GetName()}.</summary>",
                        $"public {multiTypeDefinition.GetName()}() {{ }}",
                        $""
                    };
                }
                var sanitizedVariableName = SanitizeVariableName($"value{typeReferenceName}");
                return new[]
                {
                    $"private readonly {typeReferenceName} {sanitizedVariableName};",
                    $"/// <summary>Creates a new instance of {multiTypeDefinition.GetName()}.</summary>",
                    $"public {multiTypeDefinition.GetName()}({typeReferenceName} {sanitizedVariableName})",
                    $"{{",
                    $"    this.{sanitizedVariableName} = {sanitizedVariableName};",
                    $"}}",
                    $""
                };
            });
            yield return $"// MultiType Definition";
            yield return $"/// <summary>";
            foreach (var description in multiTypeDefinition.GetDescription())
            {
                yield return $"/// {description}";
            }
            yield return $"/// </summary>";
            if (multiTypeDefinition.Deprecated)
            {
                yield return $"[Obsolete(\"{multiTypeDefinition.DeprecatedMessage}\")]";
            }
            yield return $"public class {multiTypeDefinition.GetName()}";
            yield return $"{{";
            foreach (var constructorLine in constructors)
            {
                yield return $"    {constructorLine}";
            }
            yield return $"}}";
        }

        public IEnumerable<string> TranslatePropertyDefinitionForApiDefinition(PropertyDefinition propertyDefinition)
        {
            return TranslatePropertyDefinition(propertyDefinition, false);
        }

        public IEnumerable<string> TranslatePropertyDefinition(PropertyDefinition propertyDefinition)
        {
            return TranslatePropertyDefinition(propertyDefinition, true);
        }

        public IEnumerable<string> TranslatePropertyDefinition(PropertyDefinition propertyDefinition, bool includeJsonAttribute)
        {
            if (!propertyDefinition.Unsupported)
            {
                yield return $"";
                yield return $"// Property Definition";
                var publicPropertyName = propertyDefinition.GetName();
                var privatePropertyName = $"_{propertyDefinition.Name}";
                var propertyType = TranslateTypeReference(propertyDefinition.Type, propertyDefinition.Optional);
                if (propertyDefinition.Constant)
                {
                    yield return $"private const {propertyType} {privatePropertyName} = {propertyDefinition.ConstantValue};";
                }
                else
                {
                    yield return $"private {propertyType} {privatePropertyName};";
                }
                yield return $"/// <summary>";
                foreach (var description in propertyDefinition.GetDescription())
                {
                    yield return $"/// {description}";
                }
                yield return $"/// </summary>";
                if (propertyDefinition.Deprecated)
                {
                    yield return $"[Obsolete(\"{propertyDefinition.DeprecatedMessage}\")]";
                }
                if (propertyDefinition.Constant)
                {
                    yield return $"public {propertyType} {publicPropertyName} => {privatePropertyName};";
                }
                else
                {
                    if (includeJsonAttribute)
                    {
                        yield return $"[JsonPropertyName(\"{propertyDefinition.Name}\")]";
                    }
                    yield return $"public {propertyType} {publicPropertyName}";
                    yield return $"{{";
                    yield return $"    get";
                    yield return $"    {{";
                    yield return $"        InitializeProperty(\"{propertyDefinition.Name}\", {privatePropertyName});";
                    yield return $"        return {privatePropertyName};";
                    yield return $"    }}";
                    yield return $"    set";
                    yield return $"    {{";
                    yield return $"        {privatePropertyName} = value;";
                    yield return $"    }}";
                    yield return $"}}";
                }
            }
        }

        public IEnumerable<string> TranslatePropertyDefinitionInterface(PropertyDefinition propertyDefinition)
        {
            if (!propertyDefinition.Unsupported)
            {
                yield return $"";
                yield return $"// Property Definition Interface";
                yield return $"/// <summary>";
                foreach (var description in propertyDefinition.GetDescription())
                {
                    yield return $"/// {description}";
                }
                yield return $"/// </summary>";
                if (propertyDefinition.Deprecated)
                {
                    yield return $"[Obsolete(\"{propertyDefinition.DeprecatedMessage}\")]";
                }
                if (propertyDefinition.Constant)
                {
                    yield return $"{TranslateTypeReference(propertyDefinition.Type, propertyDefinition.Optional)} {propertyDefinition.GetName()} {{ get; }}";
                }
                else
                {
                    yield return $"{TranslateTypeReference(propertyDefinition.Type, propertyDefinition.Optional)} {propertyDefinition.GetName()} {{ get; set; }}";
                }
            }
        }

        public IEnumerable<string> TranslatePropertyGetterFunctionDefinition(FunctionDefinition functionDefinition)
        {
            if (!functionDefinition.Unsupported)
            {
                var returnType = TranslateTypeReference(functionDefinition.ReturnType);
                if (returnType == null)
                {
                    throw new Exception("Property definition type should not be null.");
                }
                if (returnType == "object")
                {
                    returnType = "JsonElement";
                }
                var methodReturnType = $"ValueTask<{returnType}>";
                var clientMethodInvoke = $"GetPropertyAsync<{returnType}>";

                yield return $"";
                yield return $"// Property Getter Function Definition";
                yield return $"/// <summary>";
                foreach (var description in functionDefinition.GetDescription())
                {
                    yield return $"/// {description}";
                }
                yield return $"/// </summary>";
                if (returnType != null && functionDefinition.ReturnType != null)
                {
                    yield return $"/// <returns>{string.Join(" ", functionDefinition.ReturnType.GetDescription())}</returns>";
                }
                if (functionDefinition.Deprecated)
                {
                    yield return $"[Obsolete(\"{functionDefinition.DeprecatedMessage}\")]";
                }
                yield return $"public virtual {methodReturnType} Get{functionDefinition.GetName()}()";
                yield return $"{{";
                yield return $"    return {clientMethodInvoke}(\"{functionDefinition.Name}\");";
                yield return $"}}";
            }
        }

        public IEnumerable<string> TranslatePropertyGetterFunctionDefinitionInterface(FunctionDefinition functionDefinition)
        {
            if (!functionDefinition.Unsupported)
            {
                var returnType = TranslateTypeReference(functionDefinition.ReturnType);
                if (returnType == null)
                {
                    throw new Exception("Property definition type should not be null.");
                }
                if (returnType == "object")
                {
                    returnType = "JsonElement";
                }
                var methodReturnType = $"ValueTask<{returnType}>";

                yield return $"";
                yield return $"// Property Getter Function Definition Interface";
                yield return $"/// <summary>";
                foreach (var description in functionDefinition.GetDescription())
                {
                    yield return $"/// {description}";
                }
                yield return $"/// </summary>";
                if (returnType != null && functionDefinition.ReturnType != null)
                {
                    yield return $"/// <returns>{string.Join(" ", functionDefinition.ReturnType.GetDescription())}</returns>";
                }
                if (functionDefinition.Deprecated)
                {
                    yield return $"[Obsolete(\"{functionDefinition.DeprecatedMessage}\")]";
                }
                yield return $"{methodReturnType} Get{functionDefinition.GetName()}();";
            }
        }

        public IEnumerable<string> TranslateFunctionDefinition(FunctionDefinition functionDefinition)
        {
            if (!functionDefinition.Unsupported)
            {
                var methodReturnType = "ValueTask";
                var clientMethodInvoke = "InvokeVoidAsync";
                var returnType = TranslateTypeReference(functionDefinition.ReturnType);
                if (returnType != null)
                {
                    if (returnType == "object")
                    {
                        returnType = "JsonElement";
                    }
                    methodReturnType = $"ValueTask<{returnType}>";
                    clientMethodInvoke = $"InvokeAsync<{returnType}>";
                }

                foreach (var parameterTypeCombinations in GetParametersCombination(functionDefinition.Parameters))
                {
                    yield return $"";
                    yield return $"// Function Definition";
                    yield return $"/// <summary>";
                    foreach (var description in functionDefinition.GetDescription())
                    {
                        yield return $"/// {description}";
                    }
                    yield return $"/// </summary>";
                    foreach (var parameterTypeCombination in parameterTypeCombinations)
                    {
                        yield return $"/// <param name=\"{parameterTypeCombination.ParameterDefinition.Name}\">{string.Join(" ", parameterTypeCombination.ParameterDefinition.GetDescription())}</param>";
                    };
                    if (returnType != null && functionDefinition.ReturnType != null)
                    {
                        yield return $"/// <returns>{string.Join(" ", functionDefinition.ReturnType.GetDescription())}</returns>";
                    }
                    if (functionDefinition.Deprecated)
                    {
                        yield return $"[Obsolete(\"{functionDefinition.DeprecatedMessage}\")]";
                    }
                    yield return $"public virtual {methodReturnType} {functionDefinition.GetName()}({string.Join(", ", parameterTypeCombinations.Select(TranslateParameterDefinition))})";
                    yield return $"{{";
                    yield return $"    return {clientMethodInvoke}(\"{functionDefinition.Name}\"{string.Join(string.Empty, parameterTypeCombinations.Select(parameterTypeCombination => $", {parameterTypeCombination.ParameterDefinition.Name}"))});";
                    yield return $"}}";
                }
            }
        }

        public IEnumerable<string> TranslateFunctionDefinitionInterface(FunctionDefinition functionDefinition)
        {
            if (!functionDefinition.Unsupported)
            {
                var methodReturnType = "ValueTask";
                var returnType = TranslateTypeReference(functionDefinition.ReturnType);
                if (returnType != null)
                {
                    if (returnType == "object")
                    {
                        returnType = "JsonElement";
                    }
                    methodReturnType = $"ValueTask<{returnType}>";
                }

                foreach (var parameterTypeCombinations in GetParametersCombination(functionDefinition.Parameters))
                {
                    yield return $"";
                    yield return $"// Function Definition Interface";
                    yield return $"/// <summary>";
                    foreach (var description in functionDefinition.GetDescription())
                    {
                        yield return $"/// {description}";
                    }
                    yield return $"/// </summary>";
                    foreach (var parameterTypeCombination in parameterTypeCombinations)
                    {
                        yield return $"/// <param name=\"{parameterTypeCombination.ParameterDefinition.Name}\">{string.Join(" ", parameterTypeCombination.ParameterDefinition.GetDescription())}</param>";
                    };
                    if (returnType != null && functionDefinition.ReturnType != null)
                    {
                        yield return $"/// <returns>{string.Join(" ", functionDefinition.ReturnType.GetDescription())}</returns>";
                    }
                    if (functionDefinition.Deprecated)
                    {
                        yield return $"[Obsolete(\"{functionDefinition.DeprecatedMessage}\")]";
                    }
                    yield return $"{methodReturnType} {functionDefinition.GetName()}({string.Join(", ", parameterTypeCombinations.Select(TranslateParameterDefinition))});";
                }
            }
        }

        private string TranslateParameterDefinition((ParameterDefinition ParameterDefinition, TypeReference TypeReference) parameterTypeCombination)
        {
            if (parameterTypeCombination.ParameterDefinition.Optional)
            {
                return $"{TranslateTypeReference(parameterTypeCombination.TypeReference, true)} {parameterTypeCombination.ParameterDefinition.Name}";
            }
            return $"{TranslateTypeReference(parameterTypeCombination.TypeReference)} {parameterTypeCombination.ParameterDefinition.Name}";
        }

        private IEnumerable<IEnumerable<(ParameterDefinition ParameterDefinition, TypeReference TypeReference)>> GetParametersCombination(IEnumerable<ParameterDefinition> parameterDefinitions)
        {
            if (!parameterDefinitions.Any())
            {
                // return 1 combination of no parameters
                return new[] { Enumerable.Empty<(ParameterDefinition ParameterDefinition, TypeReference TypeReference)>() };
            }
            var parameters = parameterDefinitions.Select(parameterDefinition => {
                if (parameterDefinition.TypeReference is null)
                {
                    throw new Exception($"Type reference cannot be null. Parameter definition: {parameterDefinition.Name}");
                }

                if (parameterDefinition.TypeReference.ChoicesType != null)
                {
                    return parameterDefinition.TypeReference.ChoicesType.Select(typeReference => (parameterDefinition, typeReference));
                }
                return new[] { (parameterDefinition, parameterDefinition.TypeReference) };
            }).ToArray();
            return parameters.GetCombinations();
        }

        public IEnumerable<string> TranslateEnumValueDefinition(EnumValueDefinition enumValueDefinition)
        {
            if (!string.IsNullOrEmpty(enumValueDefinition.Description))
            {
                yield return $"/// <summary>";
                foreach (var description in enumValueDefinition.GetDescription())
                {
                    yield return $"/// {description}";
                }
                yield return $"/// </summary>";
            }
            else
            {
                yield return $"/// <summary>{enumValueDefinition.Name}</summary>";
            }
            var sanitizedValueName = enumValueDefinition.GetName().Replace("-", "_");
            if (enumValueDefinition.Deprecated)
            {
                yield return $"[Obsolete(\"{enumValueDefinition.DeprecatedMessage}\")]";
            }
            yield return $"[EnumValue(\"{enumValueDefinition.Name}\")]";
            yield return $"{sanitizedValueName},";
        }

        public string? TranslateTypeReference(TypeReference? typeReference)
        {
            return TranslateTypeReference(typeReference, false);
        }

        public string? TranslateTypeReference(TypeReference? typeReference, bool optional)
        {
            if (typeReference is null)
            {
                return null;
            }
            if (typeReference.Reference != null)
            {
                typeReference.Name = typeReference.Reference;
            }
            else
            {
                typeReference.Name = typeReference.Type;
                if (typeReference.Type == "array")
                {
                    var arrayItemTypeName = TranslateTypeReference(typeReference.ArrayItemType);
                    if (arrayItemTypeName != null)
                    {
                        typeReference.Name = $"IEnumerable<{arrayItemTypeName}>";
                    }
                }
                else
                {
                    switch (typeReference.Type)
                    {
                        case "boolean":
                            return "bool" + (optional ? "?" : "");
                        case "number":
                            return "double" + (optional ? "?" : "");
                        case "integer":
                            return "int" + (optional ? "?" : "");
                        case "string":
                            return "string";
                        case "function":
                            return "Action";
                        case "any":
                        case "object":
                        case null:
                            return "object";
                    }
                }
            }

            return typeReference.GetName();
        }

        private string SanitizeVariableName(string variableName)
        {
            return Regex.Replace(variableName, "(-|<|>)", "");
        }
    }
}
