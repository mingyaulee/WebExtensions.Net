using System.Collections.Generic;
using System.Text.RegularExpressions;
using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public class MultitypeConstructorCodeConverter : ICodeConverter
    {
        private readonly string className;
        private readonly IEnumerable<TypeDefinition> typeChoices;

        public MultitypeConstructorCodeConverter(string className, IEnumerable<TypeDefinition> typeChoices)
        {
            this.className = className;
            this.typeChoices = typeChoices;
        }

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            var usingNamespaces = new HashSet<string>();
            var typeNames = new HashSet<string>();
            bool writeParameterlessConstructor = false;

            foreach (var typeDefinition in typeChoices)
            {
                if (typeDefinition.Type == ObjectType.Null)
                {
                    writeParameterlessConstructor = true;
                    continue;
                }
                typeNames.Add(typeDefinition.ToTypeName(usingNamespaces));
            }

            codeWriter.WriteUsingStatement(usingNamespaces);
            
            if (writeParameterlessConstructor)
            {
                codeWriter.Constructors
                    .WriteWithConverter(new CommentSummaryCodeConverter($"Creates a new instance of <see cref=\"{className}\" />."))
                    .WriteLine($"public {className}()")
                    .WriteStartBlock()
                    .WriteEndBlock();
            }

            foreach (var typeName in typeNames)
            {
                string? privateField = null;
                // Rely on the convention that interface name starts with the letter I
                // object and interface implicit conversion is not allowed in C#
                if (typeName != "object" && !typeName.StartsWith("I"))
                {
                    privateField = $"value{SanitizeVariableName(typeName).ToCapitalCase()}";
                }

                codeWriter.Constructors
                    .WriteWithConverter(new CommentSummaryCodeConverter($"Creates a new instance of <see cref=\"{className}\" />."))
                    .WriteWithConverter(new CommentParamCodeSectionConverter("value", "The value."))
                    .WriteLine($"public {className}({typeName} value)")
                    .WriteStartBlock()
                    .WriteLine(privateField is null ? null : $"{privateField} = value;")
                    .WriteLine($"currentValue = value;")
                    .WriteEndBlock();

                if (privateField is not null)
                {
                    codeWriter.Properties
                        .WriteLine($"private readonly {typeName} {privateField};");

                    codeWriter.PublicMethods
                        .WriteWithConverter(new CommentSummaryCodeConverter($"Converts from <see cref=\"{className}\" /> to <see cref=\"{typeName}\" />."))
                        .WriteWithConverter(new CommentParamCodeSectionConverter("value", "The value to convert from."))
                        .WriteLine($"public static implicit operator {typeName}({className} value) => value.{privateField};");

                    codeWriter.PublicMethods
                        .WriteWithConverter(new CommentSummaryCodeConverter($"Converts from <see cref=\"{typeName}\" /> to <see cref=\"{className}\" />."))
                        .WriteWithConverter(new CommentParamCodeSectionConverter("value", "The value to convert from."))
                        .WriteLine($"public static implicit operator {className}({typeName} value) => new(value);");
                }
            }
        }

        private static string SanitizeVariableName(string variableName)
        {
            return Regex.Replace(variableName, "(-|<|>)", "");
        }
    }
}
