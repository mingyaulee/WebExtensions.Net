using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class ApiClassInterfaceApiPropertyCodeConverter : ICodeConverter
    {
        private readonly ClrPropertyInfo clrPropertyInfo;

        public ApiClassInterfaceApiPropertyCodeConverter(ClrPropertyInfo clrPropertyInfo)
        {
            this.clrPropertyInfo = clrPropertyInfo;
        }

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.PublicProperties
                .WriteWithConverter(new CommentSummaryCodeConverter(clrPropertyInfo.Description))
                .WriteWithConverter(new AttributeJsAccessPathCodeConverter((string)clrPropertyInfo.PropertyType.Metadata[Constants.TypeMetadata.ApiNamespace]))
                .WriteWithConverter(clrPropertyInfo.IsObsolete ? new AttributeObsoleteCodeConverter(clrPropertyInfo.ObsoleteMessage) : null)
                .WriteLine($"I{clrPropertyInfo.PropertyType.CSharpName} {clrPropertyInfo.PublicName} {{ get; }}");
        }
    }
}
