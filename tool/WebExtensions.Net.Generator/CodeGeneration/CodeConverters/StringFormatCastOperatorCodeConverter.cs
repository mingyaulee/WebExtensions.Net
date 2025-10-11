namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters;

public class StringFormatCastOperatorCodeConverter(string className) : ICodeConverter
{
    private readonly string className = className;

    public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
    {
        codeWriter.PublicMethods
            .WriteWithConverter(new CommentSummaryCodeConverter($"Converts from <see cref=\"{className}\" /> to <see cref=\"string\" />."))
            .WriteWithConverter(new CommentParamCodeSectionConverter("value", "The value to convert from."))
            .WriteLine($"public static implicit operator string({className} value) => value.Value;");

        codeWriter.PublicMethods
            .WriteWithConverter(new CommentSummaryCodeConverter($"Converts from <see cref=\"string\" /> to <see cref=\"{className}\" />."))
            .WriteWithConverter(new CommentParamCodeSectionConverter("value", "The value to convert from."))
            .WriteLine($"public static implicit operator {className}(string value) => new(value);");
    }
}
