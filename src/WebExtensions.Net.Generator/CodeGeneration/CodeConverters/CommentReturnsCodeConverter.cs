using WebExtension.Net.Generator.Extensions;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public class CommentReturnsCodeConverter : ICodeSectionConverter
    {
        private readonly string? description;

        public CommentReturnsCodeConverter(string? description)
        {
            this.description = description;
        }

        public void WriteTo(CodeSectionWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.WriteLine($"/// <returns>{description.ToXmlContent()}</returns>");
        }
    }
}
