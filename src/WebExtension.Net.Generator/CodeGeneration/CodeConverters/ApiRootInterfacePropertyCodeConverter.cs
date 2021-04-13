using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public class ApiRootInterfacePropertyCodeConverter : BasePropertyCodeConverter
    {
        private readonly string propertyName;

        public ApiRootInterfacePropertyCodeConverter(string propertyName, PropertyDefinition propertyDefinition) : base(propertyDefinition)
        {
            this.propertyName = propertyName;
        }

        public override void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.WriteUsingStatement(UsingNamespaces);

            codeWriter.PublicProperties
                .WriteWithConverter(new CommentSummaryCodeConverter(PropertyDefinition.Description))
                .WriteWithConverter(PropertyDefinition.IsDeprecated ? new AttributeObsoleteCodeConverter(PropertyDefinition.Deprecated) : null)
                .WriteLine($"I{PropertyType} {propertyName.ToCapitalCase()} {{ get; }}");
        }
    }
}
