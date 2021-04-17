using System;
using WebExtension.Net.Generator.CodeGeneration.CodeConverters;
using WebExtension.Net.Generator.Models.Entities;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverterFactories
{
    public class StringFormatCodeConverterFactory : ICodeConverterFactory<ClassEntity>
    {
        public void AddInterfaceConvertersToCodeFile(ClassEntity entity, CodeFile codeFile)
        {
            throw new NotImplementedException();
        }

        public void AddConvertersToCodeFile(ClassEntity entity, CodeFile codeFile)
        {
            if (entity.TypeDefinition is null || entity.TypeDefinition.StringFormat is null)
            {
                return;
            }

            codeFile.Comments.Add(new CommentCodeConverter("String Format Class"));
            codeFile.Comments.Add(new CommentSummaryCodeConverter(entity.Description));

            if (entity.TypeDefinition.IsDeprecated)
            {
                codeFile.Attributes.Add(new AttributeObsoleteCodeConverter(entity.TypeDefinition.Deprecated));
            }

            codeFile.Constructors.Add(new StringFormatConstructorCodeConverter(entity.FormattedName, entity.TypeDefinition.StringFormat));
        }
    }
}
