using WebExtension.Net.Generator.CodeGeneration;
using WebExtension.Net.Generator.CodeGeneration.CodeConverterFactories;
using WebExtension.Net.Generator.Models.Entities;

namespace WebExtension.Net.Generator.Translators
{
    public class EnumEntityTranslator
    {
        private readonly EnumCodeConverterFactory enumCodeConverter;

        public EnumEntityTranslator(EnumCodeConverterFactory enumCodeConverter)
        {
            this.enumCodeConverter = enumCodeConverter;
        }

        public void TranslateEnumEntityToCodeFile(EnumEntity enumEntity, CodeFile codeFile)
        {
            enumCodeConverter.AddConvertersToCodeFile(enumEntity, codeFile);
        }
    }
}
