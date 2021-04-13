using System.Linq;
using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public class TypeMethodCodeConverter : BaseMethodCodeConverter
    {
        private readonly FunctionDefinition functionDefinition;

        public TypeMethodCodeConverter(FunctionDefinition functionDefinition) : base(functionDefinition)
        {
            this.functionDefinition = functionDefinition;
        }

        public override void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            if (functionDefinition.Name is null)
            {
                return;
            }

            if (functionDefinition.Name is null)
            {
                return;
            }

            codeWriter.WriteUsingStatement(UsingNamespaces);

            codeWriter.PublicMethods
                .WriteWithConverter(new CommentSummaryCodeConverter(functionDefinition.Description))
                .WriteWithConverters(ParameterDefinitions.Select(parameterDefinition => new CommentParamCodeSectionConverter(parameterDefinition.Name, parameterDefinition.Description)))
                .WriteWithConverter(ReturnDefinition is not null ? new CommentReturnsCodeConverter(ReturnDefinition.Description) : null)
                .WriteWithConverter(functionDefinition.IsDeprecated ? new AttributeObsoleteCodeConverter(functionDefinition.Deprecated) : null)
                .WriteLine($"public virtual {MethodReturnType} {functionDefinition.Name.ToCapitalCase()}({MethodArguments})")
                .WriteStartBlock()
                .WriteLine($"return {ClientMethodInvoke}(\"{functionDefinition.Name}\"{ClientMethodInvokeArguments});")
                .WriteEndBlock();
        }
    }
}
