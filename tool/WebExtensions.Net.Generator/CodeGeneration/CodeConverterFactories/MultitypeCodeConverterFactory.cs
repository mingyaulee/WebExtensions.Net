using System;
using WebExtensions.Net.Generator.CodeGeneration.CodeConverters;
using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverterFactories
{
    public class MultitypeCodeConverterFactory : ICodeConverterFactory
    {
        public void AddInterfaceConvertersToCodeFile(ClrTypeInfo clrTypeInfo, CodeFile codeFile)
            => throw new NotImplementedException();

        public void AddConvertersToCodeFile(ClrTypeInfo clrTypeInfo, CodeFile codeFile)
        {
            if (clrTypeInfo.TypeChoices is null)
            {
                throw new InvalidOperationException("Multitype type must have type choices.");
            }

            codeFile.UsingNamespaces.Add("System.Text.Json.Serialization");
            codeFile.Comments.Add(new CommentCodeConverter("Multitype Class"));
            codeFile.Comments.Add(new CommentSummaryCodeConverter(clrTypeInfo.Description));

            if (clrTypeInfo.IsObsolete)
            {
                codeFile.Attributes.Add(new AttributeObsoleteCodeConverter(clrTypeInfo.ObsoleteMessage));
            }
            codeFile.Attributes.Add(new AttributeCodeConverter($"JsonConverter(typeof(MultiTypeJsonConverter<{clrTypeInfo.CSharpName}>))"));

            codeFile.Constructors.Add(new MultitypeConstructorCodeConverter(clrTypeInfo.CSharpName, clrTypeInfo.TypeChoices));
        }
    }
}
