using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters;

public class ApiRootPropertyCodeConverter(ClrPropertyInfo clrPropertyInfo) : ICodeConverter
{
    private readonly ClrPropertyInfo clrPropertyInfo = clrPropertyInfo;

    public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        => new ApiClassApiPropertyCodeConverter(clrPropertyInfo)
            .WriteTo(codeWriter, options);
}
