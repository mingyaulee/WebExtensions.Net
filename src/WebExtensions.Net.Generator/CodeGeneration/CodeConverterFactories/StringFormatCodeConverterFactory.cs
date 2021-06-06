using System;
using WebExtension.Net.Generator.CodeGeneration.CodeConverters;
using WebExtension.Net.Generator.Models.ClrTypes;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverterFactories
{
    public class StringFormatCodeConverterFactory : ICodeConverterFactory
    {
        public void AddInterfaceConvertersToCodeFile(ClrTypeInfo clrTypeInfo, CodeFile codeFile)
        {
            throw new NotImplementedException();
        }

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

            var stringFormat = clrTypeInfo.Metadata.ContainsKey(Constants.TypeMetadata.StringFormat) ? (string)clrTypeInfo.Metadata[Constants.TypeMetadata.StringFormat] : null;
            var stringPattern = clrTypeInfo.Metadata.ContainsKey(Constants.TypeMetadata.StringPattern) ? (string)clrTypeInfo.Metadata[Constants.TypeMetadata.StringPattern] : null;
            codeFile.Constructors.Add(new StringFormatConstructorCodeConverter(clrTypeInfo.CSharpName, stringFormat, stringPattern));

            codeFile.Methods.Add(new StringFormatCastOperatorCodeConverter(clrTypeInfo.CSharpName));
        }
    }
}
