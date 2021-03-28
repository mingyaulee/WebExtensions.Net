using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.ContentScripts
{
    /// <inheritdoc />
    public class ContentScriptsApi : BaseApi, IContentScriptsApi
    {
        /// <summary>Creates a new instance of ContentScriptsApi.</summary>
        /// <param name="webExtensionJSRuntime">Web Extension JS Runtime</param>
        public ContentScriptsApi(WebExtensionJSRuntime webExtensionJSRuntime) : base(webExtensionJSRuntime, "contentScripts")
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
