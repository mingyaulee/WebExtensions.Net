namespace WebExtensions.Net.Generator.CodeGeneration
{
    public class DeclarationCodeSectionWriter(CodeSection codeSection, CodeWriterOptions codeWriterOptions, CodeWriter codeWriter) : BaseCodeSectionWriter<DeclarationCodeSectionWriter>(codeSection, codeWriterOptions, codeWriter)
    {
        private string? primaryConstructorParameters;
        private string? primaryConstructorBaseArguments;

        public void WritePrimaryConstructor(string[] parameters, string[]? baseArguments = null)
        {
            primaryConstructorParameters = $"({string.Join(", ", parameters)})";
            primaryConstructorBaseArguments = baseArguments is not null ? $"({string.Join(", ", baseArguments)})" : null;
        }

        public void WriteDeclaration(CodeFile codeFile)
            => WriteLine(string.Format(codeFile.Declaration, primaryConstructorParameters, primaryConstructorBaseArguments));
    }
}
