namespace WebExtension.Net.Generator.CodeGeneration
{
    public interface ICodeConverterFactory<EntityType>
    {
        void AddInterfaceConvertersToCodeFile(EntityType classEntity, CodeFile codeFile);
        void AddConvertersToCodeFile(EntityType classEntity, CodeFile codeFile);
    }
}