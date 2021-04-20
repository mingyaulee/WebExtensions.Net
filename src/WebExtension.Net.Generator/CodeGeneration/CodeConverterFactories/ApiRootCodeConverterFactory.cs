using WebExtension.Net.Generator.CodeGeneration.CodeConverters;
using WebExtension.Net.Generator.Models.Entities;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverterFactories
{
    public class ApiRootCodeConverterFactory : ICodeConverterFactory<ClassEntity>
    {
        public void AddInterfaceConvertersToCodeFile(ClassEntity entity, CodeFile codeFile)
        {
            codeFile.Comments.Add(new CommentSummaryCodeConverter(entity.Description));
            // Api Root has properties and no functions or events
            foreach (var propertyDefinitionPair in entity.Properties)
            {
                codeFile.Properties.Add(new ApiRootInterfacePropertyCodeConverter(propertyDefinitionPair.Key, propertyDefinitionPair.Value));
            }
        }

        public void AddConvertersToCodeFile(ClassEntity entity, CodeFile codeFile)
        {
            codeFile.Comments.Add(new CommentSummaryCodeConverter(entity.Description));
            codeFile.Constructors.Add(new ApiRootConstructorCodeConverter(entity.FormattedName));

            // Api Root has properties and no functions or events
            foreach (var propertyDefinitionPair in entity.Properties)
            {
                codeFile.Properties.Add(new ApiRootPropertyCodeConverter(propertyDefinitionPair.Key, propertyDefinitionPair.Value));
            }
        }
    }
}
