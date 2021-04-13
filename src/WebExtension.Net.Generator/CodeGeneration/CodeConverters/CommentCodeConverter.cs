namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public class CommentCodeConverter : ICodeConverter, ICodeSectionConverter
    {
        private readonly string? content;

        public CommentCodeConverter(string? content)
        {
            this.content = content;
        }

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            WriteTo(codeWriter.Declaration, options);
        }

        public void WriteTo(CodeSectionWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.WriteLine($"// {content}");
        }
    }
}
