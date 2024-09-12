namespace WebExtensions.Net.Mock.Configurators
{
    /// <summary>
    /// Mock configurator interface.
    /// </summary>
    public interface IMockConfigurator
    {
        /// <summary>
        /// Configures the mock handler for the WebExtensionsApi.
        /// </summary>
        ApiConfigurator Api { get; }

        /// <summary>Configures the mock handler for the object reference.</summary>
        /// <typeparam name="TObject">The object reference type.</typeparam>
        /// <param name="objectReference">The object reference instance.</param>
        /// <returns>The object reference configurator.</returns>
        ObjectReferenceConfigurator<TObject> ObjectReference<TObject>(TObject objectReference) where TObject : BaseObject;

        /// <summary>
        /// Registers a delegate to handle all Api calls.
        /// </summary>
        /// <param name="apiHandler">The Api handler delegate.</param>
        void ApiHandler(ApiHandler apiHandler);

        /// <summary>
        /// Registers a delegate to handle all object referece calls.
        /// </summary>
        /// <param name="objectReferenceHandler">The object reference handler delegate.</param>
        void ObjectReferenceHandler(ObjectReferenceHandler objectReferenceHandler);
    }
}
