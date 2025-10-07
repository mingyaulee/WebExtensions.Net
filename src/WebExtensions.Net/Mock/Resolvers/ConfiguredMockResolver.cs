using System;
using System.Collections.Generic;
using System.Linq;
using WebExtensions.Net.Mock.Configurators;
using WebExtensions.Net.Mock.Handlers;

namespace WebExtensions.Net.Mock.Resolvers
{
    /// <summary>
    /// Configured mock resolver.
    /// </summary>
    internal class ConfiguredMockResolver : IMockResolver
    {
        private static readonly Queue<Action<IMockConfigurator>> configureActions = new();
        private static readonly List<MockApiHandler> mockApiHandlers = [];
        private static readonly List<MockObjectReferenceHandler> mockObjectReferenceHandlers = [];

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

        internal static void AddConfigureAction(Action<IMockConfigurator> configureAction)
            => configureActions.Enqueue(configureAction);

        internal static void Configure(MockConfigurator configurator)
        {
            while (configureActions.Count > 0)
            {
                var configureAction = configureActions.Dequeue();
                configureAction?.Invoke(configurator);
            }
            configurator.MergeTo(mockApiHandlers, mockObjectReferenceHandlers);
        }
    }
}
