namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class ApiConstructorCodeConverter(string apiName) : ICodeConverter
    {
        private readonly string apiName = apiName;

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.WriteUsingStatement("JsBind.Net");

            codeWriter.Declaration
                .WriteWithConverter(new CommentParamCodeSectionConverter("jsRuntime", "The JS runtime adapter."))
                .WriteWithConverter(new CommentParamCodeSectionConverter("accessPath", "The base API access path."))
                .WritePrimaryConstructor(["IJsRuntimeAdapter jsRuntime", "string accessPath"], ["jsRuntime", $"AccessPaths.Combine(accessPath, \"{apiName}\")"]);
        }
    }
}
