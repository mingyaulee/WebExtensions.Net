namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class ApiRootConstructorCodeConverter : ICodeConverter
    {
        private readonly string apiRootName;

        public ApiRootConstructorCodeConverter(string apiRootName)
        {
            this.apiRootName = apiRootName;
        }

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.WriteUsingStatement("JsBind.Net");

            codeWriter.Constructors
                .WriteWithConverter(new CommentSummaryCodeConverter($"Creates a new instance of <see cref=\"{apiRootName}\" />."))
                .WriteWithConverter(new CommentParamCodeSectionConverter("jsRuntime", "The JS runtime adapter."))
                .WriteLine($"public {apiRootName}(IJsRuntimeAdapter jsRuntime) : base(jsRuntime, \"browser\")")
                .WriteStartBlock()
                .WriteEndBlock();
        }
    }
}
