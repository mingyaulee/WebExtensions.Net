using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.Runtime
{
    /// <inheritdoc />
    public class RuntimeApi : BaseApi, IRuntimeApi
    {
        /// <summary>Creates a new instance of <see cref="RuntimeApi" />.</summary>
        /// <param name="webExtensionJSRuntime">Web Extension JS Runtime</param>
        public RuntimeApi(WebExtensionJSRuntime webExtensionJSRuntime) : base(webExtensionJSRuntime, "runtime")
        {
        }

        /// <inheritdoc />
        public virtual ValueTask<Port> Connect(string extensionId, object connectInfo)
        {
            return InvokeAsync<Port>("connect", extensionId, connectInfo);
        }

        /// <inheritdoc />
        public virtual ValueTask<Port> ConnectNative(string application)
        {
            return InvokeAsync<Port>("connectNative", application);
        }

        /// <inheritdoc />
        public virtual ValueTask<JsonElement> GetBackgroundPage()
        {
            return InvokeAsync<JsonElement>("getBackgroundPage");
        }

        /// <inheritdoc />
        public virtual ValueTask<BrowserInfo> GetBrowserInfo()
        {
            return InvokeAsync<BrowserInfo>("getBrowserInfo");
        }

        /// <inheritdoc />
        public virtual ValueTask<JsonElement> GetManifest()
        {
            return InvokeAsync<JsonElement>("getManifest");
        }

        /// <inheritdoc />
        public virtual ValueTask<PlatformInfo> GetPlatformInfo()
        {
            return InvokeAsync<PlatformInfo>("getPlatformInfo");
        }

        /// <inheritdoc />
        public virtual ValueTask<string> GetURL(string path)
        {
            return InvokeAsync<string>("getURL", path);
        }

        /// <inheritdoc />
        public virtual ValueTask<string> GetId()
        {
            return GetPropertyAsync<string>("id");
        }

        /// <inheritdoc />
        public virtual ValueTask<JsonElement> GetLastError()
        {
            return GetPropertyAsync<JsonElement>("lastError");
        }

        /// <inheritdoc />
        public virtual ValueTask OpenOptionsPage()
        {
            return InvokeVoidAsync("openOptionsPage");
        }

        /// <inheritdoc />
        public virtual ValueTask Reload()
        {
            return InvokeVoidAsync("reload");
        }

        /// <inheritdoc />
        public virtual ValueTask<JsonElement> SendMessage(string extensionId, object message, object options)
        {
            return InvokeAsync<JsonElement>("sendMessage", extensionId, message, options);
        }

        /// <inheritdoc />
        public virtual ValueTask<JsonElement> SendNativeMessage(string application, object message)
        {
            return InvokeAsync<JsonElement>("sendNativeMessage", application, message);
        }

        /// <inheritdoc />
        public virtual ValueTask SetUninstallURL(string url)
        {
            return InvokeVoidAsync("setUninstallURL", url);
        }
    }
}
