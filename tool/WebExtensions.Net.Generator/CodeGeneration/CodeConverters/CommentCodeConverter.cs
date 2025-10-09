namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class CommentCodeConverter(string? content) : ICodeConverter, ICodeSectionConverter
    {
        private readonly string? content = content;

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
            => WriteTo(codeWriter.Declaration, options);

        public void WriteTo(ICodeSectionWriter codeWriter, CodeWriterOptions options)
            => codeWriter.WriteLine($"// {content}");
    }
}
