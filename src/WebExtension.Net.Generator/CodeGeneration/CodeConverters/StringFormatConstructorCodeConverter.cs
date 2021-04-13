namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public class StringFormatConstructorCodeConverter : ICodeConverter
    {
        private readonly string className;
        private readonly string stringFormat;

        public StringFormatConstructorCodeConverter(string className, string stringFormat)
        {
            this.className = className;
            this.stringFormat = stringFormat;
        }

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.Properties
                .WriteLine($"private const string pattern = \"{stringFormat}\";");

            codeWriter.PublicProperties
                .WriteWithConverter(new CommentSummaryCodeConverter($"Creates a new instance of <see cref=\"{className}\" />."))
                .WriteLine($"public {className}(string value) : base(value, pattern)")
                .WriteStartBlock()
                .WriteEndBlock();
        }
    }
}
