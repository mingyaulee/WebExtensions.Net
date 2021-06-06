using System.Collections.Generic;
using System.Linq;
using WebExtensions.Net.Mock.Configurators;
using WebExtensions.Net.Mock.Handlers;
using WebExtensions.Net.Storage;

namespace WebExtensions.Net.Mock.Resolvers
{
    /// <summary>
    /// Default mock resolver.
    /// </summary>
    internal class DefaultMockResolver : IMockResolver
    {
        private static bool isConfigured;
        public static readonly List<MockApiHandler> mockApiHandlers = new();
        public static readonly List<MockObjectReferenceHandler> mockObjectReferenceHandlers = new();

        public bool TryInvokeApiHandler(string targetPath, object[] arguments, out object result)
        {
            var apiHandler = mockApiHandlers.LastOrDefault(mockApiHandler => mockApiHandler.ApiTargetPath == targetPath);
            if (apiHandler is not null)
            {
                result = apiHandler.DelegateHandler?.DynamicInvoke(arguments);
                return true;
            }

            result = null;
            return false;
        }

        public bool TryInvokeObjectReferenceHandler(object objectReference, string targetPath, object[] arguments, out object result)
        {
            var objectReferenceHandler = mockObjectReferenceHandlers.LastOrDefault(mockObjectReferenceHandler => mockObjectReferenceHandler.ObjectReference.Equals(objectReference) && mockObjectReferenceHandler.TargetPath == targetPath);
            if (objectReferenceHandler is not null)
            {
                result = objectReferenceHandler.DelegateHandler?.DynamicInvoke(arguments);
                return true;
            }

            result = null;
            return false;
        }

        internal static void Configure(MockConfigurator configurator)
        {
            if (isConfigured)
            {
                return;
            }

            isConfigured = true;
            ConfigureDefaultMock(configurator);
            configurator.MergeTo(mockApiHandlers, mockObjectReferenceHandlers);
        }

        private static void ConfigureDefaultMock(MockConfigurator configure)
        {
            configure.Api.Method<string>(api => api.Runtime.GetId)
                .ReturnsForAnyArgs(string.Empty);
            configure.Api.Method<string, string>(api => api.Runtime.GetURL)
                .Returns(path => $"/{path}");
            configure.Api.Method<StorageArea>(api => api.Storage.GetLocal)
                .ReturnsForAnyArgs(DefaultMockObjects.LocalStorage);
            configure.Api.Method<StorageArea>(api => api.Storage.GetManaged)
                .ReturnsForAnyArgs(DefaultMockObjects.ManagedStorage);
            configure.Api.Method<StorageAreaSync>(api => api.Storage.GetSync)
                .ReturnsForAnyArgs(DefaultMockObjects.SyncStorage);
        }
    }
}
