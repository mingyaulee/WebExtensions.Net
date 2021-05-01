using WebExtension.Net.Generator.Models.ClrTypes;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public class ApiPropertyCodeConverter : ICodeConverter
    {
        private readonly ClrPropertyInfo clrPropertyInfo;

        public ApiPropertyCodeConverter(ClrPropertyInfo clrPropertyInfo)
        {
            this.clrPropertyInfo = clrPropertyInfo;
        }

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            if (!clrPropertyInfo.IsConstant)
            {
                return;
            }

            codeWriter.PublicProperties
                .WriteWithConverter(new CommentInheritDocCodeConverter())
                .WriteLine($"public {clrPropertyInfo.PropertyType.CSharpName} {clrPropertyInfo.PublicName} => {clrPropertyInfo.ConstantValue};");
        }
    }
}
