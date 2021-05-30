using System;
using System.Collections.Generic;
using System.Linq;
using WebExtension.Net.Mock.Handlers;
using WebExtension.Net.Mock.Resolvers;

namespace WebExtension.Net.Mock.Configurators
{
    /// <summary>
    /// Mock configurator
    /// </summary>
    public class MockConfigurator : IMockConfigurator
    {
        private readonly IList<IMockHandler> apiHandlers;
        private readonly IList<IMockHandler> objectReferenceHandlers;
        private readonly ApiConfigurator apiConfigurator;
        private readonly IWebExtensionApi webExtensionApi;

        /// <summary>
        /// Creates a new instance of MockConfigurator.
        /// </summary>
        public MockConfigurator(IWebExtensionApi webExtensionApi)
        {
            apiHandlers = new List<IMockHandler>();
            objectReferenceHandlers = new List<IMockHandler>();
            apiConfigurator = new ApiConfigurator(webExtensionApi, apiHandlers);
            this.webExtensionApi = webExtensionApi;
        }

        /// <inheritdoc />
        public ApiConfigurator Api => apiConfigurator;

        /// <inheritdoc />
        public ObjectReferenceConfigurator<TObject> ObjectReference<TObject>(TObject objectReference)
            where TObject : BaseObject
            => new(webExtensionApi, objectReferenceHandlers, objectReference);

        /// <inheritdoc />
        public void ApiHandler(ApiHandler apiHandler)
        {
            MockResolvers.Resolvers.Insert(1, new CustomMockResolver(apiHandler, null));
        }

        /// <inheritdoc />
        public void ObjectReferenceHandler(ObjectReferenceHandler objectReferenceHandler)
        {
            MockResolvers.Resolvers.Insert(1, new CustomMockResolver(null, objectReferenceHandler));
        }

        internal void MergeTo(IList<MockApiHandler> mockApiHandlers, IList<MockObjectReferenceHandler> mockObjectReferenceHandlers)
        {
            foreach (var apiHandler in apiHandlers.Cast<MockApiHandler>())
            {
                mockApiHandlers.Add(apiHandler);
            }

            foreach (var objectReferenceHandler in objectReferenceHandlers.Cast<MockObjectReferenceHandler>())
            {
                mockObjectReferenceHandlers.Add(objectReferenceHandler);
            }

            apiHandlers.Clear();
            objectReferenceHandlers.Clear();
        }
    }
}
