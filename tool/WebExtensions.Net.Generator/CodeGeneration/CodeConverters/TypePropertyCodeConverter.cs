using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters;

public class TypePropertyCodeConverter(ClrPropertyInfo clrPropertyInfo) : ICodeConverter
{
    private readonly ClrPropertyInfo clrPropertyInfo = clrPropertyInfo;

    public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
    {
        codeWriter.WriteUsingStatement("System.Text.Json.Serialization");

        codeWriter.PublicProperties
            .WriteWithConverter(new CommentSummaryCodeConverter(clrPropertyInfo.Description))
            .WriteWithConverter(clrPropertyInfo.IsObsolete ? new AttributeObsoleteCodeConverter(clrPropertyInfo.ObsoleteMessage) : null)
            .WriteWithConverter(new AttributeJsAccessPathCodeConverter(clrPropertyInfo.Name))
            .WriteWithConverter(new AttributeCodeConverter($"JsonPropertyName(\"{clrPropertyInfo.Name}\")"))
            .WriteWithConverter(clrPropertyInfo.PropertyType.IsNullable ? new AttributeCodeConverter($"JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)") : null)
            .WriteLine($"public {clrPropertyInfo.PropertyType.CSharpName} {clrPropertyInfo.PublicName} {{ get; set; }}");
    }
}
