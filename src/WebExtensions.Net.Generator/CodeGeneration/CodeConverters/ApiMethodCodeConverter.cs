using System.Linq;
using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class ApiMethodCodeConverter : ICodeConverter
    {
        private readonly ClrMethodInfo clrMethodInfo;

        public ApiMethodCodeConverter(ClrMethodInfo clrMethodInfo)
        {
            this.clrMethodInfo = clrMethodInfo;
        }

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.WriteUsingStatement("System.Threading.Tasks");

            var methodArguments = string.Join(", ", clrMethodInfo.Parameters.Select(parameter => $"{parameter.ParameterType.CSharpName} {parameter.Name}"));
            var clientMethodInvokeArguments = string.Join("", clrMethodInfo.Parameters.Select(parameter => $", {parameter.Name}"));
            var clientMethodInvoke = "InvokeVoidAsync";
            var methodReturnType = "ValueTask";
            if (clrMethodInfo.Return.HasReturnType)
            {
                var returnTypeName = clrMethodInfo.Return.ReturnType?.CSharpName;
                methodReturnType = $"ValueTask<{returnTypeName}>";
                clientMethodInvoke = $"InvokeAsync<{returnTypeName}>";
            }

            codeWriter.PublicMethods
                .WriteWithConverter(new CommentInheritDocCodeConverter())
                .WriteWithConverter(clrMethodInfo.IsObsolete ? new AttributeObsoleteCodeConverter(clrMethodInfo.ObsoleteMessage) : null)
                .WriteLine($"public virtual {methodReturnType} {clrMethodInfo.PublicName}({methodArguments})")
                .WriteStartBlock()
                .WriteLine($"return {clientMethodInvoke}(\"{clrMethodInfo.Name}\"{clientMethodInvokeArguments});")
                .WriteEndBlock();
        }
    }
}
