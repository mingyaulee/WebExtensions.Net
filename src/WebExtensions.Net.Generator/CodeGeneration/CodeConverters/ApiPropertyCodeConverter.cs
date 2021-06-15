using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class ApiPropertyCodeConverter : ICodeConverter
    {
        private readonly ClrPropertyInfo clrPropertyInfo;

        public ApiPropertyCodeConverter(ClrPropertyInfo clrPropertyInfo)
        {
            this.clrPropertyInfo = clrPropertyInfo;
        }

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            if (clrPropertyInfo.PropertyType.Metadata.TryGetValue(Constants.TypeMetadata.ClassType, out var classType) && (ClassType)classType == ClassType.ApiClass)
            {
                new ApiClassApiPropertyCodeConverter(clrPropertyInfo)
                    .WriteTo(codeWriter, options);
            }
            else if (clrPropertyInfo.IsConstant)
            {
                codeWriter.PublicProperties
                    .WriteWithConverter(new CommentInheritDocCodeConverter())
                    .WriteLine($"public {clrPropertyInfo.PropertyType.CSharpName} {clrPropertyInfo.PublicName} => {clrPropertyInfo.ConstantValue};");
            }
            else
            {
                // Event property
                var privatePropertyName = clrPropertyInfo.PrivateName;
                codeWriter.Properties
                    .WriteLine($"private {clrPropertyInfo.PropertyType.CSharpName} _{privatePropertyName};");

                codeWriter.PublicProperties
                    .WriteWithConverter(new CommentInheritDocCodeConverter())
                    .WriteWithConverter(clrPropertyInfo.IsObsolete ? new AttributeObsoleteCodeConverter(clrPropertyInfo.ObsoleteMessage) : null)
                    .WriteLine($"public {clrPropertyInfo.PropertyType.CSharpName} {clrPropertyInfo.PublicName}")
                    // start property body
                    .WriteStartBlock()
                        .WriteLine($"get")
                        // start property get
                        .WriteStartBlock()
                            .WriteLine($"if (_{privatePropertyName} is null)")
                            .WriteStartBlock()
                                .WriteLine($"_{privatePropertyName} = new {clrPropertyInfo.PropertyType.CSharpName}();")
                                .WriteLine($"InitializeProperty(\"{privatePropertyName}\", _{privatePropertyName});")
                            .WriteEndBlock()
                            .WriteLine($"return _{privatePropertyName};")
                        // end property get
                        .WriteEndBlock()
                    // end property body
                    .WriteEndBlock();
            }
        }
    }
}
