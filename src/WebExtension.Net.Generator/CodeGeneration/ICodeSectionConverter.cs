namespace WebExtension.Net.Generator.CodeGeneration
{
    public interface ICodeSectionConverter
    {
        void WriteTo(CodeSectionWriter codeWriter, CodeWriterOptions options);
    }
}