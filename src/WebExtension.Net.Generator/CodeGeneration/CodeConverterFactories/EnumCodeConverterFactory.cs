using System;
using WebExtension.Net.Generator.CodeGeneration.CodeConverters;
using WebExtension.Net.Generator.Models.Entities;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverterFactories
{
    public class EnumCodeConverterFactory : ICodeConverterFactory<EnumEntity>
    {
        public void AddInterfaceConvertersToCodeFile(EnumEntity classEntity, CodeFile codeFile)
        {
            throw new NotImplementedException();
        }

        public void AddConvertersToCodeFile(EnumEntity enumEntity, CodeFile codeFile)
        {
            codeFile.UsingNamespaces.Add("System.Text.Json.Serialization");
            codeFile.Comments.Add(new CommentSummaryCodeConverter(enumEntity.Description));

            if (enumEntity.IsDeprecated)
            {
                codeFile.Attributes.Add(new AttributeObsoleteCodeConverter(enumEntity.Deprecated));
            }
            codeFile.Attributes.Add(new AttributeCodeConverter($"JsonConverter(typeof(EnumStringConverter<{enumEntity.FormattedName}>))"));

            foreach (var enumValueDefinition in enumEntity.EnumValues)
            {
                codeFile.Properties.Add(new EnumPropertyCodeConverter(enumValueDefinition));
            }
        }
    }
}
