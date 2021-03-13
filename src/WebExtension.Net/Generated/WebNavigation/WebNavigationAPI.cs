/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.WebNavigation
{
    /// <summary>Use the <code>browser.webNavigation</code> API to receive notifications about the status of navigation requests in-flight.</summary>
    public class WebNavigationAPI : IWebNavigationAPI
    {
        private readonly WebExtensionJSRuntime webExtensionJSRuntime;
        public WebNavigationAPI(WebExtensionJSRuntime webExtensionJSRuntime)
        {
            this.webExtensionJSRuntime = webExtensionJSRuntime;
        }

        
        /// Function Definition
        /// <summary>
        /// Retrieves information about the given frame. A frame refers to an &lt;iframe&gt; or a &lt;frame&gt; of a web page and is identified by a tab ID and a frame ID.
        /// </summary>
        /// <param name="details">Information about the frame to retrieve information about.</param>
        public virtual ValueTask<JsonElement> GetFrame(object details)
        {
            return webExtensionJSRuntime.InvokeAsync<JsonElement>("webNavigation.getFrame", details);
        }
        
        /// Function Definition
        /// <summary>
        /// Retrieves information about all frames of a given tab.
        /// </summary>
        /// <param name="details">Information about the tab to retrieve all frames from.</param>
        public virtual ValueTask<IEnumerable<object>> GetAllFrames(object details)
        {
            return webExtensionJSRuntime.InvokeAsync<IEnumerable<object>>("webNavigation.getAllFrames", details);
        }
    }
}
