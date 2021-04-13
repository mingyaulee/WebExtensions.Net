namespace WebExtension.Net.Generator.Repositories
{
    public class EntitiesContext
    {
        public EntitiesContext()
        {
            Namespaces = new NamespaceRepository();
            Types = new TypeRepository();
            Classes = new ClassRepository();
            Enums = new EnumRepository();
        }

        public NamespaceRepository Namespaces { get; }
        public TypeRepository Types { get; }
        public ClassRepository Classes { get; }
        public EnumRepository Enums { get; }
    }
}
