// This file is auto generated at 2021-03-24T04:51:22

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.ContentScripts
{
    /// <inheritdoc />
    public class ContentScriptsAPI : IContentScriptsAPI
    {
        private readonly WebExtensionJSRuntime webExtensionJSRuntime;
        /// <summary>Creates a new instance of ContentScriptsAPI.</summary>
        /// <param name="webExtensionJSRuntime">Web Extension JS Runtime</param>
        public ContentScriptsAPI(WebExtensionJSRuntime webExtensionJSRuntime)
        {
            this.webExtensionJSRuntime = webExtensionJSRuntime;
        }

        
        // Function Definition
        /// <summary>
        /// Register a content script programmatically
        /// </summary>
        /// <param name="contentScriptOptions"></param>
        public virtual ValueTask Register(RegisteredContentScriptOptions contentScriptOptions)
        {
            return webExtensionJSRuntime.InvokeVoidAsync("contentScripts.register", contentScriptOptions);
        }
    }
}
