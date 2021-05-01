using System.Linq;
using WebExtension.Net.Generator.Models.ClrTypes;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public class ApiInterfaceMethodCodeConverter : ICodeConverter
    {
        private readonly ClrMethodInfo clrMethodInfo;

        public ApiInterfaceMethodCodeConverter(ClrMethodInfo clrMethodInfo)
        {
            this.clrMethodInfo = clrMethodInfo;
        }

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.WriteUsingStatement("System.Threading.Tasks");

            var isPropertyGetterMethod = clrMethodInfo.Metadata.ContainsKey(Constants.MethodMetadata.IsPropertyGetterMethod);
            var methodNamePrefix = isPropertyGetterMethod ? "Get" : string.Empty;
            var methodArguments = string.Join(", ", clrMethodInfo.Parameters.Select(parameter => $"{parameter.ParameterType.CSharpName} {parameter.Name}"));
            var methodReturnType = "ValueTask";
            if (clrMethodInfo.Return.HasReturnType)
            {
                methodReturnType = $"ValueTask<{clrMethodInfo.Return.ReturnType?.CSharpName}>";
            }

            codeWriter.PublicMethods
                .WriteWithConverter(new CommentSummaryCodeConverter(clrMethodInfo.Description))
                .WriteWithConverters(clrMethodInfo.Parameters.Select(parameterInfo => new CommentParamCodeSectionConverter(parameterInfo.Name, parameterInfo.Description)))
                .WriteWithConverter(clrMethodInfo.Return.HasReturnType ? new CommentReturnsCodeConverter(clrMethodInfo.Return.Description) : null)
                .WriteWithConverter(clrMethodInfo.IsObsolete ? new AttributeObsoleteCodeConverter(clrMethodInfo.ObsoleteMessage) : null)
                .WriteLine($"{methodReturnType} {methodNamePrefix}{clrMethodInfo.PublicName}({methodArguments});");
        }
    }
}
