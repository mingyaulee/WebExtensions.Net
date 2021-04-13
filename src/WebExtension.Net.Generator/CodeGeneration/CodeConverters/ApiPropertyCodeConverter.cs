using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public class ApiPropertyCodeConverter : BasePropertyCodeConverter
    {
        private readonly string propertyName;

        public ApiPropertyCodeConverter(string propertyName, PropertyDefinition propertyDefinition) : base(propertyDefinition)
        {
            this.propertyName = propertyName;
        }

        public override void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            if (!PropertyDefinition.IsConstant)
            {
                return;
            }

            codeWriter.WriteUsingStatement(UsingNamespaces);

            codeWriter.PublicProperties
                .WriteWithConverter(new CommentInheritDocCodeConverter())
                .WriteLine($"public {PropertyType} {propertyName.ToCapitalCase()} => {PropertyDefinition.ConstantValue};");
        }
    }
}
