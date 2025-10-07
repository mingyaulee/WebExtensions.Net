using WebExtensions.Net.Generator.Extensions;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class CommentSummaryCodeConverter(string? content) : ICodeConverter, ICodeSectionConverter
    {
        private readonly string? content = content;

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
            => WriteTo(codeWriter.Declaration, options);

        public void WriteTo(CodeSectionWriter codeWriter, CodeWriterOptions options)
            => codeWriter.WriteLine($"/// <summary>{content.ToXmlContent()}</summary>");
    }
}
