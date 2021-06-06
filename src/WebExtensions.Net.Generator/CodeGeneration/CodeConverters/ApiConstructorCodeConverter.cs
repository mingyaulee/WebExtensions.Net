namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
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
                .WriteWithConverter(new CommentParamCodeSectionConverter("webExtensionsJSRuntime", "Web Extension JS Runtime"))
                .WriteLine($"public {className}(IWebExtensionsJSRuntime webExtensionsJSRuntime) : base(webExtensionsJSRuntime, \"{apiName}\")")
                .WriteStartBlock()
                .WriteEndBlock();
        }
    }
}
