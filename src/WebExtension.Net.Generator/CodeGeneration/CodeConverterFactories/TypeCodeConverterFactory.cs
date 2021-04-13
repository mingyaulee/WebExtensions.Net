using System;
using WebExtension.Net.Generator.CodeGeneration.CodeConverters;
using WebExtension.Net.Generator.Models.Entities;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverterFactories
{
    public class TypeCodeConverterFactory : ICodeConverterFactory<ClassEntity>
    {
        public void AddInterfaceConvertersToCodeFile(ClassEntity classEntity, CodeFile codeFile)
        {
            throw new NotImplementedException();
        }

        public void AddConvertersToCodeFile(ClassEntity classEntity, CodeFile codeFile)
        {
            codeFile.Comments.Add(new CommentCodeConverter("Type Class"));
            codeFile.Comments.Add(new CommentSummaryCodeConverter(classEntity.Description));

            if (classEntity.TypeDefinition is not null && classEntity.TypeDefinition.IsDeprecated)
            {
                codeFile.Attributes.Add(new AttributeObsoleteCodeConverter(classEntity.TypeDefinition.Deprecated));
            }

            foreach (var propertyDefinitionPair in classEntity.Properties)
            {
                codeFile.Properties.Add(new TypePropertyCodeConverter(propertyDefinitionPair.Key, propertyDefinitionPair.Value));
            }

            foreach (var functionDefinition in classEntity.Functions)
            {
                codeFile.Methods.Add(new TypeMethodCodeConverter(functionDefinition));
            }
        }
    }
}
