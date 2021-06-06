using WebExtension.Net.Generator.Extensions;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public class CommentParamCodeSectionConverter : ICodeSectionConverter
    {
        private readonly string? paramName;
        private readonly string? description;

        public CommentParamCodeSectionConverter(string? paramName, string? description)
        {
            this.paramName = paramName;
            this.description = description;
        }

        public void WriteTo(CodeSectionWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.WriteLine($"/// <param name=\"{paramName}\">{description.ToXmlContent()}</param>");
        }
    }
}
