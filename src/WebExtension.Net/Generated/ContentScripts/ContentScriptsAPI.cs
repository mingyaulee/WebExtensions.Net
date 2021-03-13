/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.ContentScripts
{
    /// <summary></summary>
    public class ContentScriptsAPI : IContentScriptsAPI
    {
        private readonly WebExtensionJSRuntime webExtensionJSRuntime;
        public ContentScriptsAPI(WebExtensionJSRuntime webExtensionJSRuntime)
        {
            this.webExtensionJSRuntime = webExtensionJSRuntime;
        }

        
        /// Function Definition
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
