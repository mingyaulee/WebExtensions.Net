using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.Runtime
{
    /// <inheritdoc />
    public class RuntimeAPI : BaseAPI, IRuntimeAPI
    {
        /// <summary>Creates a new instance of RuntimeAPI.</summary>
        /// <param name="webExtensionJSRuntime">Web Extension JS Runtime</param>
        public RuntimeAPI(WebExtensionJSRuntime webExtensionJSRuntime) : base(webExtensionJSRuntime, "runtime")
        {
        }

        
        
        // Property Getter Function Definition
        /// <summary>
        /// This will be defined during an API method callback if there was an error
        /// </summary>
        /// <returns></returns>
        public virtual ValueTask<JsonElement> GetLastError()
        {
            return GetPropertyAsync<JsonElement>("lastError");
        }
        
        // Property Getter Function Definition
        /// <summary>
        /// The ID of the extension/app.
        /// </summary>
        /// <returns></returns>
        public virtual ValueTask<string> GetId()
        {
            return GetPropertyAsync<string>("id");
        }
        
        // Function Definition
        /// <summary>
        /// Retrieves the JavaScript 'window' object for the background page running inside the current extension/app. If the background page is an event page, the system will ensure it is loaded before calling the callback. If there is no background page, an error is set.
        /// </summary>
        /// <returns></returns>
        public virtual ValueTask<JsonElement> GetBackgroundPage()
        {
            return InvokeAsync<JsonElement>("getBackgroundPage");
        }
        
        // Function Definition
        /// <summary>
        /// <p>Open your Extension's options page, if possible.</p><p>The precise behavior may depend on your manifest's <c>$(topic:optionsV2)[options_ui]</c> or <c>$(topic:options)[options_page]</c> key, or what the browser happens to support at the time.</p><p>If your Extension does not declare an options page, or the browser failed to create one for some other reason, the callback will set $(ref:lastError).</p>
        /// </summary>
        public virtual ValueTask OpenOptionsPage()
        {
            return InvokeVoidAsync("openOptionsPage");
        }
        
        // Function Definition
        /// <summary>
        /// Returns details about the app or extension from the manifest. The object returned is a serialization of the full $(topic:manifest)[manifest file].
        /// </summary>
        /// <returns></returns>
        public virtual ValueTask<JsonElement> GetManifest()
        {
            return InvokeAsync<JsonElement>("getManifest");
        }
        
        // Function Definition
        /// <summary>
        /// Converts a relative path within an app/extension install directory to a fully-qualified URL.
        /// </summary>
        /// <param name="path">A path to a resource within an app/extension expressed relative to its install directory.</param>
        /// <returns></returns>
        public virtual ValueTask<string> GetURL(string path)
        {
            return InvokeAsync<string>("getURL", path);
        }
        
        // Function Definition
        /// <summary>
        /// Sets the URL to be visited upon uninstallation. This may be used to clean up server-side data, do analytics, and implement surveys. Maximum 255 characters.
        /// </summary>
        /// <param name="url">URL to be opened after the extension is uninstalled. This URL must have an http: or https: scheme. Set an empty string to not open a new tab upon uninstallation.</param>
        public virtual ValueTask SetUninstallURL(string url)
        {
            return InvokeVoidAsync("setUninstallURL", url);
        }
        
        // Function Definition
        /// <summary>
        /// Reloads the app or extension.
        /// </summary>
        public virtual ValueTask Reload()
        {
            return InvokeVoidAsync("reload");
        }
        
        // Function Definition
        /// <summary>
        /// Attempts to connect to connect listeners within an extension/app (such as the background page), or other extensions/apps. This is useful for content scripts connecting to their extension processes, inter-app/extension communication, and $(topic:manifest/externally_connectable)[web messaging]. Note that this does not connect to any listeners in a content script. Extensions may connect to content scripts embedded in tabs via $(ref:tabs.connect).
        /// </summary>
        /// <param name="extensionId">The ID of the extension or app to connect to. If omitted, a connection will be attempted with your own extension. Required if sending messages from a web page for $(topic:manifest/externally_connectable)[web messaging].</param>
        /// <param name="connectInfo"></param>
        /// <returns></returns>
        public virtual ValueTask<Port> Connect(string extensionId, object connectInfo)
        {
            return InvokeAsync<Port>("connect", extensionId, connectInfo);
        }
        
        // Function Definition
        /// <summary>
        /// Connects to a native application in the host machine.
        /// </summary>
        /// <param name="application">The name of the registered application to connect to.</param>
        /// <returns></returns>
        public virtual ValueTask<Port> ConnectNative(string application)
        {
            return InvokeAsync<Port>("connectNative", application);
        }
        
        // Function Definition
        /// <summary>
        /// Sends a single message to event listeners within your extension/app or a different extension/app. Similar to $(ref:runtime.connect) but only sends a single message, with an optional response. If sending to your extension, the $(ref:runtime.onMessage) event will be fired in each page, or $(ref:runtime.onMessageExternal), if a different extension. Note that extensions cannot send messages to content scripts using this method. To send messages to content scripts, use $(ref:tabs.sendMessage).
        /// </summary>
        /// <param name="extensionId">The ID of the extension/app to send the message to. If omitted, the message will be sent to your own extension/app. Required if sending messages from a web page for $(topic:manifest/externally_connectable)[web messaging].</param>
        /// <param name="message"></param>
        /// <param name="options"></param>
        /// <param name="responseCallback"></param>
        public virtual ValueTask SendMessage(string extensionId, object message, object options, Action responseCallback)
        {
            return InvokeVoidAsync("sendMessage", extensionId, message, options, responseCallback);
        }
        
        // Function Definition
        /// <summary>
        /// Send a single message to a native application.
        /// </summary>
        /// <param name="application">The name of the native messaging host.</param>
        /// <param name="message">The message that will be passed to the native messaging host.</param>
        /// <param name="responseCallback"></param>
        public virtual ValueTask SendNativeMessage(string application, object message, Action responseCallback)
        {
            return InvokeVoidAsync("sendNativeMessage", application, message, responseCallback);
        }
        
        // Function Definition
        /// <summary>
        /// Returns information about the current browser.
        /// </summary>
        /// <returns></returns>
        public virtual ValueTask<BrowserInfo> GetBrowserInfo()
        {
            return InvokeAsync<BrowserInfo>("getBrowserInfo");
        }
        
        // Function Definition
        /// <summary>
        /// Returns information about the current platform.
        /// </summary>
        /// <returns></returns>
        public virtual ValueTask<PlatformInfo> GetPlatformInfo()
        {
            return InvokeAsync<PlatformInfo>("getPlatformInfo");
        }
    }
}
