using System;
using WebExtensions.Net.Generator.CodeGeneration.CodeConverters;
using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverterFactories
{
    public class TypeCodeConverterFactory : ICodeConverterFactory
    {
        public void AddInterfaceConvertersToCodeFile(ClrTypeInfo clrTypeInfo, CodeFile codeFile)
        {
            throw new NotImplementedException();
        }

        public void AddConvertersToCodeFile(ClrTypeInfo clrTypeInfo, CodeFile codeFile)
        {
            codeFile.Comments.Add(new CommentCodeConverter("Type Class"));
            codeFile.Comments.Add(new CommentSummaryCodeConverter(clrTypeInfo.Description));

            if (clrTypeInfo.IsObsolete)
            {
                codeFile.Attributes.Add(new AttributeObsoleteCodeConverter(clrTypeInfo.ObsoleteMessage));
            }

            foreach (var property in clrTypeInfo.Properties)
            {
                codeFile.Properties.Add(new TypePropertyCodeConverter(property));
            }

            foreach (var method in clrTypeInfo.Methods)
            {
                codeFile.Methods.Add(new TypeMethodCodeConverter(method));
            }
        }
    }
}
