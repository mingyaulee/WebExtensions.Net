using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public class TypePropertyCodeConverter : BasePropertyCodeConverter
    {
        private readonly string propertyName;

        public TypePropertyCodeConverter(string propertyName, PropertyDefinition propertyDefinition) : base(propertyDefinition)
        {
            this.propertyName = propertyName;
        }

        public override void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.WriteUsingStatement(UsingNamespaces);
            codeWriter.WriteUsingStatement("System.Text.Json.Serialization");

            codeWriter.Properties
                .WriteLine($"private {PropertyType} _{propertyName};");

            codeWriter.PublicProperties
                .WriteWithConverter(new CommentSummaryCodeConverter(PropertyDefinition.Description))
                .WriteWithConverter(PropertyDefinition.IsDeprecated ? new AttributeObsoleteCodeConverter(PropertyDefinition.Deprecated) : null)
                .WriteWithConverter(new AttributeCodeConverter($"JsonPropertyName(\"{propertyName}\")"))
                .WriteLine($"public {PropertyType} {propertyName.ToCapitalCase()}")
                // start property body
                .WriteStartBlock()
                    .WriteLine($"get")
                    .WriteStartBlock()
                        .WriteLine($"InitializeProperty(\"{propertyName}\", _{propertyName});")
                        .WriteLine($"return _{propertyName};")
                    .WriteEndBlock()

                    .WriteLine($"set")
                    .WriteStartBlock()
                        .WriteLine($"_{propertyName} = value;")
                    .WriteEndBlock()
                // end property body
                .WriteEndBlock();
        }
    }
}
