using WebExtension.Net.Generator.Extensions;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public class CommentSummaryCodeConverter : ICodeConverter, ICodeSectionConverter
    {
        private readonly string? content;

        public CommentSummaryCodeConverter(string? content)
        {
            this.content = content;
        }

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            WriteTo(codeWriter.Declaration, options);
        }

        public void WriteTo(CodeSectionWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.WriteLine($"/// <summary>{content.ToXmlContent()}</summary>");
        }
    }
}
