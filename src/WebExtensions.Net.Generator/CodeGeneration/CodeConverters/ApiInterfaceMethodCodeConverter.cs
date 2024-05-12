using System.Linq;
using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class ApiInterfaceMethodCodeConverter : BaseMethodCodeConverter, ICodeConverter
    {
        public ApiInterfaceMethodCodeConverter(ClrMethodInfo clrMethodInfo) : base(clrMethodInfo)
        {
        }

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.WriteUsingStatement("System.Threading.Tasks");

            var methodSignature = GetMethodSignature();
            codeWriter.PublicMethods
                .WriteWithConverter(new CommentSummaryCodeConverter(clrMethodInfo.Description))
                .WriteWithConverters(clrMethodInfo.Parameters.Select(parameterInfo => new CommentParamCodeSectionConverter(parameterInfo.Name, parameterInfo.Description)))
                .WriteWithConverter(clrMethodInfo.Return.HasReturnType ? new CommentReturnsCodeConverter(clrMethodInfo.Return.Description) : null)
                .WriteWithConverter(clrMethodInfo.IsObsolete ? new AttributeObsoleteCodeConverter(clrMethodInfo.ObsoleteMessage) : null)
                .WriteLine($"{methodSignature.MethodReturnType} {clrMethodInfo.PublicName}({methodSignature.MethodArguments});");
        }
    }
}
