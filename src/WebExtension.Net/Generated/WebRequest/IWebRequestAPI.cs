// This file is auto generated at 2021-03-24T04:51:22

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.WebRequest
{
    /// <summary>
    /// Use the <c>browser.webRequest</c> API to observe and analyze traffic and to intercept, block, or modify requests in-flight.
    /// </summary>
    public interface IWebRequestAPI
    {
        
        // Function Definition Interface
        /// <summary>
        /// Needs to be called when the behavior of the webRequest handlers has changed to prevent incorrect handling due to caching. This function call is expensive. Don't call it often.
        /// </summary>
        ValueTask HandlerBehaviorChanged();
        
        // Function Definition Interface
        /// <summary>
        /// ...
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        ValueTask<JsonElement> FilterResponseData(string requestId);
        
        // Function Definition Interface
        /// <summary>
        /// Retrieves the security information for the request.  Returns a promise that will resolve to a SecurityInfo object.
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="options"></param>
        ValueTask GetSecurityInfo(string requestId, object options);
    }
}
