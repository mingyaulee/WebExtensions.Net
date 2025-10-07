using WebExtensions.Net.Generator.Models;
using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class ApiPropertyCodeConverter(ClrPropertyInfo clrPropertyInfo) : ICodeConverter
    {
        private readonly ClrPropertyInfo clrPropertyInfo = clrPropertyInfo;

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
        {
            if (clrPropertyInfo.PropertyType.Metadata.TryGetValue(Constants.TypeMetadata.ClassType, out var classType) && (ClassType)classType == ClassType.ApiClass)
            {
                new ApiClassApiPropertyCodeConverter(clrPropertyInfo)
                    .WriteTo(codeWriter, options);
            }
            else if (clrPropertyInfo.Metadata.TryGetValue(Constants.PropertyMetadata.EventProperty, out var isEventProperty) && (bool)isEventProperty)
            {
                WriteEventProperty(codeWriter);
            }
            else if (clrPropertyInfo.IsConstant)
            {
                WriteConstantProperty(codeWriter);
            }
            else
            {
                WritePublicProperty(codeWriter);
            }
        }

        private void WriteEventProperty(CodeWriter codeWriter)
        {
            var privatePropertyName = clrPropertyInfo.PrivateName;

            codeWriter.WriteUsingStatement("JsBind.Net");

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
                            .WriteLine($"_{privatePropertyName}.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, \"{privatePropertyName}\"));")
                        .WriteEndBlock()
                        .WriteLine($"return _{privatePropertyName};")
                    // end property get
                    .WriteEndBlock()
                // end property body
                .WriteEndBlock();
        }

        private void WriteConstantProperty(CodeWriter codeWriter)
        {
            if (clrPropertyInfo.PropertyType.FullName == typeof(string).FullName)
            {
                codeWriter.PublicProperties
                    .WriteWithConverter(new CommentInheritDocCodeConverter())
                    .WriteWithConverter(clrPropertyInfo.IsObsolete ? new AttributeObsoleteCodeConverter(clrPropertyInfo.ObsoleteMessage) : null)
                    .WriteLine($"public {clrPropertyInfo.PropertyType.CSharpName} {clrPropertyInfo.PublicName} => \"{clrPropertyInfo.ConstantValue}\";");
            }
            else
            {
                codeWriter.PublicProperties
                    .WriteWithConverter(new CommentInheritDocCodeConverter())
                    .WriteWithConverter(clrPropertyInfo.IsObsolete ? new AttributeObsoleteCodeConverter(clrPropertyInfo.ObsoleteMessage) : null)
                    .WriteLine($"public {clrPropertyInfo.PropertyType.CSharpName} {clrPropertyInfo.PublicName} => {clrPropertyInfo.ConstantValue};");
            }
        }

        private void WritePublicProperty(CodeWriter codeWriter)
        {
            var propertyValueSource = clrPropertyInfo.PublicName == clrPropertyInfo.Name ? $"nameof({clrPropertyInfo.Name})" : $"\"{clrPropertyInfo.Name}\"";
            codeWriter.PublicProperties
                .WriteWithConverter(new CommentInheritDocCodeConverter())
                .WriteWithConverter(clrPropertyInfo.IsObsolete ? new AttributeObsoleteCodeConverter(clrPropertyInfo.ObsoleteMessage) : null)
                .WriteLine($"public {clrPropertyInfo.PropertyType.CSharpName} {clrPropertyInfo.PublicName} => GetProperty<{clrPropertyInfo.PropertyType.CSharpName}>({propertyValueSource});");
        }
    }
}
