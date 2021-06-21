using Microsoft.JSInterop;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtensions.Net
{
    /// <summary>
    /// Adapter for IJSRuntime
    /// </summary>
    public class WebExtensionsJSRuntime : IWebExtensionsJSRuntime
    {
        private readonly IJSRuntime jsRuntime;
        private const string GetLastInvocationResultIdentifier = "WebExtensionsNet.GetLastInvocationResult";

        /// <summary>
        /// Creates a new instance of WebExtensionsJSRuntime.
        /// </summary>
        /// <param name="jsRuntime">The IJSRuntime instance.</param>
        public WebExtensionsJSRuntime(IJSRuntime jsRuntime)
        {
            IWebExtensionsJSRuntime.StaticInstance = this;
            this.jsRuntime = jsRuntime;
        }

        /// <inheritdoc />
        public async ValueTask<TValue> InvokeAsync<TValue>(string identifier, InvokeOption invokeOption, params object[] args)
        {
            if (typeof(BaseObject).IsAssignableFrom(typeof(TValue)))
            {
                invokeOption.ReturnObjectReferenceId = Guid.NewGuid().ToString();
            }
            var invokeArgs = new object[] { invokeOption }.Concat(ArgumentsHandler.ProcessOutgoingArguments(args)).ToArray();

            TValue result;
            try
            {
                result = await jsRuntime.InvokeAsync<TValue>(identifier, invokeArgs);
            }
            catch (JsonException jsonException)
            {
                var json = await jsRuntime.InvokeAsync<string>(GetLastInvocationResultIdentifier);
                throw new JsonException($"Last invocation result: {json}", jsonException);
            }

            if (!string.IsNullOrEmpty(invokeOption.ReturnObjectReferenceId) && result is BaseObject baseObject)
            {
                baseObject.Initialize(this, invokeOption.ReturnObjectReferenceId, null);
            }
            return result;
        }

        /// <inheritdoc />
        public ValueTask InvokeVoidAsync(string identifier, InvokeOption invokeOption, params object[] args)
        {
            var invokeArgs = new object[] { invokeOption }.Concat(ArgumentsHandler.ProcessOutgoingArguments(args)).ToArray();
            return jsRuntime.InvokeVoidAsync(identifier, invokeArgs);
        }

        /// <inheritdoc />
        public TValue Invoke<TValue>(string identifier, InvokeOption invokeOption, params object[] args)
        {
            if (typeof(BaseObject).IsAssignableFrom(typeof(TValue)))
            {
                invokeOption.ReturnObjectReferenceId = Guid.NewGuid().ToString();
            }
            var invokeArgs = new object[] { invokeOption }.Concat(ArgumentsHandler.ProcessOutgoingArguments(args)).ToArray();

            if (jsRuntime is not IJSInProcessRuntime jsInProcessRuntime)
            {
                throw new InvalidOperationException($"Unable to cast JS runtime to type {nameof(IJSInProcessRuntime)}");
            }

            TValue result;
            try
            {
                result = jsInProcessRuntime.Invoke<TValue>(identifier, invokeArgs);
            }
            catch (JsonException jsonException)
            {
                var json = jsInProcessRuntime.Invoke<string>(GetLastInvocationResultIdentifier);
                throw new JsonException($"Last invocation result: {json}", jsonException);
            }

            if (!string.IsNullOrEmpty(invokeOption.ReturnObjectReferenceId) && result is BaseObject baseObject)
            {
                baseObject.Initialize(this, invokeOption.ReturnObjectReferenceId, null);
            }
            return result;
        }

        /// <inheritdoc />
        public void InvokeVoid(string identifier, InvokeOption invokeOption, params object[] args)
        {
            var invokeArgs = new object[] { invokeOption }.Concat(ArgumentsHandler.ProcessOutgoingArguments(args)).ToArray();
            ((IJSInProcessRuntime)jsRuntime).InvokeVoid(identifier, invokeArgs);
        }
    }
}
