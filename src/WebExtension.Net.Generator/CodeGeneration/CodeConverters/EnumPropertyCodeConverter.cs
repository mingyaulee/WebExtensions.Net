using WebExtension.Net.Generator.Models.ClrTypes;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public class EnumPropertyCodeConverter : ICodeConverter
    {
        private readonly ClrEnumValueInfo clrEnumValueInfo;

        public EnumPropertyCodeConverter(ClrEnumValueInfo clrEnumValueInfo)
        {
            this.clrEnumValueInfo = clrEnumValueInfo;
        }

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.PublicProperties
                .WriteWithConverter(new CommentSummaryCodeConverter(clrEnumValueInfo.Description ?? clrEnumValueInfo.Name))
                .WriteLine($"[EnumValue(\"{clrEnumValueInfo.Name}\")]")
                .WriteLine($"{clrEnumValueInfo.CSharpName},");
        }
    }
}
