using WebExtensions.Net.Generator.CodeGeneration.CodeConverters;
using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverterFactories;

public class ApiRootCodeConverterFactory : ICodeConverterFactory
{
    public void AddInterfaceConvertersToCodeFile(ClrTypeInfo clrTypeInfo, CodeFile codeFile)
    {
        codeFile.Comments.Add(new CommentSummaryCodeConverter(clrTypeInfo.Description));
        codeFile.Attributes.Add(new AttributeJsAccessPathCodeConverter("browser"));

        // Api Root has properties and no functions or events
        foreach (var property in clrTypeInfo.Properties)
        {
            codeFile.Properties.Add(new ApiRootInterfacePropertyCodeConverter(property));
        }
    }

    public void AddConvertersToCodeFile(ClrTypeInfo clrTypeInfo, CodeFile codeFile)
    {
        codeFile.Comments.Add(new CommentSummaryCodeConverter(clrTypeInfo.Description));
        codeFile.Constructors.Add(new ApiRootConstructorCodeConverter());

        // Api Root has properties and no functions or events
        foreach (var property in clrTypeInfo.Properties)
        {
            codeFile.Properties.Add(new ApiRootPropertyCodeConverter(property));
        }
    }
}
