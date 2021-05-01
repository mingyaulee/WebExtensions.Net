using WebExtension.Net.Generator.Models.ClrTypes;

namespace WebExtension.Net.Generator.CodeGeneration
{
    public interface ICodeConverterFactory
    {
        void AddInterfaceConvertersToCodeFile(ClrTypeInfo clrTypeInfo, CodeFile codeFile);
        void AddConvertersToCodeFile(ClrTypeInfo clrTypeInfo, CodeFile codeFile);
    }
}