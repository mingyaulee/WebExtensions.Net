namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class AttributeObsoleteCodeConverter(string? obsoleteMessage) : ICodeConverter, ICodeSectionConverter
    {
        private readonly string? obsoleteMessage = obsoleteMessage;

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
            => WriteTo(codeWriter.Declaration, options);

        public void WriteTo(ICodeSectionWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.WriteUsingStatement("System");
            if (string.IsNullOrEmpty(obsoleteMessage) || "True".Equals(obsoleteMessage))
            {
                codeWriter.WriteLine($"[Obsolete(\"This has been marked as deprecated without a description message. Please refer to the summary comment or the official API documentation.\")]");
            }
            else
            {
                codeWriter.WriteLine($"[Obsolete(\"{obsoleteMessage}\")]");
            }
        }
    }
}
