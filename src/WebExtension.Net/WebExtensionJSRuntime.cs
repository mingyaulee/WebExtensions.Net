using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace WebExtension.Net
{
    /// <summary>
    /// Adapter for IJSRuntime
    /// </summary>
    public class WebExtensionJSRuntime
    {
        private readonly IJSRuntime jsRuntime;
        /// <summary>
        /// Creates a new instance of WebExtensionJSRuntime.
        /// </summary>
        /// <param name="jsRuntime">The IJSRuntime instance.</param>
        public WebExtensionJSRuntime(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        /// <summary>
        /// Invokes the specified JavaScript function asynchronously.
        /// </summary>
        /// <param name="args">JSON-serializable arguments.</param>
        /// <returns>An instance of TValue obtained by JSON-deserializing the return value.</returns>
        public ValueTask<TValue> InvokeAsync<TValue>(params object[] args)
        {
            return jsRuntime.InvokeAsync<TValue>("WebExtensionNet.Execute", args);
        }

        /// <summary>
        /// Invokes the specified JavaScript function asynchronously.
        /// </summary>
        /// <param name="args">JSON-serializable arguments.</param>
        /// <returns>A System.Threading.Tasks.ValueTask that represents the asynchronous invocation operation.</returns>
        public ValueTask InvokeVoidAsync(params object[] args)
        {
            return jsRuntime.InvokeVoidAsync("WebExtensionNet.Execute", args);
        }
    }
}
