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
            codeFile.Comments.Add(new CommentCodeConverter("String Format Class"));
            codeFile.Comments.Add(new CommentSummaryCodeConverter(clrTypeInfo.Description));

            if (clrTypeInfo.IsObsolete)
            {
                codeFile.Attributes.Add(new AttributeObsoleteCodeConverter(clrTypeInfo.ObsoleteMessage));
            }

            var stringFormat = (string)clrTypeInfo.Metadata[Constants.TypeMetadata.StringFormat];
            codeFile.Constructors.Add(new StringFormatConstructorCodeConverter(clrTypeInfo.CSharpName, stringFormat));
        }
    }
}
