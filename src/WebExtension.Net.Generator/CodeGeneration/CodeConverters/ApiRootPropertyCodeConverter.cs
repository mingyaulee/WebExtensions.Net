using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public class ApiRootPropertyCodeConverter : BasePropertyCodeConverter
    {
        private readonly string propertyName;

        public ApiRootPropertyCodeConverter(string propertyName, PropertyDefinition propertyDefinition) : base(propertyDefinition)
        {
            this.propertyName = propertyName;
        }

        public override void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            codeWriter.WriteUsingStatement(UsingNamespaces);

            codeWriter.Properties
                .WriteLine($"private I{PropertyType} _{propertyName};");

            codeWriter.PublicProperties
                .WriteWithConverter(new CommentInheritDocCodeConverter())
                .WriteLine($"public I{PropertyType} {propertyName.ToCapitalCase()}")
                // start property body
                .WriteStartBlock()
                    .WriteLine($"get")
                    // start property get
                    .WriteStartBlock()
                        .WriteLine($"if (_{propertyName} is null)")
                        .WriteStartBlock()
                            .WriteLine($"_{propertyName} = new {PropertyType}(webExtensionJSRuntime);")
                        .WriteEndBlock()
                        .WriteLine($"return _{propertyName};")
                    // end property get
                    .WriteEndBlock()
                // end property body
                .WriteEndBlock();
        }
    }
}
