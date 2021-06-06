using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.Mock
{
    /// <summary>
    /// Mock adapter for IJSRuntime, should be used as a singleton.
    /// </summary>
    public class MockWebExtensionsJSRuntime : IWebExtensionsJSRuntime
    {
        private static readonly IDictionary<string, object> objectReferences = new Dictionary<string, object>();

        /// <summary>
        /// Creates a new instance of MockWebExtensionsJSRuntime.
        /// </summary>
        public MockWebExtensionsJSRuntime()
        {
            IWebExtensionsJSRuntime.StaticInstance = this;
        }

        /// <inheritdoc />
        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, InvokeOption invokeOption, params object[] args)
        {
            return ValueTask.FromResult(MockInvoke<TValue>(identifier, invokeOption, args));
        }

        /// <inheritdoc />
        public ValueTask InvokeVoidAsync(string identifier, InvokeOption invokeOption, params object[] args)
        {
            MockInvoke<object>(identifier, invokeOption, args);
            return ValueTask.CompletedTask;
        }

        /// <inheritdoc />
        public TValue Invoke<TValue>(string identifier, InvokeOption invokeOption, params object[] args)
        {
            return MockInvoke<TValue>(identifier, invokeOption, args);
        }

        /// <inheritdoc />
        public void InvokeVoid(string identifier, InvokeOption invokeOption, params object[] args)
        {
            MockInvoke<object>(identifier, invokeOption, args);
        }

        private TValue MockInvoke<TValue>(string identifier, InvokeOption invokeOption, object[] args)
        {
            if (!MockConfigurationContext.IsConfigured && !MockConfigurationContext.IsConfiguring)
            {
                MockConfigurationContext.Configure();
            }

            object result = null;

            if (identifier == InvokeObjectReferenceOption.Identifier)
            {
                var invokeObjectReferenceOption = invokeOption as InvokeObjectReferenceOption;
                result = MockInvokeObjectReference(invokeObjectReferenceOption, args);
            }

            if (typeof(BaseObject).IsAssignableFrom(typeof(TValue)) && result is BaseObject baseObject)
            {
                var objectReferenceId = Guid.NewGuid().ToString();
                objectReferences[objectReferenceId] = baseObject;
                baseObject.Initialize(this, objectReferenceId, null);
            }

            if (result is null)
            {
                return default;
            }

            return (TValue)result;
        }

        private static object MockInvokeObjectReference(InvokeObjectReferenceOption invokeObjectReferenceOption, object[] arguments)
        {
            var referenceId = invokeObjectReferenceOption.ReferenceId;
            var targetPath = invokeObjectReferenceOption.TargetPath;

            if (referenceId == "browser")
            {
                if (MockConfigurationContext.IsConfiguring)
                {
                    MockConfigurationContext.ApiInvoked(targetPath);
                    return null;
                }

                return MockResolvers.InvokeApiHandler(targetPath, arguments);
            }

            if (objectReferences.ContainsKey(referenceId))
            {
                var objectReference = objectReferences[referenceId];

                if (MockConfigurationContext.IsConfiguring)
                {
                    MockConfigurationContext.ObjectReferenceInvoked(objectReference, targetPath);
                    return null;
                }

                return MockResolvers.InvokeObjectReferenceHandler(objectReference, targetPath, arguments);
            }

            return null;
        }
    }
}
