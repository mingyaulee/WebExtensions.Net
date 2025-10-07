namespace WebExtensions.Net.Generator.EntitiesRegistration
{
    public class RegistrarFactory(
        NamespaceEntityRegistrar namespaceEntityRegistrar,
        TypeEntityRegistrar typeEntityRegistrar,
        ClassEntityRegistrar classEntityRegistrar,
        AnonymousTypeRegistrar anonymousTypeRegistrar)
    {
        public NamespaceEntityRegistrar NamespaceEntityRegistrar { get; } = namespaceEntityRegistrar;
        public TypeEntityRegistrar TypeEntityRegistrar { get; } = typeEntityRegistrar;
        public ClassEntityRegistrar ClassEntityRegistrar { get; } = classEntityRegistrar;
        public AnonymousTypeRegistrar AnonymousTypeRegistrar { get; } = anonymousTypeRegistrar;
    }
}
