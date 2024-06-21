namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class AttributeCodeConverter : ICodeConverter, ICodeSectionConverter
    {
        private readonly string attribute;

        public AttributeCodeConverter(string attribute)
        {
            this.attribute = attribute;
        }

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            WriteTo(codeWriter.Declaration, options);
        }

        public virtual void WriteTo(CodeSectionWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.WriteLine($"[{attribute}]");
        }
    }
}
