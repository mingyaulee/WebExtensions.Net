using WebExtension.Net.Generator.Models.ClrTypes;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public class ApiRootInterfacePropertyCodeConverter : ICodeConverter
    {
        private readonly ClrPropertyInfo clrPropertyInfo;

        public ApiRootInterfacePropertyCodeConverter(ClrPropertyInfo clrPropertyInfo)
        {
            this.clrPropertyInfo = clrPropertyInfo;
        }

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.PublicProperties
                .WriteWithConverter(new CommentSummaryCodeConverter(clrPropertyInfo.Description))
                .WriteWithConverter(clrPropertyInfo.IsObsolete ? new AttributeObsoleteCodeConverter(clrPropertyInfo.ObsoleteMessage) : null)
                .WriteLine($"I{clrPropertyInfo.PropertyType.CSharpName} {clrPropertyInfo.PublicName} {{ get; }}");
        }
    }
}
