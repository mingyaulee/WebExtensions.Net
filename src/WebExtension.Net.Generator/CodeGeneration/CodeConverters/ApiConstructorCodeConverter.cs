namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public class ApiConstructorCodeConverter : ICodeConverter
    {
        private readonly string className;
        private readonly string apiName;

        public ApiConstructorCodeConverter(string className, string apiName)
        {
            this.className = className;
            this.apiName = apiName;
        }

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.Constructors
                .WriteWithConverter(new CommentSummaryCodeConverter($"Creates a new instance of <see cref=\"{className}\" />."))
                .WriteWithConverter(new CommentParamCodeSectionConverter("webExtensionJSRuntime", "Web Extension JS Runtime"))
                .WriteLine($"public {className}(WebExtensionJSRuntime webExtensionJSRuntime) : base(webExtensionJSRuntime, \"{apiName}\")")
                .WriteStartBlock()
                .WriteEndBlock();
        }
    }
}
