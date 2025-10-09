namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class AttributeJsAccessPathCodeConverter(string? accessPath) : AttributeCodeConverter($"JsAccessPath(\"{accessPath}\")")
    {
        public override void WriteTo(ICodeSectionWriter codeWriter, CodeWriterOptions options)
        {
            base.WriteTo(codeWriter, options);
            codeWriter.WriteUsingStatement("JsBind.Net");
        }
    }
}
