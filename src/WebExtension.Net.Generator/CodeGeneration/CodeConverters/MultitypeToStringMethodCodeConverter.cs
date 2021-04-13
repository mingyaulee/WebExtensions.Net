namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public class MultitypeToStringMethodCodeConverter : ICodeConverter
    {
        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.PublicMethods
                .WriteWithConverter(new CommentInheritDocCodeConverter())
                .WriteLine($"public override string ToString()")
                .WriteStartBlock()
                .WriteLine("return currentValue?.ToString();")
                .WriteEndBlock();
        }
    }
}
