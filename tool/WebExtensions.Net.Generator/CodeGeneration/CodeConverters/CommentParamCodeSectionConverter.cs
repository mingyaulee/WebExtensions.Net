using WebExtensions.Net.Generator.Extensions;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class CommentParamCodeSectionConverter(string? paramName, string? description) : ICodeSectionConverter
    {
        private readonly string? paramName = paramName;
        private readonly string? description = description;

        public void WriteTo(ICodeSectionWriter codeWriter, CodeWriterOptions options)
            => codeWriter.WriteLine($"/// <param name=\"{paramName}\">{description.ToXmlContent()}</param>");
    }
}
