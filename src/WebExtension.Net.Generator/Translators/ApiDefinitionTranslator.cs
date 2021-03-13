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

        public string TranslateApiDefinitionRoot(ApiDefinitionRoot apiDefinitionRoot, IEnumerable<ApiDefinition> apiDefinitions, string className, string definitionPostfix)
        {
            var content = new StringBuilder();
            var usingNamespaces = apiDefinitions.Select(apiDefinition => $"using {apiDefinition.GetNamespace()};");
            var apiProperties = apiDefinitions.SelectMany(apiDefinition =>
            {
                return new[]
                {
                    $"",
                    $"private {apiDefinition.GetName()}{definitionPostfix} _{apiDefinition.Name};",
                    $"public I{apiDefinition.GetName()}{definitionPostfix} {apiDefinition.GetName()}",
                    $"{{",
                    $"    get",
                    $"    {{",
                    $"        if (_{apiDefinition.Name} is null)",
                    $"        {{",
                    $"            _{apiDefinition.Name} = new {apiDefinition.GetName()}{definitionPostfix}(webExtensionJSRuntime);",
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
            content.AppendLine($"    public class {className} : I{className}");
            content.AppendLine($"    {{");
            content.AppendLine($"        private readonly WebExtensionJSRuntime webExtensionJSRuntime;");
            content.AppendLine($"        public {className}(WebExtensionJSRuntime webExtensionJSRuntime)");
            content.AppendLine($"        {{");
            content.AppendLine($"            this.webExtensionJSRuntime = webExtensionJSRuntime;");
            content.AppendLine($"        }}");
            content.AppendLine($"");
            content.AppendLine($"        {string.Join($"{Environment.NewLine}        ", apiProperties)}");
            content.AppendLine($"    }}");
            content.AppendLine($"}}");

            return content.ToString();
        }

        public string TranslateApiDefinitionRootInterface(ApiDefinitionRoot apiDefinitionRoot, IEnumerable<ApiDefinition> apiDefinitions, string className, string definitionPostfix)
        {
            var content = new StringBuilder();
            var usingNamespaces = apiDefinitions.Select(apiDefinition => $"using {apiDefinition.GetNamespace()};");
            var apiProperties = apiDefinitions.SelectMany(apiDefinition =>
            {
                return new[]
                {
                    $"/// <summary>{apiDefinition.Description}</summary>",
                    $"I{apiDefinition.GetName()}{definitionPostfix} {apiDefinition.GetName()} {{ get; }}"
                };
            });
            content.AppendLine($"{string.Join(Environment.NewLine, usingNamespaces)}");
            content.AppendLine($"");
            content.AppendLine($"namespace {apiDefinitionRoot.RootNamespace}");
            content.AppendLine($"{{");
            content.AppendLine($"    public interface I{className}");
            content.AppendLine($"    {{");
            content.AppendLine($"        {string.Join($"{Environment.NewLine}        ", apiProperties)}");
            content.AppendLine($"    }}");
            content.AppendLine($"}}");

            return content.ToString();
        }

        public string TranslateApiDefinition(ApiDefinition apiDefinition, string className)
        {
            if (!apiDefinition.Functions.Any())
            {
                return string.Empty;
            }

            logger.LogInformation($"    API Class {className}");
            var content = new StringBuilder();
            var methods = apiDefinition.Functions.SelectMany(TranslateFunctionDefinition);
            content.AppendLine($"using System;");
            content.AppendLine($"using System.Collections.Generic;");
            content.AppendLine($"using System.Text.Json;");
            content.AppendLine($"using System.Threading.Tasks;");
            content.AppendLine($"");
            content.AppendLine($"namespace {apiDefinition.GetNamespace()}");
            content.AppendLine($"{{");
            content.AppendLine($"    /// <summary>{apiDefinition.Description}</summary>");
            content.AppendLine($"    public class {className} : I{className}");
            content.AppendLine($"    {{");
            content.AppendLine($"        private readonly WebExtensionJSRuntime webExtensionJSRuntime;");
            content.AppendLine($"        public {className}(WebExtensionJSRuntime webExtensionJSRuntime)");
            content.AppendLine($"        {{");
            content.AppendLine($"            this.webExtensionJSRuntime = webExtensionJSRuntime;");
            content.AppendLine($"        }}");
            content.AppendLine($"");
            content.AppendLine($"        {string.Join($"{Environment.NewLine}        ", methods)}");
            content.AppendLine($"    }}");
            content.AppendLine($"}}");

            return content.ToString();
        }

        public string TranslateApiDefinitionInterface(ApiDefinition apiDefinition, string className)
        {
            if (!apiDefinition.Functions.Any())
            {
                return string.Empty;
            }

            logger.LogInformation($"    API Interface I{className}");
            var content = new StringBuilder();
            var methods = apiDefinition.Functions.SelectMany(TranslateFunctionDefinitionInterface);
            content.AppendLine($"using System;");
            content.AppendLine($"using System.Collections.Generic;");
            content.AppendLine($"using System.Text.Json;");
            content.AppendLine($"using System.Threading.Tasks;");
            content.AppendLine($"");
            content.AppendLine($"namespace {apiDefinition.GetNamespace()}");
            content.AppendLine($"{{");
            content.AppendLine($"    /// <summary>{apiDefinition.Description}</summary>");
            content.AppendLine($"    public interface I{className}");
            content.AppendLine($"    {{");
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
            yield return $"/// Class Definition";
            yield return $"/// <summary>{classDefinition.Description}</summary>";
            if (classDefinition.Deprecated)
            {
                yield return $"[Obsolete(\"{classDefinition.DeprecatedMessage}\")]";
            }
            yield return $"public class {classDefinition.GetName()}{(methods.Any() ? $" : BaseObject" : "")}";
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
            yield return $"/// Enum Definition";
            yield return $"/// <summary>{enumDefinition.Description}</summary>";
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
            yield return $"/// String Format Definition";
            yield return $"/// <summary>{stringFormatDefinition.Description}</summary>";
            if (stringFormatDefinition.Deprecated)
            {
                yield return $"[Obsolete(\"{stringFormatDefinition.DeprecatedMessage}\")]";
            }
            yield return $"public class {stringFormatDefinition.GetName()} : BaseStringFormat";
            yield return $"{{";
            yield return $"    private const string pattern = \"{stringFormatDefinition.Format}\";";
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
            yield return $"/// List Definition";
            yield return $"/// <summary>{listDefinition.Description}</summary>";
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
                        $"public {multiTypeDefinition.GetName()}() {{ }}",
                        $""
                    };
                }
                var sanitizedVariableName = SanitizeVariableName($"value{typeReferenceName}");
                return new[]
                {
                    $"private readonly {typeReferenceName} {sanitizedVariableName};",
                    $"public {multiTypeDefinition.GetName()}({typeReferenceName} {sanitizedVariableName})",
                    $"{{",
                    $"    this.{sanitizedVariableName} = {sanitizedVariableName};",
                    $"}}",
                    $""
                };
            });
            yield return $"/// MultiType Definition";
            yield return $"/// <summary>{multiTypeDefinition.Description}</summary>";
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

        public IEnumerable<string> TranslatePropertyDefinition(PropertyDefinition propertyDefinition)
        {
            if (!propertyDefinition.Unsupported)
            {
                yield return $"";
                yield return $"/// Property Definition";
                yield return $"/// <summary>{propertyDefinition.Description}</summary>";
                if (propertyDefinition.Deprecated)
                {
                    yield return $"[Obsolete(\"{propertyDefinition.DeprecatedMessage}\")]";
                }
                yield return $"[JsonPropertyName(\"{propertyDefinition.Name}\")]";
                yield return $"public {TranslateTypeReference(propertyDefinition.Type, propertyDefinition.Optional)} {propertyDefinition.GetName()} {{ get; set; }}";
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
                    yield return $"/// Function Definition";
                    yield return $"/// <summary>";
                    yield return $"/// {functionDefinition.Description}";
                    yield return $"/// </summary>";
                    foreach (var parameterTypeCombination in parameterTypeCombinations)
                    {
                        yield return $"/// <param name=\"{parameterTypeCombination.ParameterDefinition.Name}\">{parameterTypeCombination.ParameterDefinition.Description}</param>";
                    };
                    if (functionDefinition.Deprecated)
                    {
                        yield return $"[Obsolete(\"{functionDefinition.DeprecatedMessage}\")]";
                    }
                    yield return $"public virtual {methodReturnType} {functionDefinition.GetName()}({string.Join(", ", parameterTypeCombinations.Select(TranslateParameterDefinition))})";
                    yield return $"{{";
                    yield return $"    return webExtensionJSRuntime.{clientMethodInvoke}(\"{functionDefinition.FunctionAccessor}\"{string.Join("", parameterTypeCombinations.Select(parameterTypeCombination => $", {parameterTypeCombination.ParameterDefinition.Name}"))});";
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
                    yield return $"/// Function Definition Interface";
                    yield return $"/// <summary>";
                    yield return $"/// {functionDefinition.Description}";
                    yield return $"/// </summary>";
                    foreach (var parameterTypeCombination in parameterTypeCombinations)
                    {
                        yield return $"/// <param name=\"{parameterTypeCombination.ParameterDefinition.Name}\">{parameterTypeCombination.ParameterDefinition.Description}</param>";
                    };
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
                yield return $"/// <summary>{enumValueDefinition.Description}</summary>";
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
