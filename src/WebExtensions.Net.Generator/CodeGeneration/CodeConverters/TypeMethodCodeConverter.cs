using System.Linq;
using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class TypeMethodCodeConverter : BaseMethodCodeConverter, ICodeConverter
    {
        public TypeMethodCodeConverter(ClrMethodInfo clrMethodInfo) : base(clrMethodInfo)
        {
        }

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.WriteUsingStatement("System.Threading.Tasks");

            var metadata = GetMethodMetadata();
            codeWriter.PublicMethods
                .WriteWithConverter(new CommentSummaryCodeConverter(clrMethodInfo.Description))
                .WriteWithConverters(clrMethodInfo.Parameters.Select(parameterInfo => new CommentParamCodeSectionConverter(parameterInfo.Name, parameterInfo.Description)))
                .WriteWithConverter(clrMethodInfo.Return.HasReturnType ? new CommentReturnsCodeConverter(clrMethodInfo.Return.Description) : null)
                .WriteWithConverter(clrMethodInfo.IsObsolete ? new AttributeObsoleteCodeConverter(clrMethodInfo.ObsoleteMessage) : null)
                .WriteLine($"public virtual {metadata.MethodReturnType} {clrMethodInfo.PublicName}({metadata.MethodArguments})")
                .WriteStartBlock()
                .WriteLine($"return {metadata.ClientMethodInvoke}(\"{clrMethodInfo.Name}\"{metadata.ClientMethodInvokeArguments});")
                .WriteEndBlock();
        }
    }
}
