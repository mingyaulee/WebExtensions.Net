using System.Collections.Generic;
using System.Text.RegularExpressions;
using WebExtensions.Net.Generator.Extensions;
using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public partial class MultitypeConstructorCodeConverter(string className, IEnumerable<ClrTypeInfo> typeChoices) : ICodeConverter
    {
        private readonly string className = className;
        private readonly IEnumerable<ClrTypeInfo> typeChoices = typeChoices;

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            var usingNamespaces = new HashSet<string>();
            var typeNames = new HashSet<string>();
            var parameterTypes = new List<ClrTypeInfo>();
            var writeParameterlessConstructor = false;

            foreach (var clrTypeInfo in typeChoices)
            {
                if (clrTypeInfo.IsNullType)
                {
                    writeParameterlessConstructor = true;
                    continue;
                }

                if (typeNames.Add(clrTypeInfo.CSharpName))
                {
                    parameterTypes.Add(clrTypeInfo);
                }
            }

            codeWriter.WriteUsingStatement(usingNamespaces);
            
            if (writeParameterlessConstructor)
            {
                WriteParameterlessConstructor(codeWriter, usePrimaryConstructor: parameterTypes.Count == 0);
            }

            WriteConstructors(codeWriter, parameterTypes, hasParameterlessConstructor: writeParameterlessConstructor);
        }

        private void WriteParameterlessConstructor(CodeWriter codeWriter, bool usePrimaryConstructor)
        {
            if (usePrimaryConstructor)
            {
                codeWriter.Declaration
                    .WritePrimaryConstructor([], ["null", "null"]);
            }
            else
            {
                codeWriter.Constructors
                    .WriteWithConverter(new CommentSummaryCodeConverter($"Creates a new instance of <see cref=\"{className}\" />."))
                    .WriteLine($"public {className}() : base(null, null)")
                    .WriteStartBlock()
                    .WriteEndBlock();
            }
        }

        private void WriteConstructors(CodeWriter codeWriter, List<ClrTypeInfo> parameterTypes, bool hasParameterlessConstructor)
        {
            if (parameterTypes.Count == 1 && !hasParameterlessConstructor)
            {
                WriteConstructor(codeWriter, parameterTypes[0], usePrimaryConstructor: true);
                return;
            }

            foreach (var clrTypeInfo in parameterTypes)
            {
                WriteConstructor(codeWriter, clrTypeInfo, usePrimaryConstructor: false);
            }
        }

        private void WriteConstructor(CodeWriter codeWriter, ClrTypeInfo clrTypeInfo, bool usePrimaryConstructor)
        {
            string? privateField = null;
            // object and interface implicit conversion is not allowed in C#
            if (clrTypeInfo.FullName != typeof(object).FullName && !clrTypeInfo.IsInterface)
            {
                privateField = $"value{SanitizeVariableName(clrTypeInfo.CSharpName).ToCapitalCase()}";
            }

            if (usePrimaryConstructor)
            {
                codeWriter.Declaration
                    .WriteWithConverter(new CommentParamCodeSectionConverter("value", "The value."))
                    .WritePrimaryConstructor([$"{clrTypeInfo.CSharpName} value"], ["value", $"typeof({clrTypeInfo.CSharpName})"]);
            }
            else
            {
                codeWriter.Constructors
                    .WriteWithConverter(new CommentSummaryCodeConverter($"Creates a new instance of <see cref=\"{className}\" />."))
                    .WriteWithConverter(new CommentParamCodeSectionConverter("value", "The value."))
                    .WriteLine($"public {className}({clrTypeInfo.CSharpName} value) : base(value, typeof({clrTypeInfo.CSharpName}))")
                    .WriteStartBlock()
                    .WriteLine(privateField is null ? null : $"{privateField} = value;")
                    .WriteEndBlock();
            }

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

        [GeneratedRegex("(-|<|>)")]
        private static partial Regex ReplacePattern();

        private static string SanitizeVariableName(string variableName)
            => ReplacePattern().Replace(variableName, "");
    }
}
