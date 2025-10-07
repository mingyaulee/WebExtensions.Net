using System.Collections.Generic;

namespace WebExtensions.Net.Generator.CodeGeneration
{
    public class CodeSectionWriter(CodeSection codeSection, CodeWriterOptions codeWriterOptions, CodeWriter codeWriter)
    {
        private const int INDENTATION = 4;
        private readonly CodeSection codeSection = codeSection;
        private readonly CodeWriterOptions codeWriterOptions = codeWriterOptions;
        private readonly CodeWriter codeWriter = codeWriter;
        private int appendLine = 0;

        public void WriteUsingStatement(string @namespace)
            => codeWriter.WriteUsingStatement(@namespace);

        public void WriteUsingStatement(IEnumerable<string> namespaces)
            => codeWriter.WriteUsingStatement(namespaces);

        public CodeSectionWriter WriteLine(string? line)
        {
            if (line is null)
            {
                return this;
            }
            WriteIndentation();
            Write(line);
            WriteNewLine();
            return this;
        }

        public CodeSectionWriter WriteLines(IEnumerable<string?> lines)
        {
            foreach (var line in lines)
            {
                WriteLine(line);
            }
            return this;
        }

        public CodeSectionWriter WriteStartBlock()
        {
            WriteIndentation();
            Write("{");
            WriteNewLine();
            codeSection.Indentation += INDENTATION;
            return this;
        }

        public CodeSectionWriter WriteEndBlock()
        {
            codeSection.Indentation -= INDENTATION;
            WriteIndentation();
            Write("}");
            WriteNewLine();
            return this;
        }

        public CodeSectionWriter WriteWithConverter(ICodeSectionConverter? codeSectionConverter)
        {
            codeSectionConverter?.WriteTo(this, codeWriterOptions);
            return this;
        }

        public CodeSectionWriter WriteWithConverters(IEnumerable<ICodeSectionConverter>? codeSectionConverters)
        {
            if (codeSectionConverters is not null)
            {
                foreach (var codeSectionConverter in codeSectionConverters)
                {
                    codeSectionConverter.WriteTo(this, codeWriterOptions);
                }
            }
            return this;
        }

        public CodeSectionWriter WriteNewLine()
        {
            appendLine++;
            return this;
        }

        private void WriteIndentation()
        {
            if (codeSection.Indentation > 0)
            {
                Write(string.Empty.PadRight(codeSection.Indentation, ' '));
            }
        }

        private void Write(string str)
        {
            while (appendLine > 0)
            {
                appendLine--;
                codeSection.Lines.Add(string.Empty);
            }
            if (codeSection.Lines.Count == 0)
            {
                codeSection.Lines.Add(str);
            }
            else
            {
                var lastIndex = codeSection.Lines.Count - 1;
                codeSection.Lines[lastIndex] += str;
            }
        }
    }
}
