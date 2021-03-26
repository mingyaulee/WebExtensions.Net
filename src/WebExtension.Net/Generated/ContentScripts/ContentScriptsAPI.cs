using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.ContentScripts
{
    /// <inheritdoc />
    public class ContentScriptsAPI : BaseAPI, IContentScriptsAPI
    {
        /// <summary>Creates a new instance of ContentScriptsAPI.</summary>
        /// <param name="webExtensionJSRuntime">Web Extension JS Runtime</param>
        public ContentScriptsAPI(WebExtensionJSRuntime webExtensionJSRuntime) : base(webExtensionJSRuntime, "contentScripts")
        {
        }

        
        
        
        // Function Definition
        /// <summary>
        /// Register a content script programmatically
        /// </summary>
        /// <param name="contentScriptOptions"></param>
        public virtual ValueTask Register(RegisteredContentScriptOptions contentScriptOptions)
        {
            return InvokeVoidAsync("register", contentScriptOptions);
        }
    }
}
