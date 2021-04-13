using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public class ApiInterfacePropertyCodeConverter : BasePropertyCodeConverter
    {
        private readonly string propertyName;

        public ApiInterfacePropertyCodeConverter(string propertyName, PropertyDefinition propertyDefinition) : base(propertyDefinition)
        {
            this.propertyName = propertyName;
        }

        public override void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.WriteUsingStatement(UsingNamespaces);

            codeWriter.PublicProperties
                .WriteWithConverter(new CommentSummaryCodeConverter(PropertyDefinition.Description))
                .WriteWithConverter(PropertyDefinition.IsDeprecated ? new AttributeObsoleteCodeConverter(PropertyDefinition.Deprecated) : null)
                .WriteLine($"{PropertyType} {propertyName} {{ get; }}");
        }
    }
}
