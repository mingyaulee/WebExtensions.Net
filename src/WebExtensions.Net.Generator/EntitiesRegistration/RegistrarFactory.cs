namespace WebExtensions.Net.Generator.EntitiesRegistration
{
    public class RegistrarFactory
    {
        public RegistrarFactory(
            NamespaceEntityRegistrar namespaceEntityRegistrar,
            TypeEntityRegistrar typeEntityRegistrar,
            ClassEntityRegistrar classEntityRegistrar,
            AnonymousTypeRegistrar anonymousTypeRegistrar)
        {
            NamespaceEntityRegistrar = namespaceEntityRegistrar;
            TypeEntityRegistrar = typeEntityRegistrar;
            ClassEntityRegistrar = classEntityRegistrar;
            AnonymousTypeRegistrar = anonymousTypeRegistrar;
        }

        public NamespaceEntityRegistrar NamespaceEntityRegistrar { get; }
        public TypeEntityRegistrar TypeEntityRegistrar { get; }
        public ClassEntityRegistrar ClassEntityRegistrar { get; }
        public AnonymousTypeRegistrar AnonymousTypeRegistrar { get; }
    }
}
