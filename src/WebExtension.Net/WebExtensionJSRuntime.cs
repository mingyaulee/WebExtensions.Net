using Microsoft.JSInterop;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebExtension.Net
{
    /// <summary>
    /// Adapter for IJSRuntime
    /// </summary>
    public class WebExtensionJSRuntime
    {
        private static IJSRuntime staticJsRuntime;
        private readonly IJSRuntime jsRuntime;

        internal WebExtensionJSRuntime()
        {
            jsRuntime = staticJsRuntime;
        }

        /// <summary>
        /// Creates a new instance of WebExtensionJSRuntime.
        /// </summary>
        /// <param name="jsRuntime">The IJSRuntime instance.</param>
        public WebExtensionJSRuntime(IJSRuntime jsRuntime)
        {
#pragma warning disable S3010 // Static fields should not be updated in constructors
            staticJsRuntime = jsRuntime;
#pragma warning restore S3010 // Static fields should not be updated in constructors
            this.jsRuntime = jsRuntime;
        }

        /// <summary>
        /// Invokes the specified JavaScript function asynchronously.
        /// </summary>
        /// <typeparam name="TValue">The JSON-serializable return type.</typeparam>
        /// <param name="identifier">An identifier for the function to invoke. For example, the value "someScope.someFunction" will invoke the function window.someScope.someFunction.</param>
        /// <param name="invokeOption">The option for invocation.</param>
        /// <param name="args">JSON-serializable arguments.</param>
        /// <returns>An instance of TValue obtained by JSON-deserializing the return value.</returns>
        public async ValueTask<TValue> InvokeAsync<TValue>(string identifier, InvokeOption invokeOption, params object[] args)
        {
            if (typeof(BaseObject).IsAssignableFrom(typeof(TValue)))
            {
                invokeOption.ReturnObjectReferenceId = Guid.NewGuid().ToString();
            }
            var invokeArgs = new object[] { invokeOption }.Concat(ArgumentsHandler.ProcessOutgoingArguments(args)).ToArray();
            var result = await jsRuntime.InvokeAsync<TValue>(identifier, invokeArgs);
            if (!string.IsNullOrEmpty(invokeOption.ReturnObjectReferenceId) && result is BaseObject baseObject)
            {
                baseObject.Initialize(this, invokeOption.ReturnObjectReferenceId, null);
            }
            return result;
        }

        /// <summary>
        /// Invokes the specified JavaScript function asynchronously.
        /// </summary>
        /// <param name="identifier">An identifier for the function to invoke. For example, the value "someScope.someFunction" will invoke the function window.someScope.someFunction.</param>
        /// <param name="invokeOption">The option for invocation.</param>
        /// <param name="args">JSON-serializable arguments.</param>
        /// <returns>A System.Threading.Tasks.ValueTask that represents the asynchronous invocation operation.</returns>
        public ValueTask InvokeVoidAsync(string identifier, InvokeOption invokeOption, params object[] args)
        {
            var invokeArgs = new object[] { invokeOption }.Concat(ArgumentsHandler.ProcessOutgoingArguments(args)).ToArray();
            return jsRuntime.InvokeVoidAsync(identifier, invokeArgs);
        }

        /// <summary>
        /// Invokes the specified JavaScript function synchronously.
        /// </summary>
        /// <typeparam name="TValue">The JSON-serializable return type.</typeparam>
        /// <param name="identifier">An identifier for the function to invoke. For example, the value "someScope.someFunction" will invoke the function window.someScope.someFunction.</param>
        /// <param name="invokeOption">The option for invocation.</param>
        /// <param name="args">JSON-serializable arguments.</param>
        /// <returns>An instance of TResult obtained by JSON-deserializing the return value.</returns>
        public TValue Invoke<TValue>(string identifier, InvokeOption invokeOption, params object[] args)
        {
            if (typeof(BaseObject).IsAssignableFrom(typeof(TValue)))
            {
                invokeOption.ReturnObjectReferenceId = Guid.NewGuid().ToString();
            }
            var invokeArgs = new object[] { invokeOption }.Concat(ArgumentsHandler.ProcessOutgoingArguments(args)).ToArray();
            var result = ((IJSInProcessRuntime)jsRuntime).Invoke<TValue>(identifier, invokeArgs);
            if (!string.IsNullOrEmpty(invokeOption.ReturnObjectReferenceId) && result is BaseObject baseObject)
            {
                baseObject.Initialize(this, invokeOption.ReturnObjectReferenceId, null);
            }
            return result;
        }

        /// <summary>
        /// Invokes the specified JavaScript function synchronously.
        /// </summary>
        /// <param name="identifier">An identifier for the function to invoke. For example, the value "someScope.someFunction" will invoke the function window.someScope.someFunction.</param>
        /// <param name="invokeOption">The option for invocation.</param>
        /// <param name="args">JSON-serializable arguments.</param>
        public void InvokeVoid(string identifier, InvokeOption invokeOption, params object[] args)
        {
            var invokeArgs = new object[] { invokeOption }.Concat(ArgumentsHandler.ProcessOutgoingArguments(args)).ToArray();
            ((IJSInProcessRuntime)jsRuntime).InvokeVoid(identifier, invokeArgs);
        }

        internal static WebExtensionJSRuntime GetStaticInstance()
        {
            return new WebExtensionJSRuntime();
        }
    }
}
