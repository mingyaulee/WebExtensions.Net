using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public class ApiMethodCodeConverter : BaseMethodCodeConverter
    {
        private readonly FunctionDefinition functionDefinition;

        public ApiMethodCodeConverter(FunctionDefinition functionDefinition) : base(functionDefinition)
        {
            this.functionDefinition = functionDefinition;
        }

        public override void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            if (functionDefinition.Name is null)
            {
                return;
            }

            codeWriter.WriteUsingStatement(UsingNamespaces);

            var methodNamePrefix = functionDefinition.Type == ObjectType.PropertyGetterFunction ? "Get" : string.Empty;
            codeWriter.PublicMethods
                .WriteWithConverter(new CommentInheritDocCodeConverter())
                .WriteWithConverter(functionDefinition.IsDeprecated ? new AttributeObsoleteCodeConverter(functionDefinition.Deprecated) : null)
                .WriteLine($"public virtual {MethodReturnType} {methodNamePrefix}{functionDefinition.Name.ToCapitalCase()}({MethodArguments})")
                .WriteStartBlock()
                .WriteLine($"return {ClientMethodInvoke}(\"{functionDefinition.Name}\"{ClientMethodInvokeArguments});")
                .WriteEndBlock();
        }
    }
}
