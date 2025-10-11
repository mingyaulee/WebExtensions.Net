using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters;

public class ApiMethodCodeConverter(ClrMethodInfo clrMethodInfo) : BaseMethodCodeConverter(clrMethodInfo), ICodeConverter
{
    public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
    {
        if (clrMethodInfo.IsAsync)
        {
            codeWriter.WriteUsingStatement("System.Threading.Tasks");
        }

        var (MethodArguments, MethodReturnType, ClientMethodInvokeArguments, ClientMethodInvoke) = GetMethodMetadata();
        codeWriter.PublicMethods
            .WriteWithConverter(new CommentInheritDocCodeConverter())
            .WriteWithConverter(clrMethodInfo.IsObsolete ? new AttributeObsoleteCodeConverter(clrMethodInfo.ObsoleteMessage) : null)
            .WriteLine($"public virtual {MethodReturnType} {clrMethodInfo.PublicName}({MethodArguments})")
            .WriteLine($"    => {ClientMethodInvoke}(\"{clrMethodInfo.Name}\"{ClientMethodInvokeArguments});");
    }
}
