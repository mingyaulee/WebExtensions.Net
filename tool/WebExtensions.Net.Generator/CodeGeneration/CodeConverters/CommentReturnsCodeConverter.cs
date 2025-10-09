using WebExtensions.Net.Generator.Extensions;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class CommentReturnsCodeConverter(string? description) : ICodeSectionConverter
    {
        private readonly string? description = description;

        public void WriteTo(ICodeSectionWriter codeWriter, CodeWriterOptions options)
            => codeWriter.WriteLine($"/// <returns>{description.ToXmlContent()}</returns>");
    }
}
