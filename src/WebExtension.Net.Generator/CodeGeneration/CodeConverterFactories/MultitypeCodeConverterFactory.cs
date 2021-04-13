using System;
using WebExtension.Net.Generator.CodeGeneration.CodeConverters;
using WebExtension.Net.Generator.Models.Entities;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverterFactories
{
    public class MultitypeCodeConverterFactory : ICodeConverterFactory<ClassEntity>
    {
        public void AddInterfaceConvertersToCodeFile(ClassEntity classEntity, CodeFile codeFile)
        {
            throw new NotImplementedException();
        }

        public void AddConvertersToCodeFile(ClassEntity classEntity, CodeFile codeFile)
        {
            if (classEntity.TypeDefinition is null || classEntity.TypeDefinition.TypeChoices is null)
            {
                return;
            }

            codeFile.Comments.Add(new CommentCodeConverter("Multitype Class"));
            codeFile.Comments.Add(new CommentSummaryCodeConverter(classEntity.Description));

            if (classEntity.TypeDefinition.IsDeprecated)
            {
                codeFile.Attributes.Add(new AttributeObsoleteCodeConverter(classEntity.TypeDefinition.Deprecated));
            }

            codeFile.Properties.Add(new MultitypeCurrentValuePropertyCodeConverter());

            codeFile.Constructors.Add(new MultitypeConstructorCodeConverter(classEntity.FormattedName, classEntity.TypeDefinition.TypeChoices));

            codeFile.Methods.Add(new MultitypeToStringMethodCodeConverter());
        }
    }
}
