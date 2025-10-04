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
            codeWriter.WriteUsingStatement("JsBind.Net");

            codeWriter.Constructors
                .WriteWithConverter(new CommentSummaryCodeConverter($"Creates a new instance of <see cref=\"{className}\" />."))
                .WriteWithConverter(new CommentParamCodeSectionConverter("jsRuntime", "The JS runtime adapter."))
                .WriteWithConverter(new CommentParamCodeSectionConverter("accessPath", "The base API access path."))
                .WriteLine($"public {className}(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, \"{apiName}\"))")
                .WriteStartBlock()
                .WriteEndBlock();
        }
    }
}
