// This file is auto generated at 2021-03-24T04:51:22

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.WebRequest
{
    // Class Definition
    /// <summary>
    /// Returns value for event handlers that have the 'blocking' extraInfoSpec applied. Allows the event handler to modify network requests.
    /// </summary>
    public class BlockingResponse
    {
        
        // Property Definition
        /// <summary>
        /// If true, the request is cancelled. Used in onBeforeRequest, this prevents the request from being sent.
        /// </summary>
        [JsonPropertyName("cancel")]
        public bool? Cancel { get; set; }
        
        // Property Definition
        /// <summary>
        /// Only used as a response to the onBeforeRequest and onHeadersReceived events. If set, the original request is prevented from being sent/completed and is instead redirected to the given URL. Redirections to non-HTTP schemes such as data: are allowed. Redirects initiated by a redirect action use the original request method for the redirect, with one exception: If the redirect is initiated at the onHeadersReceived stage, then the redirect will be issued using the GET method.
        /// </summary>
        [JsonPropertyName("redirectUrl")]
        public string RedirectUrl { get; set; }
        
        // Property Definition
        /// <summary>
        /// Only used as a response to the onBeforeRequest event. If set, the original request is prevented from being sent/completed and is instead upgraded to a secure request.  If any extension returns <c>redirectUrl</c> during onBeforeRequest, <c>upgradeToSecure</c> will have no affect.
        /// </summary>
        [JsonPropertyName("upgradeToSecure")]
        public bool? UpgradeToSecure { get; set; }
        
        // Property Definition
        /// <summary>
        /// Only used as a response to the onBeforeSendHeaders event. If set, the request is made with these request headers instead.
        /// </summary>
        [JsonPropertyName("requestHeaders")]
        public HttpHeaders RequestHeaders { get; set; }
        
        // Property Definition
        /// <summary>
        /// Only used as a response to the onHeadersReceived event. If set, the server is assumed to have responded with these response headers instead. Only return <c>responseHeaders</c> if you really want to modify the headers in order to limit the number of conflicts (only one extension may modify <c>responseHeaders</c> for each request).
        /// </summary>
        [JsonPropertyName("responseHeaders")]
        public HttpHeaders ResponseHeaders { get; set; }
        
        // Property Definition
        /// <summary>
        /// Only used as a response to the onAuthRequired event. If set, the request is made using the supplied credentials.
        /// </summary>
        [JsonPropertyName("authCredentials")]
        public object AuthCredentials { get; set; }
    }
}

