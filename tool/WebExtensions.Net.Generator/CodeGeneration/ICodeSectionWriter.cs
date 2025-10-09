namespace WebExtensions.Net.Generator.CodeGeneration
{
    public interface ICodeSectionWriter
    {
        void WriteLine(string? line);
        void WriteUsingStatement(string @namespace);
    }
}
