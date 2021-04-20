using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.WebRequest
{
    /// <summary>Use the <c>browser.webRequest</c> API to observe and analyze traffic and to intercept, block, or modify requests in-flight.</summary>
    public interface IWebRequestApi
    {
        /// <summary>The maximum number of times that <c>handlerBehaviorChanged</c> can be called per 10 minute sustained interval. <c>handlerBehaviorChanged</c> is an expensive function call that shouldn't be called often.</summary>
        int MAX_HANDLER_BEHAVIOR_CHANGED_CALLS_PER_10_MINUTES { get; }

        /// <summary>...</summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        ValueTask<JsonElement> FilterResponseData(string requestId);

        /// <summary>Retrieves the security information for the request.  Returns a promise that will resolve to a SecurityInfo object.</summary>
        /// <param name="requestId"></param>
        /// <param name="options"></param>
        ValueTask GetSecurityInfo(string requestId, object options);

        /// <summary>Needs to be called when the behavior of the webRequest handlers has changed to prevent incorrect handling due to caching. This function call is expensive. Don't call it often.</summary>
        ValueTask HandlerBehaviorChanged();
    }
}
