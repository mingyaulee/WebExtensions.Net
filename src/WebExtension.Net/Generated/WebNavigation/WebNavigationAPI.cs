// This file is auto generated at 2021-03-24T04:51:22

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.WebNavigation
{
    /// <inheritdoc />
    public class WebNavigationAPI : IWebNavigationAPI
    {
        private readonly WebExtensionJSRuntime webExtensionJSRuntime;
        /// <summary>Creates a new instance of WebNavigationAPI.</summary>
        /// <param name="webExtensionJSRuntime">Web Extension JS Runtime</param>
        public WebNavigationAPI(WebExtensionJSRuntime webExtensionJSRuntime)
        {
            this.webExtensionJSRuntime = webExtensionJSRuntime;
        }

        
        // Function Definition
        /// <summary>
        /// Retrieves information about the given frame. A frame refers to an &amp;lt;iframe&amp;gt; or a &amp;lt;frame&amp;gt; of a web page and is identified by a tab ID and a frame ID.
        /// </summary>
        /// <param name="details">Information about the frame to retrieve information about.</param>
        /// <returns></returns>
        public virtual ValueTask<JsonElement> GetFrame(object details)
        {
            return webExtensionJSRuntime.InvokeAsync<JsonElement>("webNavigation.getFrame", details);
        }
        
        // Function Definition
        /// <summary>
        /// Retrieves information about all frames of a given tab.
        /// </summary>
        /// <param name="details">Information about the tab to retrieve all frames from.</param>
        /// <returns></returns>
        public virtual ValueTask<IEnumerable<object>> GetAllFrames(object details)
        {
            return webExtensionJSRuntime.InvokeAsync<IEnumerable<object>>("webNavigation.getAllFrames", details);
        }
    }
}
