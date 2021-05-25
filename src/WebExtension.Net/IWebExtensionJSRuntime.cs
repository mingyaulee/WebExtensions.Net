using System.Threading.Tasks;

namespace WebExtension.Net
{
    /// <summary>
    /// Adapter for IJSRuntime
    /// </summary>
    public interface IWebExtensionJSRuntime
    {
        internal static IWebExtensionJSRuntime StaticInstance { get; set; }

        /// <summary>
        /// Invokes the specified JavaScript function synchronously.
        /// </summary>
        /// <typeparam name="TValue">The JSON-serializable return type.</typeparam>
        /// <param name="identifier">An identifier for the function to invoke. For example, the value "someScope.someFunction" will invoke the function window.someScope.someFunction.</param>
        /// <param name="invokeOption">The option for invocation.</param>
        /// <param name="args">JSON-serializable arguments.</param>
        /// <returns>An instance of TResult obtained by JSON-deserializing the return value.</returns>
        TValue Invoke<TValue>(string identifier, InvokeOption invokeOption, params object[] args);

        /// <summary>
        /// Invokes the specified JavaScript function asynchronously.
        /// </summary>
        /// <typeparam name="TValue">The JSON-serializable return type.</typeparam>
        /// <param name="identifier">An identifier for the function to invoke. For example, the value "someScope.someFunction" will invoke the function window.someScope.someFunction.</param>
        /// <param name="invokeOption">The option for invocation.</param>
        /// <param name="args">JSON-serializable arguments.</param>
        /// <returns>An instance of TValue obtained by JSON-deserializing the return value.</returns>
        ValueTask<TValue> InvokeAsync<TValue>(string identifier, InvokeOption invokeOption, params object[] args);

        /// <summary>
        /// Invokes the specified JavaScript function synchronously.
        /// </summary>
        /// <param name="identifier">An identifier for the function to invoke. For example, the value "someScope.someFunction" will invoke the function window.someScope.someFunction.</param>
        /// <param name="invokeOption">The option for invocation.</param>
        /// <param name="args">JSON-serializable arguments.</param>
        void InvokeVoid(string identifier, InvokeOption invokeOption, params object[] args);

        /// <summary>
        /// Invokes the specified JavaScript function asynchronously.
        /// </summary>
        /// <param name="identifier">An identifier for the function to invoke. For example, the value "someScope.someFunction" will invoke the function window.someScope.someFunction.</param>
        /// <param name="invokeOption">The option for invocation.</param>
        /// <param name="args">JSON-serializable arguments.</param>
        /// <returns>A System.Threading.Tasks.ValueTask that represents the asynchronous invocation operation.</returns>
        ValueTask InvokeVoidAsync(string identifier, InvokeOption invokeOption, params object[] args);
    }
}
