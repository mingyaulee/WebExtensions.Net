using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.WebRequest
{
    /// <inheritdoc />
    public class WebRequestApi : BaseApi, IWebRequestApi
    {
        /// <summary>Creates a new instance of WebRequestApi.</summary>
        /// <param name="webExtensionJSRuntime">Web Extension JS Runtime</param>
        public WebRequestApi(WebExtensionJSRuntime webExtensionJSRuntime) : base(webExtensionJSRuntime, "webRequest")
        {
        }

        
        // Property Definition
        private const int _MAX_HANDLER_BEHAVIOR_CHANGED_CALLS_PER_10_MINUTES = 20;
        /// <summary>
        /// The maximum number of times that <c>handlerBehaviorChanged</c> can be called per 10 minute sustained interval. <c>handlerBehaviorChanged</c> is an expensive function call that shouldn't be called often.
        /// </summary>
        public int MAX_HANDLER_BEHAVIOR_CHANGED_CALLS_PER_10_MINUTES => _MAX_HANDLER_BEHAVIOR_CHANGED_CALLS_PER_10_MINUTES;
        
        
        // Function Definition
        /// <summary>
        /// Needs to be called when the behavior of the webRequest handlers has changed to prevent incorrect handling due to caching. This function call is expensive. Don't call it often.
        /// </summary>
        public virtual ValueTask HandlerBehaviorChanged()
        {
            return InvokeVoidAsync("handlerBehaviorChanged");
        }
        
        // Function Definition
        /// <summary>
        /// ...
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public virtual ValueTask<JsonElement> FilterResponseData(string requestId)
        {
            return InvokeAsync<JsonElement>("filterResponseData", requestId);
        }
        
        // Function Definition
        /// <summary>
        /// Retrieves the security information for the request.  Returns a promise that will resolve to a SecurityInfo object.
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="options"></param>
        public virtual ValueTask GetSecurityInfo(string requestId, object options)
        {
            return InvokeVoidAsync("getSecurityInfo", requestId, options);
        }
    }
}
