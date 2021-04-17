namespace WebExtension.Net.Generator.CodeGeneration
{
    public interface ICodeConverterFactory<in EntityType>
    {
        void AddInterfaceConvertersToCodeFile(EntityType entity, CodeFile codeFile);
        void AddConvertersToCodeFile(EntityType entity, CodeFile codeFile);
    }
}