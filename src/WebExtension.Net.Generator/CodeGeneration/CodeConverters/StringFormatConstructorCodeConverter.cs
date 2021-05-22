namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public class StringFormatConstructorCodeConverter : ICodeConverter
    {
        private readonly string className;
        private readonly string? stringFormat;
        private readonly string? stringPattern;

        public StringFormatConstructorCodeConverter(string className, string? stringFormat, string? stringPattern)
        {
            this.className = className;
            this.stringFormat = stringFormat;
            this.stringPattern = stringPattern?.Replace(@"\", @"\\");
        }

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.Properties
                .WriteLine($"private const string FORMAT = \"{stringFormat}\";")
                .WriteLine($"private const string PATTERN = \"{stringPattern}\";");

            codeWriter.Constructors
                .WriteWithConverter(new CommentSummaryCodeConverter($"Creates a new instance of <see cref=\"{className}\" />."))
                .WriteLine($"public {className}(string value) : base(value, FORMAT, PATTERN)")
                .WriteStartBlock()
                .WriteEndBlock();
        }
    }
}
