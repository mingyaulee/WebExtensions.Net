using System;
using WebExtension.Net.Generator.CodeGeneration.CodeConverters;
using WebExtension.Net.Generator.Models.ClrTypes;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverterFactories
{
    public class EnumCodeConverterFactory : ICodeConverterFactory
    {
        public void AddInterfaceConvertersToCodeFile(ClrTypeInfo clrTypeInfo, CodeFile codeFile)
        {
            throw new NotImplementedException();
        }

        public void AddConvertersToCodeFile(ClrTypeInfo clrTypeInfo, CodeFile codeFile)
        {
            if (clrTypeInfo.EnumValues is null)
            {
                throw new InvalidOperationException("Enum type must have enum values.");
            }

            codeFile.UsingNamespaces.Add("System.Text.Json.Serialization");
            codeFile.Comments.Add(new CommentSummaryCodeConverter(clrTypeInfo.Description));

            if (clrTypeInfo.IsObsolete)
            {
                codeFile.Attributes.Add(new AttributeObsoleteCodeConverter(clrTypeInfo.ObsoleteMessage));
            }
            codeFile.Attributes.Add(new AttributeCodeConverter($"JsonConverter(typeof(EnumStringConverter<{clrTypeInfo.CSharpName}>))"));

            foreach (var enumValue in clrTypeInfo.EnumValues)
            {
                codeFile.Properties.Add(new EnumPropertyCodeConverter(enumValue));
            }
        }
    }
}
