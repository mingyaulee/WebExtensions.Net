using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class ApiClassApiPropertyCodeConverter(ClrPropertyInfo clrPropertyInfo) : ICodeConverter
    {
        private readonly ClrPropertyInfo clrPropertyInfo = clrPropertyInfo;

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            var propertyType = clrPropertyInfo.PropertyType.CSharpName;
            var privatePropertyName = clrPropertyInfo.PrivateName;

            codeWriter.Properties
                .WriteLine($"private I{clrPropertyInfo.PropertyType.CSharpName} _{privatePropertyName};");

            codeWriter.PublicProperties
                .WriteWithConverter(new CommentInheritDocCodeConverter())
                .WriteLine($"public I{propertyType} {clrPropertyInfo.PublicName} => _{privatePropertyName} ??= new {propertyType}(JsRuntime, AccessPath);");
        }
    }
}
