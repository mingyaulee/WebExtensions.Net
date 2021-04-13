using WebExtension.Net.Generator.CodeGeneration.CodeConverters;
using WebExtension.Net.Generator.Models.Entities;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverterFactories
{
    public class ApiRootCodeConverterFactory : ICodeConverterFactory<ClassEntity>
    {
        public void AddInterfaceConvertersToCodeFile(ClassEntity classEntity, CodeFile codeFile)
        {
            foreach (var relativeNamespace in classEntity.UsingRelativeNamespaces)
            {
                codeFile.UsingRelativeNamespaces.Add(relativeNamespace);
            }

            codeFile.Comments.Add(new CommentSummaryCodeConverter(classEntity.Description));
            // Api Root has properties and no functions or events
            foreach (var propertyDefinitionPair in classEntity.Properties)
            {
                codeFile.Properties.Add(new ApiRootInterfacePropertyCodeConverter(propertyDefinitionPair.Key, propertyDefinitionPair.Value));
            }
        }

        public void AddConvertersToCodeFile(ClassEntity classEntity, CodeFile codeFile)
        {
            foreach (var relativeNamespace in classEntity.UsingRelativeNamespaces)
            {
                codeFile.UsingRelativeNamespaces.Add(relativeNamespace);
            }

            codeFile.Comments.Add(new CommentSummaryCodeConverter(classEntity.Description));
            codeFile.Constructors.Add(new ApiRootConstructorCodeConverter(classEntity.FormattedName));

            // Api Root has properties and no functions or events
            foreach (var propertyDefinitionPair in classEntity.Properties)
            {
                codeFile.Properties.Add(new ApiRootPropertyCodeConverter(propertyDefinitionPair.Key, propertyDefinitionPair.Value));
            }
        }
    }
}
