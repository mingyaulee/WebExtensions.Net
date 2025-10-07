namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class AttributeCodeConverter(string attribute) : ICodeConverter, ICodeSectionConverter
    {
        private readonly string attribute = attribute;

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
            => WriteTo(codeWriter.Declaration, options);

        public virtual void WriteTo(CodeSectionWriter codeWriter, CodeWriterOptions options)
            => codeWriter.WriteLine($"[{attribute}]");
    }
}
