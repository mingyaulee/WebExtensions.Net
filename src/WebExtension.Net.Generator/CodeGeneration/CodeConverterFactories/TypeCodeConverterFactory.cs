using System;
using WebExtension.Net.Generator.CodeGeneration.CodeConverters;
using WebExtension.Net.Generator.Models.Entities;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverterFactories
{
    public class TypeCodeConverterFactory : ICodeConverterFactory<ClassEntity>
    {
        public void AddInterfaceConvertersToCodeFile(ClassEntity entity, CodeFile codeFile)
        {
            throw new NotImplementedException();
        }

        public void AddConvertersToCodeFile(ClassEntity entity, CodeFile codeFile)
        {
            codeFile.Comments.Add(new CommentCodeConverter("Type Class"));
            codeFile.Comments.Add(new CommentSummaryCodeConverter(entity.Description));

            if (entity.TypeDefinition is not null && entity.TypeDefinition.IsDeprecated)
            {
                codeFile.Attributes.Add(new AttributeObsoleteCodeConverter(entity.TypeDefinition.Deprecated));
            }

            foreach (var propertyDefinitionPair in entity.Properties)
            {
                codeFile.Properties.Add(new TypePropertyCodeConverter(propertyDefinitionPair.Key, propertyDefinitionPair.Value));
            }

            foreach (var functionDefinition in entity.Functions)
            {
                codeFile.Methods.Add(new TypeMethodCodeConverter(functionDefinition));
            }
        }
    }
}
