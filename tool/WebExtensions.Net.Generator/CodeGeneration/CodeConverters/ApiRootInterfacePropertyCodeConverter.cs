using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public class ApiRootInterfacePropertyCodeConverter(ClrPropertyInfo clrPropertyInfo) : ICodeConverter
    {
        private readonly ClrPropertyInfo clrPropertyInfo = clrPropertyInfo;

        public void WriteTo(CodeWriter codeWriter, CodeWriterOptions options)
            => new ApiClassInterfaceApiPropertyCodeConverter(clrPropertyInfo)
                .WriteTo(codeWriter, options);
    }
}
