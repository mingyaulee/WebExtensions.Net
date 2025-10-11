using System;
using WebExtensions.Net.Generator.CodeGeneration.CodeConverters;
using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverterFactories;

public class StringFormatCodeConverterFactory : ICodeConverterFactory
{
    public void AddInterfaceConvertersToCodeFile(ClrTypeInfo clrTypeInfo, CodeFile codeFile)
        => throw new NotImplementedException();

    public void AddConvertersToCodeFile(ClrTypeInfo clrTypeInfo, CodeFile codeFile)
    {
        codeFile.UsingNamespaces.Add("System.Text.Json.Serialization");
        codeFile.Comments.Add(new CommentCodeConverter("String Format Class"));
        codeFile.Comments.Add(new CommentSummaryCodeConverter(clrTypeInfo.Description));

        if (clrTypeInfo.IsObsolete)
        {
            codeFile.Attributes.Add(new AttributeObsoleteCodeConverter(clrTypeInfo.ObsoleteMessage));
        }

        codeFile.Attributes.Add(new AttributeCodeConverter($"JsonConverter(typeof(StringFormatJsonConverter<{clrTypeInfo.CSharpName}>))"));

        var stringFormat = clrTypeInfo.Metadata.TryGetValue(Constants.TypeMetadata.StringFormat, out var stringFormatObj) ? (string)stringFormatObj : null;
        var stringPattern = clrTypeInfo.Metadata.TryGetValue(Constants.TypeMetadata.StringPattern, out var stringPatternObj) ? (string)stringPatternObj : null;
        codeFile.Constructors.Add(new StringFormatConstructorCodeConverter(stringFormat, stringPattern));

        codeFile.Methods.Add(new StringFormatCastOperatorCodeConverter(clrTypeInfo.CSharpName));
    }
}
