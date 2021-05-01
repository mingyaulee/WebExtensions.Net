using System.Linq;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public class CodeFileConverter : ICodeConverter
    {
        public CodeFile CodeFile { get; }

        public CodeFileConverter(CodeFile codeFile)
        {
            CodeFile = codeFile;
        }

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            WriteUsingStatements(codeWriter, options);
            WriteCodeConverters(codeWriter, options);
            WriteCodeFile((CodeFileWriter)codeWriter, options);
        }

        private void WriteUsingStatements(CodeWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.WriteUsingStatement(CodeFile.UsingNamespaces);
        }

        private void WriteCodeConverters(CodeWriter codeWriter, CodeWriterOptions options)
        {
            foreach (var comment in CodeFile.Comments)
            {
                comment.WriteTo(codeWriter, options);
            }

            foreach (var attribute in CodeFile.Attributes)
            {
                attribute.WriteTo(codeWriter, options);
            }

            if (CodeFile.Constructors.Any())
            {
                foreach (var constructor in CodeFile.Constructors)
                {
                    constructor.WriteTo(codeWriter, options);
                }
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

        private void WriteCodeFile(CodeFileWriter codeFileWriter, CodeWriterOptions options)
        {
            codeFileWriter.WriteUsingStatements();
            codeFileWriter.WriteNamespace(CodeFile.Namespace);

            // start namespace block
            codeFileWriter.WriteStartBlock();
            codeFileWriter.Declaration.WriteLine(CodeFile.Declaration);
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
