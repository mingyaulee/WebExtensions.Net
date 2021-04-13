using System.Linq;
using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public class ApiInterfaceMethodCodeConverter : BaseMethodCodeConverter
    {
        private readonly FunctionDefinition functionDefinition;

        public ApiInterfaceMethodCodeConverter(FunctionDefinition functionDefinition) : base(functionDefinition)
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
                .WriteWithConverter(new CommentSummaryCodeConverter(functionDefinition.Description))
                .WriteWithConverters(ParameterDefinitions.Select(parameterDefinition => new CommentParamCodeSectionConverter(parameterDefinition.Name, parameterDefinition.Description)))
                .WriteWithConverter(ReturnDefinition is not null ? new CommentReturnsCodeConverter(ReturnDefinition.Description) : null)
                .WriteWithConverter(functionDefinition.IsDeprecated ? new AttributeObsoleteCodeConverter(functionDefinition.Deprecated) : null)
                .WriteLine($"{MethodReturnType} {methodNamePrefix}{functionDefinition.Name.ToCapitalCase()}({MethodArguments});");
        }
    }
}
