﻿namespace WebExtensions.Net.Generator.CodeGeneration
{
    public interface ICodeConverter
    {
        void WriteTo(CodeWriter codeWriter, CodeWriterOptions options);
    }
}