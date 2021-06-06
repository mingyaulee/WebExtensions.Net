using System.Linq;
using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class TypeMethodCodeConverter : ICodeConverter
    {
        private readonly ClrMethodInfo clrMethodInfo;

        public TypeMethodCodeConverter(ClrMethodInfo clrMethodInfo)
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
                .WriteWithConverter(new CommentSummaryCodeConverter(clrMethodInfo.Description))
                .WriteWithConverters(clrMethodInfo.Parameters.Select(parameterInfo => new CommentParamCodeSectionConverter(parameterInfo.Name, parameterInfo.Description)))
                .WriteWithConverter(clrMethodInfo.Return.HasReturnType ? new CommentReturnsCodeConverter(clrMethodInfo.Return.Description) : null)
                .WriteWithConverter(clrMethodInfo.IsObsolete ? new AttributeObsoleteCodeConverter(clrMethodInfo.ObsoleteMessage) : null)
                .WriteLine($"public virtual {methodReturnType} {clrMethodInfo.PublicName}({methodArguments})")
                .WriteStartBlock()
                .WriteLine($"return {clientMethodInvoke}(\"{clrMethodInfo.Name}\"{clientMethodInvokeArguments});")
                .WriteEndBlock();
        }
    }
}
