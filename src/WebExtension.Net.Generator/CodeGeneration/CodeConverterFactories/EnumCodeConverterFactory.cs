using System;
using WebExtension.Net.Generator.CodeGeneration.CodeConverters;
using WebExtension.Net.Generator.Models.Entities;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverterFactories
{
    public class EnumCodeConverterFactory : ICodeConverterFactory<EnumEntity>
    {
        public void AddInterfaceConvertersToCodeFile(EnumEntity entity, CodeFile codeFile)
        {
            throw new NotImplementedException();
        }

        public void AddConvertersToCodeFile(EnumEntity entity, CodeFile codeFile)
        {
            codeFile.UsingNamespaces.Add("System.Text.Json.Serialization");
            codeFile.Comments.Add(new CommentSummaryCodeConverter(entity.Description));

            if (entity.IsDeprecated)
            {
                codeFile.Attributes.Add(new AttributeObsoleteCodeConverter(entity.Deprecated));
            }
            codeFile.Attributes.Add(new AttributeCodeConverter($"JsonConverter(typeof(EnumStringConverter<{entity.FormattedName}>))"));

            foreach (var enumValueDefinition in entity.EnumValues)
            {
                codeFile.Properties.Add(new EnumPropertyCodeConverter(enumValueDefinition));
            }
        }
    }
}
