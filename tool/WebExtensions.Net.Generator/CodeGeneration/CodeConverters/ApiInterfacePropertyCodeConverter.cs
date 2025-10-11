using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters;

public class ApiInterfacePropertyCodeConverter(ClrPropertyInfo clrPropertyInfo) : ICodeConverter
{
    private readonly ClrPropertyInfo clrPropertyInfo = clrPropertyInfo;

    public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
    {
        if (clrPropertyInfo.PropertyType.Metadata.TryGetValue(Constants.TypeMetadata.ClassType, out var classType) && (ClassType)classType == ClassType.ApiClass)
        {
            new ApiClassInterfaceApiPropertyCodeConverter(clrPropertyInfo)
                .WriteTo(codeWriter, options);
        }
        else
        {
            codeWriter.PublicProperties
                .WriteWithConverter(new CommentSummaryCodeConverter(clrPropertyInfo.Description))
                .WriteWithConverter(new AttributeJsAccessPathCodeConverter(clrPropertyInfo.Name))
                .WriteWithConverter(clrPropertyInfo.IsObsolete ? new AttributeObsoleteCodeConverter(clrPropertyInfo.ObsoleteMessage) : null)
                .WriteLine($"{clrPropertyInfo.PropertyType.CSharpName} {clrPropertyInfo.PublicName} {{ get; }}");
        }
    }
}
