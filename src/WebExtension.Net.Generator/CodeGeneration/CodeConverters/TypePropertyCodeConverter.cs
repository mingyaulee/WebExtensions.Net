using WebExtension.Net.Generator.Models.ClrTypes;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public class TypePropertyCodeConverter : ICodeConverter
    {
        private readonly ClrPropertyInfo clrPropertyInfo;

        public TypePropertyCodeConverter(ClrPropertyInfo clrPropertyInfo)
        {
            this.clrPropertyInfo = clrPropertyInfo;
        }

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.WriteUsingStatement("System.Text.Json.Serialization");

            var privatePropertyName = clrPropertyInfo.PrivateName;
            codeWriter.Properties
                .WriteLine($"private {clrPropertyInfo.PropertyType.CSharpName} _{privatePropertyName};");

            codeWriter.PublicProperties
                .WriteWithConverter(new CommentSummaryCodeConverter(clrPropertyInfo.Description))
                .WriteWithConverter(clrPropertyInfo.IsObsolete ? new AttributeObsoleteCodeConverter(clrPropertyInfo.ObsoleteMessage) : null)
                .WriteWithConverter(new AttributeCodeConverter($"JsonPropertyName(\"{privatePropertyName}\")"))
                .WriteWithConverter(clrPropertyInfo.PropertyType.IsNullable ? new AttributeCodeConverter($"JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)") : null)
                .WriteLine($"public {clrPropertyInfo.PropertyType.CSharpName} {clrPropertyInfo.PublicName}")
                // start property body
                .WriteStartBlock()
                    .WriteLine($"get")
                    .WriteStartBlock()
                        .WriteLine($"InitializeProperty(\"{privatePropertyName}\", _{privatePropertyName});")
                        .WriteLine($"return _{privatePropertyName};")
                    .WriteEndBlock()

                    .WriteLine($"set")
                    .WriteStartBlock()
                        .WriteLine($"_{privatePropertyName} = value;")
                    .WriteEndBlock()
                // end property body
                .WriteEndBlock();
        }
    }
}
