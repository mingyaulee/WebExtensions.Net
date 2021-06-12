using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using WebExtensions.Net.Generator.Extensions;
using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class MultitypeConstructorCodeConverter : ICodeConverter
    {
        private readonly string className;
        private readonly IEnumerable<ClrTypeInfo> typeChoices;

        public MultitypeConstructorCodeConverter(string className, IEnumerable<ClrTypeInfo> typeChoices)
        {
            this.className = className;
            this.typeChoices = typeChoices;
        }

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            var usingNamespaces = new HashSet<string>();
            var typeNames = new HashSet<string>();
            var writeParameterlessConstructor = typeChoices.Any(clrTypeInfo => clrTypeInfo.IsNullType);

            codeWriter.WriteUsingStatement(usingNamespaces);
            
            if (writeParameterlessConstructor)
            {
                codeWriter.Constructors
                    .WriteWithConverter(new CommentSummaryCodeConverter($"Creates a new instance of <see cref=\"{className}\" />."))
                    .WriteLine($"public {className}() : base(null, null)")
                    .WriteStartBlock()
                    .WriteEndBlock();
            }

            foreach (var clrTypeInfo in typeChoices)
            {
                if (typeNames.Contains(clrTypeInfo.CSharpName) || clrTypeInfo.IsNullType)
                {
                    continue;
                }
                typeNames.Add(clrTypeInfo.CSharpName);

                string? privateField = null;
                // object and interface implicit conversion is not allowed in C#
                if (clrTypeInfo.FullName != typeof(object).FullName && !clrTypeInfo.IsInterface)
                {
                    privateField = $"value{SanitizeVariableName(clrTypeInfo.CSharpName).ToCapitalCase()}";
                }

                codeWriter.Constructors
                    .WriteWithConverter(new CommentSummaryCodeConverter($"Creates a new instance of <see cref=\"{className}\" />."))
                    .WriteWithConverter(new CommentParamCodeSectionConverter("value", "The value."))
                    .WriteLine($"public {className}({clrTypeInfo.CSharpName} value) : base(value, typeof({clrTypeInfo.CSharpName}))")
                    .WriteStartBlock()
                    .WriteLine(privateField is null ? null : $"{privateField} = value;")
                    .WriteEndBlock();

                if (privateField is not null)
                {
                    codeWriter.Properties
                        .WriteLine($"private readonly {clrTypeInfo.CSharpName} {privateField};");

                    codeWriter.PublicMethods
                        .WriteWithConverter(new CommentSummaryCodeConverter($"Converts from <see cref=\"{className}\" /> to <see cref=\"{clrTypeInfo.CSharpName}\" />."))
                        .WriteWithConverter(new CommentParamCodeSectionConverter("value", "The value to convert from."))
                        .WriteLine($"public static implicit operator {clrTypeInfo.CSharpName}({className} value) => value.{privateField};");

                    codeWriter.PublicMethods
                        .WriteWithConverter(new CommentSummaryCodeConverter($"Converts from <see cref=\"{clrTypeInfo.CSharpName}\" /> to <see cref=\"{className}\" />."))
                        .WriteWithConverter(new CommentParamCodeSectionConverter("value", "The value to convert from."))
                        .WriteLine($"public static implicit operator {className}({clrTypeInfo.CSharpName} value) => new(value);");
                }
            }
        }

        private static string SanitizeVariableName(string variableName)
        {
            return Regex.Replace(variableName, "(-|<|>)", "");
        }
    }
}
