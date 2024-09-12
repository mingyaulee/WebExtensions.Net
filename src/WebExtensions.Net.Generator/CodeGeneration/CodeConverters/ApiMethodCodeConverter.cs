using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class ApiMethodCodeConverter : BaseMethodCodeConverter, ICodeConverter
    {
        public ApiMethodCodeConverter(ClrMethodInfo clrMethodInfo) : base(clrMethodInfo)
        {
        }

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            if (clrMethodInfo.IsAsync)
            {
                codeWriter.WriteUsingStatement("System.Threading.Tasks");
            }

            var metadata = GetMethodMetadata();
            codeWriter.PublicMethods
                .WriteWithConverter(new CommentInheritDocCodeConverter())
                .WriteWithConverter(clrMethodInfo.IsObsolete ? new AttributeObsoleteCodeConverter(clrMethodInfo.ObsoleteMessage) : null)
                .WriteLine($"public virtual {metadata.MethodReturnType} {clrMethodInfo.PublicName}({metadata.MethodArguments})")
                .WriteLine($"    => {metadata.ClientMethodInvoke}(\"{clrMethodInfo.Name}\"{metadata.ClientMethodInvokeArguments});");
        }
    }
}
