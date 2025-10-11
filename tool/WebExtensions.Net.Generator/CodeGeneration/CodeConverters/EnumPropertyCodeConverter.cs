using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters;

public class EnumPropertyCodeConverter(ClrEnumValueInfo clrEnumValueInfo) : ICodeConverter
{
    private readonly ClrEnumValueInfo clrEnumValueInfo = clrEnumValueInfo;

    public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        => codeWriter.PublicProperties
            .WriteWithConverter(new CommentSummaryCodeConverter(!string.IsNullOrEmpty(clrEnumValueInfo.Description) ? clrEnumValueInfo.Description : clrEnumValueInfo.Name))
            .WriteLine($"[EnumValue(\"{clrEnumValueInfo.Name}\")]")
            .WriteLine($"{clrEnumValueInfo.CSharpName},");
}
