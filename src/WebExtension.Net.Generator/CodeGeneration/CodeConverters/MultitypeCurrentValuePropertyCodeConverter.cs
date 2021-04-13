namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public class MultitypeCurrentValuePropertyCodeConverter : ICodeConverter
    {
        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.Properties
                .WriteLine($"private readonly object currentValue = null;");
        }
    }
}
