using System.Linq;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class CodeFileConverter(CodeFile codeFile) : ICodeConverter
    {
        public CodeFile CodeFile { get; } = codeFile;

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            WriteUsingStatements(codeWriter);
            WriteCodeConverters(codeWriter, options);
            WriteCodeFile((CodeFileWriter)codeWriter);
        }

        private void WriteUsingStatements(CodeWriter codeWriter)
            => codeWriter.WriteUsingStatement(CodeFile.UsingNamespaces);

        private void WriteCodeConverters(CodeWriter codeWriter, CodeWriterOptions options)
        {
            foreach (var comment in CodeFile.Comments)
            {
                comment.WriteTo(codeWriter, options);
            }

            if (CodeFile.Constructors.Any())
            {
                foreach (var constructor in CodeFile.Constructors)
                {
                    constructor.WriteTo(codeWriter, options);
                }
            }

            foreach (var attribute in CodeFile.Attributes)
            {
                attribute.WriteTo(codeWriter, options);
            }

            if (CodeFile.Properties.Any())
            {
                foreach (var property in CodeFile.Properties)
                {
                    property.WriteTo(codeWriter, options);
                }
            }

            if (CodeFile.Methods.Any())
            {
                foreach (var method in CodeFile.Methods)
                {
                    method.WriteTo(codeWriter, options);
                }
            }
        }

        private void WriteCodeFile(CodeFileWriter codeFileWriter)
        {
            codeFileWriter.WriteUsingStatements();
            codeFileWriter.WriteNamespace(CodeFile.Namespace);

            // start namespace block
            codeFileWriter.WriteStartBlock();
            codeFileWriter.WriteDeclarationSection();

            // start declaration block
            codeFileWriter.WriteStartBlock();

            codeFileWriter.WritePropertiesSection(ignoreNewLineInSection: true);
            codeFileWriter.WriteConstructorsSection();
            codeFileWriter.WritePublicPropertiesSection();
            codeFileWriter.WritePublicMethodsSection();
            codeFileWriter.WriteMethodsSection();

            // end declaration block
            codeFileWriter.WriteEndBlock();

            // end namespace block
            codeFileWriter.WriteEndBlock();
        }
    }
}
