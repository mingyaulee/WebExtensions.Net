using WebExtension.Net.Generator.CodeGeneration.CodeConverters;
using WebExtension.Net.Generator.Models.Entities;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverterFactories
{
    public class ApiCodeConverterFactory : ICodeConverterFactory<ClassEntity>
    {
        public void AddInterfaceConvertersToCodeFile(ClassEntity classEntity, CodeFile codeFile)
        {
            codeFile.Comments.Add(new CommentSummaryCodeConverter(classEntity.Description));

            foreach (var propertyDefinitionPair in classEntity.Properties)
            {
                codeFile.Properties.Add(new ApiInterfacePropertyCodeConverter(propertyDefinitionPair.Key, propertyDefinitionPair.Value));
            }

            foreach (var functionDefinition in classEntity.Functions)
            {
                codeFile.Methods.Add(new ApiInterfaceMethodCodeConverter(functionDefinition));
            }
        }

        public void AddConvertersToCodeFile(ClassEntity classEntity, CodeFile codeFile)
        {
            codeFile.Comments.Add(new CommentInheritDocCodeConverter());
            codeFile.Constructors.Add(new ApiConstructorCodeConverter(classEntity.FormattedName, classEntity.NamespaceEntity.Name));

            foreach (var propertyDefinitionPair in classEntity.Properties)
            {
                codeFile.Properties.Add(new ApiPropertyCodeConverter(propertyDefinitionPair.Key, propertyDefinitionPair.Value));
            }

            foreach (var functionDefinition in classEntity.Functions)
            {
                codeFile.Methods.Add(new ApiMethodCodeConverter(functionDefinition));
            }
        }
    }
}
