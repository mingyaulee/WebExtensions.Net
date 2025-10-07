using System.Collections.Generic;
using System.Linq;
using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class CombinedCallbackParameterConstructorCodeConverter(string className, IEnumerable<ClrPropertyInfo> clrPropertyInfos) : ICodeConverter
    {
        private readonly string className = className;
        private readonly IEnumerable<ClrPropertyInfo> clrPropertyInfos = clrPropertyInfos;

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.WriteUsingStatement("System");

            var propertyTypes = clrPropertyInfos.Select(property => $"typeof({property.PropertyType.CSharpName})");
            var propertyNames = clrPropertyInfos.Select(property => $"\"{property.PublicName}\"");

            codeWriter.Properties
                .WriteLine($"private static readonly Type[] propertyTypes = new[] {{ {string.Join(", ", propertyTypes)} }};")
                .WriteLine($"private static readonly string[] propertyNames = new[] {{ {string.Join(", ", propertyNames)} }};");

            codeWriter.Constructors
                .WriteWithConverter(new CommentSummaryCodeConverter($"Creates a new instance of <see cref=\"{className}\" />."))
                .WriteLine($"public {className}() : base(propertyTypes, propertyNames)")
                .WriteStartBlock()
                .WriteEndBlock();
        }
    }
}
