using System;
using WebExtension.Net.Generator.CodeGeneration.CodeConverters;
using WebExtension.Net.Generator.Models.ClrTypes;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverterFactories
{
    public class MultitypeCodeConverterFactory : ICodeConverterFactory
    {
        public void AddInterfaceConvertersToCodeFile(ClrTypeInfo clrTypeInfo, CodeFile codeFile)
        {
            throw new NotImplementedException();
        }

        public void AddConvertersToCodeFile(ClrTypeInfo clrTypeInfo, CodeFile codeFile)
        {
            if (clrTypeInfo.TypeChoices is null)
            {
                throw new InvalidOperationException("Multitype type must have type choices.");
            }

            codeFile.Comments.Add(new CommentCodeConverter("Multitype Class"));
            codeFile.Comments.Add(new CommentSummaryCodeConverter(clrTypeInfo.Description));

            if (clrTypeInfo.IsObsolete)
            {
                codeFile.Attributes.Add(new AttributeObsoleteCodeConverter(clrTypeInfo.ObsoleteMessage));
            }

            codeFile.Properties.Add(new MultitypeCurrentValuePropertyCodeConverter());

            codeFile.Constructors.Add(new MultitypeConstructorCodeConverter(clrTypeInfo.CSharpName, clrTypeInfo.TypeChoices));

            codeFile.Methods.Add(new MultitypeToStringMethodCodeConverter());
        }
    }
}
