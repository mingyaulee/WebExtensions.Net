using System;
using WebExtension.Net.Generator.CodeGeneration.CodeConverters;
using WebExtension.Net.Generator.Models.Entities;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverterFactories
{
    public class MultitypeCodeConverterFactory : ICodeConverterFactory<ClassEntity>
    {
        public void AddInterfaceConvertersToCodeFile(ClassEntity entity, CodeFile codeFile)
        {
            throw new NotImplementedException();
        }

        public void AddConvertersToCodeFile(ClassEntity entity, CodeFile codeFile)
        {
            if (entity.TypeDefinition is null || entity.TypeDefinition.TypeChoices is null)
            {
                return;
            }

            codeFile.Comments.Add(new CommentCodeConverter("Multitype Class"));
            codeFile.Comments.Add(new CommentSummaryCodeConverter(entity.Description));

            if (entity.TypeDefinition.IsDeprecated)
            {
                codeFile.Attributes.Add(new AttributeObsoleteCodeConverter(entity.TypeDefinition.Deprecated));
            }

            codeFile.Properties.Add(new MultitypeCurrentValuePropertyCodeConverter());

            codeFile.Constructors.Add(new MultitypeConstructorCodeConverter(entity.FormattedName, entity.TypeDefinition.TypeChoices));

            codeFile.Methods.Add(new MultitypeToStringMethodCodeConverter());
        }
    }
}
