using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.WebRequest
{
    /// <inheritdoc />
    public class WebRequestApi : BaseApi, IWebRequestApi
    {
        /// <summary>Creates a new instance of <see cref="WebRequestApi" />.</summary>
        /// <param name="webExtensionJSRuntime">Web Extension JS Runtime</param>
        public WebRequestApi(WebExtensionJSRuntime webExtensionJSRuntime) : base(webExtensionJSRuntime, "webRequest")
        {
        }

        /// <inheritdoc />
        public int MAX_HANDLER_BEHAVIOR_CHANGED_CALLS_PER_10_MINUTES => 20;

        /// <inheritdoc />
        public virtual ValueTask<JsonElement> FilterResponseData(string requestId)
        {
            return InvokeAsync<JsonElement>("filterResponseData", requestId);
        }

        /// <inheritdoc />
        public virtual ValueTask GetSecurityInfo(string requestId, object options)
        {
            return InvokeVoidAsync("getSecurityInfo", requestId, options);
        }

        /// <inheritdoc />
        public virtual ValueTask HandlerBehaviorChanged()
        {
            return InvokeVoidAsync("handlerBehaviorChanged");
        }
    }
}
