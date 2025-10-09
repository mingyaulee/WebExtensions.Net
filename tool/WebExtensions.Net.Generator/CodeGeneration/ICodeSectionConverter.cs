namespace WebExtensions.Net.Generator.CodeGeneration
{
    public interface ICodeSectionConverter
    {
        void WriteTo(ICodeSectionWriter codeWriter, CodeWriterOptions options);
    }
}
