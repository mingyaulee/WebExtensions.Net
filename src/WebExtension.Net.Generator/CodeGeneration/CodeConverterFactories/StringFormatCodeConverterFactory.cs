using System;
using WebExtension.Net.Generator.CodeGeneration.CodeConverters;
using WebExtension.Net.Generator.Models.Entities;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverterFactories
{
    public class StringFormatCodeConverterFactory : ICodeConverterFactory<ClassEntity>
    {
        public void AddInterfaceConvertersToCodeFile(ClassEntity classEntity, CodeFile codeFile)
        {
            throw new NotImplementedException();
        }

        public void AddConvertersToCodeFile(ClassEntity classEntity, CodeFile codeFile)
        {
            if (classEntity.TypeDefinition is null || classEntity.TypeDefinition.StringFormat is null)
            {
                return;
            }

            codeFile.Comments.Add(new CommentCodeConverter("String Format Class"));
            codeFile.Comments.Add(new CommentSummaryCodeConverter(classEntity.Description));

            if (classEntity.TypeDefinition.IsDeprecated)
            {
                codeFile.Attributes.Add(new AttributeObsoleteCodeConverter(classEntity.TypeDefinition.Deprecated));
            }

            codeFile.Constructors.Add(new StringFormatConstructorCodeConverter(classEntity.FormattedName, classEntity.TypeDefinition.StringFormat));
        }
    }
}
