namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class StringFormatConstructorCodeConverter(string className, string? stringFormat, string? stringPattern) : ICodeConverter
    {
        private readonly string className = className;
        private readonly string? stringFormat = stringFormat;
        private readonly string? stringPattern = stringPattern?.Replace(@"\", @"\\");

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.Properties
                .WriteLine($"private const string FORMAT = \"{stringFormat}\";")
                .WriteLine($"private const string PATTERN = \"{stringPattern}\";");

            codeWriter.Declaration
                .WritePrimaryConstructor(["string value"], ["value", "FORMAT", "PATTERN"]);
        }
    }
}
