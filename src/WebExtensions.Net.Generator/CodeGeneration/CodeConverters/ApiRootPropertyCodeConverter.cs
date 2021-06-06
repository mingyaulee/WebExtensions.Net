using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class ApiRootPropertyCodeConverter : ICodeConverter
    {
        private readonly ClrPropertyInfo clrPropertyInfo;

        public ApiRootPropertyCodeConverter(ClrPropertyInfo clrPropertyInfo)
        {
            this.clrPropertyInfo = clrPropertyInfo;
        }

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            var propertyType = clrPropertyInfo.PropertyType.CSharpName;
            var privatePropertyName = clrPropertyInfo.PrivateName;

            codeWriter.Properties
                .WriteLine($"private I{clrPropertyInfo.PropertyType.CSharpName} _{privatePropertyName};");

            codeWriter.PublicProperties
                .WriteWithConverter(new CommentInheritDocCodeConverter())
                .WriteLine($"public I{propertyType} {clrPropertyInfo.PublicName}")
                // start property body
                .WriteStartBlock()
                    .WriteLine($"get")
                    // start property get
                    .WriteStartBlock()
                        .WriteLine($"if (_{privatePropertyName} is null)")
                        .WriteStartBlock()
                            .WriteLine($"_{privatePropertyName} = new {propertyType}(webExtensionsJSRuntime);")
                        .WriteEndBlock()
                        .WriteLine($"return _{privatePropertyName};")
                    // end property get
                    .WriteEndBlock()
                // end property body
                .WriteEndBlock();
        }
    }
}
