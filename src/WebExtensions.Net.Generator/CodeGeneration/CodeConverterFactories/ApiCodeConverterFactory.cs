using System.Collections.Generic;
using System.Linq;
using WebExtensions.Net.Generator.CodeGeneration.CodeConverters;
using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverterFactories
{
    public class ApiCodeConverterFactory : ICodeConverterFactory
    {
        public void AddInterfaceConvertersToCodeFile(ClrTypeInfo clrTypeInfo, CodeFile codeFile)
        {
            codeFile.Comments.Add(new CommentSummaryCodeConverter(clrTypeInfo.Description));

            foreach (var property in GetProperties(clrTypeInfo))
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

            foreach (var property in GetProperties(clrTypeInfo))
            {
                codeFile.Properties.Add(new ApiPropertyCodeConverter(property));
            }

            foreach (var method in clrTypeInfo.Methods)
            {
                codeFile.Methods.Add(new ApiMethodCodeConverter(method));
            }
        }

        private static IEnumerable<ClrPropertyInfo> GetProperties(ClrTypeInfo clrTypeInfo)
        {
            return clrTypeInfo.Properties.OrderBy(property => property.Metadata.TryGetValue(Constants.PropertyMetadata.NestedApiProperty, out var isNestedApiProperty) && (bool)isNestedApiProperty ? 0 : 1);
        }
    }
}
