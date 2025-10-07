using System;
using WebExtensions.Net.Generator.CodeGeneration.CodeConverters;
using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverterFactories
{
    public class CombinedCallbackParameterCodeConverterFactory : ICodeConverterFactory
    {
        public void AddInterfaceConvertersToCodeFile(ClrTypeInfo clrTypeInfo, CodeFile codeFile)
            => throw new NotImplementedException();

        public void AddConvertersToCodeFile(ClrTypeInfo clrTypeInfo, CodeFile codeFile)
        {
            codeFile.UsingNamespaces.Add("System.Text.Json.Serialization");
            codeFile.Comments.Add(new CommentCodeConverter("Combined Callback Parameter Class"));
            codeFile.Comments.Add(new CommentSummaryCodeConverter(clrTypeInfo.Description));

            if (clrTypeInfo.IsObsolete)
            {
                codeFile.Attributes.Add(new AttributeObsoleteCodeConverter(clrTypeInfo.ObsoleteMessage));
            }
            codeFile.Attributes.Add(new AttributeCodeConverter($"JsonConverter(typeof(CombinedCallbackParameterJsonConverter<{clrTypeInfo.CSharpName}>))"));

            codeFile.Constructors.Add(new CombinedCallbackParameterConstructorCodeConverter(clrTypeInfo.CSharpName, clrTypeInfo.Properties));

            foreach (var property in clrTypeInfo.Properties)
            {
                codeFile.Properties.Add(new TypePropertyCodeConverter(property));
            }
        }
    }
}
