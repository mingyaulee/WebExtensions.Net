using System.Linq;
using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters;

public class TypeMethodCodeConverter(ClrMethodInfo clrMethodInfo) : BaseMethodCodeConverter(clrMethodInfo), ICodeConverter
{
    public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
    {
        if (clrMethodInfo.IsAsync)
        {
            codeWriter.WriteUsingStatement("System.Threading.Tasks");
        }

        var (MethodArguments, MethodReturnType, ClientMethodInvokeArguments, ClientMethodInvoke) = GetMethodMetadata();
        codeWriter.PublicMethods
            .WriteWithConverter(new CommentSummaryCodeConverter(clrMethodInfo.Description))
            .WriteWithConverters(clrMethodInfo.Parameters.Select(parameterInfo => new CommentParamCodeSectionConverter(parameterInfo.Name, parameterInfo.Description)))
            .WriteWithConverter(clrMethodInfo.Return.HasReturnType ? new CommentReturnsCodeConverter(clrMethodInfo.Return.Description) : null)
            .WriteWithConverter(new AttributeJsAccessPathCodeConverter(clrMethodInfo.Name))
            .WriteWithConverter(clrMethodInfo.IsObsolete ? new AttributeObsoleteCodeConverter(clrMethodInfo.ObsoleteMessage) : null)
            .WriteLine($"public virtual {MethodReturnType} {clrMethodInfo.PublicName}({MethodArguments})")
            .WriteLine($"    => {ClientMethodInvoke}(\"{clrMethodInfo.Name}\"{ClientMethodInvokeArguments});");
    }
}
