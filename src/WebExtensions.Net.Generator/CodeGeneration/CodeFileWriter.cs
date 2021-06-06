using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebExtensions.Net.Generator.CodeGeneration
{
    public class CodeFileWriter : CodeWriter
    {
        private const int INDENTATION = 4;
        private readonly string filePath;
        private readonly CodeFile codeFile;
        private readonly CodeWriterOptions codeWriterOptions;
        private readonly StringBuilder fileContent;
        private int currentIndentation = 0;
        private bool appendLine = false;

        protected override ISet<string> UsingNamespaces { get; }

        public CodeFileWriter(string filePath, CodeFile codeFile, CodeWriterOptions codeWriterOptions) : base(codeWriterOptions)
        {
            this.filePath = filePath;
            this.codeFile = codeFile;
            this.codeWriterOptions = codeWriterOptions;
            UsingNamespaces = codeFile.UsingNamespaces;
            fileContent = new StringBuilder();
        }

        public void WriteUsingStatements()
        {
            var usingNamespaces = UsingNamespaces
                .Where(usingNamespace => codeFile.Namespace != usingNamespace)
                .Select(usingNamespace => usingNamespace.Replace(Constants.RelativeNamespaceToken, codeWriterOptions.RootNamespace))
                .OrderBy(usingNamespace => usingNamespace)
                .ToArray();
            if (usingNamespaces.Any())
            {
                AppendLineIfNeeded();
                foreach (var usingNamespace in usingNamespaces)
                {
                    WriteIndentation();
                    Write($"using {usingNamespace};");
                    WriteNewLine();
                }
                appendLine = true;
            }
        }

        public void WriteNamespace(string @namespace)
        {
            AppendLineIfNeeded();
            WriteIndentation();
            @namespace = @namespace.Replace(Constants.RelativeNamespaceToken, codeWriterOptions.RootNamespace);
            Write($"namespace {@namespace}");
            WriteNewLine();
        }

        public void WriteDeclarationSection(bool ignoreNewLineInSection = false)
        {
            WriteSection(DeclarationSection, ignoreNewLineInSection);
            appendLine = false;
        }

        public void WriteConstructorsSection(bool ignoreNewLineInSection = false)
        {
            WriteSection(ConstructorsSection, ignoreNewLineInSection);
        }

        public void WritePropertiesSection(bool ignoreNewLineInSection = false)
        {
            WriteSection(PropertiesSection, ignoreNewLineInSection);
        }

        public void WritePublicPropertiesSection(bool ignoreNewLineInSection = false)
        {
            WriteSection(PublicPropertiesSection, ignoreNewLineInSection);
        }

        public void WriteMethodsSection(bool ignoreNewLineInSection = false)
        {
            WriteSection(MethodsSection, ignoreNewLineInSection);
            appendLine = true;
        }

        public void WritePublicMethodsSection(bool ignoreNewLineInSection = false)
        {
            WriteSection(PublicMethodsSection, ignoreNewLineInSection);
            appendLine = true;
        }

        public void WriteStartBlock()
        {
            WriteIndentation();
            Write("{");
            WriteNewLine();
            currentIndentation += INDENTATION;
        }

        public void WriteEndBlock()
        {
            currentIndentation -= INDENTATION;
            WriteIndentation();
            Write("}");
            WriteNewLine();
        }

        private void WriteSection(CodeSection section, bool ignoreNewLineInSection)
        {
            if (section.Lines.Any())
            {
                AppendLineIfNeeded();
                foreach (var line in section.Lines)
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        if (!ignoreNewLineInSection)
                        {
                            appendLine = true;
                        }
                        continue;
                    }
                    AppendLineIfNeeded();
                    WriteIndentation();
                    fileContent.AppendLine(line);
                }
                appendLine = true;
            }
        }

        private void WriteNewLine()
        {
            fileContent.AppendLine();
        }

        private void WriteIndentation()
        {
            if (currentIndentation > 0)
            {
                Write(string.Empty.PadRight(currentIndentation, ' '));
            }
        }

        private void Write(string str)
        {
            fileContent.Append(str);
        }

        private void AppendLineIfNeeded()
        {
            if (appendLine)
            {
                WriteNewLine();
                appendLine = false;
            }
        }

        public void Flush()
        {
            File.WriteAllText(filePath, fileContent.ToString());
        }
    }
}
