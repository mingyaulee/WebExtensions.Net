using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.WebNavigation
{
    /// <summary>
    /// Use the <c>browser.webNavigation</c> API to receive notifications about the status of navigation requests in-flight.
    /// </summary>
    public interface IWebNavigationApi
    {
        
        
        
        // Function Definition Interface
        /// <summary>
        /// Retrieves information about the given frame. A frame refers to an &amp;lt;iframe&amp;gt; or a &amp;lt;frame&amp;gt; of a web page and is identified by a tab ID and a frame ID.
        /// </summary>
        /// <param name="details">Information about the frame to retrieve information about.</param>
        /// <returns></returns>
        ValueTask<JsonElement> GetFrame(object details);
        
        // Function Definition Interface
        /// <summary>
        /// Retrieves information about all frames of a given tab.
        /// </summary>
        /// <param name="details">Information about the tab to retrieve all frames from.</param>
        /// <returns></returns>
        ValueTask<IEnumerable<object>> GetAllFrames(object details);
    }
}
