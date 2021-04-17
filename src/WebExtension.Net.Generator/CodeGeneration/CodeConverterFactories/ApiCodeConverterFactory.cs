using WebExtension.Net.Generator.CodeGeneration.CodeConverters;
using WebExtension.Net.Generator.Models.Entities;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverterFactories
{
    public class ApiCodeConverterFactory : ICodeConverterFactory<ClassEntity>
    {
        public void AddInterfaceConvertersToCodeFile(ClassEntity entity, CodeFile codeFile)
        {
            codeFile.Comments.Add(new CommentSummaryCodeConverter(entity.Description));

            foreach (var propertyDefinitionPair in entity.Properties)
            {
                codeFile.Properties.Add(new ApiInterfacePropertyCodeConverter(propertyDefinitionPair.Key, propertyDefinitionPair.Value));
            }

            foreach (var functionDefinition in entity.Functions)
            {
                codeFile.Methods.Add(new ApiInterfaceMethodCodeConverter(functionDefinition));
            }
        }

        public void AddConvertersToCodeFile(ClassEntity entity, CodeFile codeFile)
        {
            codeFile.Comments.Add(new CommentInheritDocCodeConverter());
            codeFile.Constructors.Add(new ApiConstructorCodeConverter(entity.FormattedName, entity.NamespaceEntity.Name));

            foreach (var propertyDefinitionPair in entity.Properties)
            {
                codeFile.Properties.Add(new ApiPropertyCodeConverter(propertyDefinitionPair.Key, propertyDefinitionPair.Value));
            }

            foreach (var functionDefinition in entity.Functions)
            {
                codeFile.Methods.Add(new ApiMethodCodeConverter(functionDefinition));
            }
        }
    }
}
