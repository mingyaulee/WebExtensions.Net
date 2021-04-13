using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public class EnumPropertyCodeConverter : ICodeConverter
    {
        private readonly EnumValueDefinition enumValueDefinition;

        public EnumPropertyCodeConverter(EnumValueDefinition enumValueDefinition)
        {
            this.enumValueDefinition = enumValueDefinition;
        }

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            if (enumValueDefinition.Name is null)
            {
                return;
            }

            var sanitizedValueName = SanitizeValueName(enumValueDefinition.Name.ToCapitalCase());
            codeWriter.PublicProperties
                .WriteWithConverter(new CommentSummaryCodeConverter(enumValueDefinition.Description ?? enumValueDefinition.Name))
                .WriteLine($"[EnumValue(\"{enumValueDefinition.Name}\")]")
                .WriteLine($"{sanitizedValueName},");
        }

        private static string SanitizeValueName(string valueName)
        {
            return valueName.Replace("-", "_");
        }
    }
}
