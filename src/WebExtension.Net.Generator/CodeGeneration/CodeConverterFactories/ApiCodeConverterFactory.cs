using WebExtension.Net.Generator.CodeGeneration.CodeConverters;
using WebExtension.Net.Generator.Models.ClrTypes;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverterFactories
{
    public class ApiCodeConverterFactory : ICodeConverterFactory
    {
        public void AddInterfaceConvertersToCodeFile(ClrTypeInfo clrTypeInfo, CodeFile codeFile)
        {
            codeFile.Comments.Add(new CommentSummaryCodeConverter(clrTypeInfo.Description));

            foreach (var property in clrTypeInfo.Properties)
            {
                codeFile.Properties.Add(new ApiInterfacePropertyCodeConverter(property));
            }

            foreach (var method in clrTypeInfo.Methods)
            {
                codeFile.Methods.Add(new ApiInterfaceMethodCodeConverter(method));
            }
        }

        public void AddConvertersToCodeFile(ClrTypeInfo clrTypeInfo, CodeFile codeFile)
        {
            codeFile.Comments.Add(new CommentInheritDocCodeConverter());
            codeFile.Constructors.Add(new ApiConstructorCodeConverter(clrTypeInfo.CSharpName, (string)clrTypeInfo.Metadata[Constants.TypeMetadata.ApiNamespace]));

            foreach (var property in clrTypeInfo.Properties)
            {
                codeFile.Properties.Add(new ApiPropertyCodeConverter(property));
            }

            foreach (var method in clrTypeInfo.Methods)
            {
                codeFile.Methods.Add(new ApiMethodCodeConverter(method));
            }
        }
    }
}
