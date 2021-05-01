using WebExtension.Net.Generator.Models.ClrTypes;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public class ApiInterfacePropertyCodeConverter : ICodeConverter
    {
        private readonly ClrPropertyInfo clrPropertyInfo;

        public ApiInterfacePropertyCodeConverter(ClrPropertyInfo clrPropertyInfo)
        {
            this.clrPropertyInfo = clrPropertyInfo;
        }

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.PublicProperties
                .WriteWithConverter(new CommentSummaryCodeConverter(clrPropertyInfo.Description))
                .WriteWithConverter(clrPropertyInfo.IsObsolete ? new AttributeObsoleteCodeConverter(clrPropertyInfo.ObsoleteMessage) : null)
                .WriteLine($"{clrPropertyInfo.PropertyType.CSharpName} {clrPropertyInfo.PublicName} {{ get; }}");
        }
    }
}
