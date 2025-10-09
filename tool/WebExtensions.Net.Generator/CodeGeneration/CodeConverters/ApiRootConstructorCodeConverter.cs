namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class ApiRootConstructorCodeConverter : ICodeConverter
    {
        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.WriteUsingStatement("JsBind.Net");

            codeWriter.Declaration
                .WriteWithConverter(new CommentParamCodeSectionConverter("jsRuntime", "The JS runtime adapter."))
                .WritePrimaryConstructor(["IJsRuntimeAdapter jsRuntime"], ["jsRuntime", "\"browser\""]);
        }
    }
}
