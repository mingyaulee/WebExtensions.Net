﻿namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class CommentInheritDocCodeConverter : ICodeConverter, ICodeSectionConverter
    {
        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            WriteTo(codeWriter.Declaration, options);
        }

        public void WriteTo(CodeSectionWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.WriteLine("/// <inheritdoc />");
        }
    }
}
