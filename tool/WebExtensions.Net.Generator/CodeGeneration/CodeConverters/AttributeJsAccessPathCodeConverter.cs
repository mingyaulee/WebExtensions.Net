namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class AttributeJsAccessPathCodeConverter : AttributeCodeConverter
    {
        public AttributeJsAccessPathCodeConverter(string? accessPath) : base($"JsAccessPath(\"{accessPath}\")")
        {
        }

        public override void WriteTo(CodeSectionWriter codeWriter, CodeWriterOptions options)
        {
            base.WriteTo(codeWriter, options);
            codeWriter.WriteUsingStatement("JsBind.Net");
        }
    }
}
