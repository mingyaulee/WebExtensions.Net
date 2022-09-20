using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsBind.Net;
using JsBind.Net.InvokeOptions;

namespace WebExtensions.Net.Mock
{
    /// <summary>
    /// Mock adapter for JS runtime, should be used as a singleton.
    /// </summary>
    public class MockJsRuntimeAdapter : IJsRuntimeAdapter
    {
        private static readonly IDictionary<string, object> objectReferences = new Dictionary<string, object>();

        /// <inheritdoc />
        public TValue Invoke<TValue>(string identifier, InvokeOptionWithReturnValue invokeOption)
        {
            return MockInvoke<TValue>(invokeOption);
        }

        /// <inheritdoc />
        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, InvokeOptionWithReturnValue invokeOption)
        {
            return ValueTask.FromResult(MockInvoke<TValue>(invokeOption));
        }

        /// <inheritdoc />
        public void InvokeVoid(string identifier, InvokeOption invokeOption)
        {
            MockInvoke<object>(invokeOption);
        }

        /// <inheritdoc />
        public ValueTask InvokeVoidAsync(string identifier, InvokeOption invokeOption)
        {
            MockInvoke<object>(invokeOption);
            return ValueTask.CompletedTask;
        }

        /// <inheritdoc />
        public bool IsJsRuntimeEqual(IJsRuntimeAdapter other)
        {
            return Equals(other);
        }

        private TValue MockInvoke<TValue>(InvokeOption invokeOption)
        {
            if (!MockConfigurationContext.IsConfigured && !MockConfigurationContext.IsConfiguring)
            {
                MockConfigurationContext.Configure();
            }

            object result = null;

            if (invokeOption is IGetPropertyOption getPropertyOption)
            {
                result = MockGetProperty(getPropertyOption);
            }
            else if (invokeOption is IInvokeFunctionOption invokeFunctionOption)
            {
                result = MockInvokeFunction(invokeFunctionOption);
            }

            if (result is null)
            {
                return default;
            }

            if (invokeOption is InvokeOptionWithReturnValue invokeOptionWithReturnValue && invokeOptionWithReturnValue.HasReturnValue && invokeOptionWithReturnValue.ReturnValueIsReference)
            {
                var accessPath = AccessPaths.FromReferenceId(invokeOptionWithReturnValue.ReturnValueReferenceId);
                InitializeObject(result, accessPath);
                objectReferences[invokeOptionWithReturnValue.ReturnValueReferenceId] = result;
            }

            return (TValue)result;
        }

        private void InitializeObject(object obj, string accessPath)
        {
            if (obj is BaseObject baseObject)
            {
                baseObject.Initialize(this, accessPath);
            }
            else if (obj is IEnumerable enumerable)
            {
                var index = 0;
                foreach (var item in enumerable)
                {
                    var itemAccessPath = AccessPaths.Combine(accessPath, index.ToString());
                    InitializeObject(item, itemAccessPath);
                    index++;
                }
            }
        }

        private static object MockGetProperty(IGetPropertyOption getPropertyOption)
        {
            var accessPaths = AccessPaths.Split(getPropertyOption.AccessPath);
            if (accessPaths is null || !accessPaths.Any())
            {
                return null;
            }

            var accessPathIdentifier = accessPaths.First();
            var targetPath = AccessPaths.Combine(accessPaths.Skip(1).Concat(new[] { getPropertyOption.PropertyName }).ToArray());
            
            if (accessPathIdentifier == "browser")
            {
                return MockInvokeApi(targetPath, Array.Empty<object>());
            }

            if (!AccessPaths.IsReferenceId(accessPathIdentifier))
            {
                return null;
            }

            return MockInvokeObjectReference(AccessPaths.GetReferenceId(accessPathIdentifier)?.ToString(), targetPath, Array.Empty<object>());
        }

        private static object MockInvokeFunction(IInvokeFunctionOption invokeFunctionOption)
        {
            var accessPaths = AccessPaths.Split(invokeFunctionOption.AccessPath);
            if (accessPaths is null || !accessPaths.Any())
            {
                return null;
            }

            var accessPathIdentifier = accessPaths.First();
            var targetPath = AccessPaths.Combine(accessPaths.Skip(1).Concat(new[] { invokeFunctionOption.FunctionName }).ToArray());
            var functionArguments = invokeFunctionOption.FunctionArguments?.ToArray() ?? Array.Empty<object>();

            if (accessPathIdentifier == "browser")
            {
                return MockInvokeApi(targetPath, functionArguments);
            }

            if (!AccessPaths.IsReferenceId(accessPathIdentifier))
            {
                return null;
            }

            return MockInvokeObjectReference(AccessPaths.GetReferenceId(accessPathIdentifier)?.ToString(), targetPath, functionArguments);
        }

        private static object MockInvokeApi(string targetPath, object[] arguments)
        {
            if (MockConfigurationContext.IsConfiguring)
            {
                MockConfigurationContext.ApiInvoked(targetPath);
                return null;
            }

            return MockResolvers.InvokeApiHandler(targetPath, arguments);
        }

        private static object MockInvokeObjectReference(string referenceId, string targetPath, object[] arguments)
        {
            if (objectReferences.TryGetValue(referenceId, out var objectReference))
            {
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
