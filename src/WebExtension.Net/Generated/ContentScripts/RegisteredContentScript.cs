using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.ContentScripts
{
    // Class Definition
    /// <summary>
    /// An object that represents a content script registered programmatically
    /// </summary>
    public class RegisteredContentScript : BaseObject
    {
        
        // Function Definition
        /// <summary>
        /// Unregister a content script registered programmatically
        /// </summary>
        public virtual ValueTask Unregister()
        {
            return InvokeVoidAsync("unregister");
        }
    }
}

