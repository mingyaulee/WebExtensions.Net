using System.Text.Json;
using System.Threading.Tasks;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Runtime
{
    /// <summary>Use the <c>browser.runtime</c> API to retrieve the background page, return details about the manifest, and listen for and respond to events in the app or extension lifecycle. You can also use this API to convert the relative path of URLs to fully-qualified URLs.</summary>
    public partial interface IRuntimeApi
    {
        /// <summary>Fired when a connection is made from either an extension process or a content script.</summary>
        OnConnectEvent OnConnect { get; }

        /// <summary>Fired when a connection is made from another extension.</summary>
        OnConnectExternalEvent OnConnectExternal { get; }

        /// <summary>Fired when the extension is first installed, when the extension is updated to a new version, and when the browser is updated to a new version.</summary>
        OnInstalledEvent OnInstalled { get; }

        /// <summary>Fired when a message is sent from either an extension process or a content script.</summary>
        OnMessageEvent OnMessage { get; }

        /// <summary>Fired when a message is sent from another extension/app. Cannot be used in a content script.</summary>
        OnMessageExternalEvent OnMessageExternal { get; }

        /// <summary>Fired when a profile that has this extension installed first starts up. This event is not fired for incognito profiles.</summary>
        Event OnStartup { get; }

        /// <summary>Fired when an update is available, but isn't installed immediately because the app is currently running. If you do nothing, the update will be installed the next time the background page gets unloaded, if you want it to be installed sooner you can explicitly call $(ref:runtime.reload). If your extension is using a persistent background page, the background page of course never gets unloaded, so unless you call $(ref:runtime.reload) manually in response to this event the update will not get installed until the next time the browser itself restarts. If no handlers are listening for this event, and your extension has a persistent background page, it behaves as if $(ref:runtime.reload) is called in response to this event.</summary>
        OnUpdateAvailableEvent OnUpdateAvailable { get; }

        /// <summary>Attempts to connect to connect listeners within an extension/app (such as the background page), or other extensions/apps. This is useful for content scripts connecting to their extension processes, inter-app/extension communication, and $(topic:manifest/externally_connectable)[web messaging]. Note that this does not connect to any listeners in a content script. Extensions may connect to content scripts embedded in tabs via $(ref:tabs.connect).</summary>
        /// <param name="extensionId">The ID of the extension or app to connect to. If omitted, a connection will be attempted with your own extension. Required if sending messages from a web page for $(topic:manifest/externally_connectable)[web messaging].</param>
        /// <param name="connectInfo"></param>
        /// <returns>Port through which messages can be sent and received. The port's $(ref:runtime.Port onDisconnect) event is fired if the extension/app does not exist. </returns>
        ValueTask<Port> Connect(string extensionId, ConnectInfo connectInfo);

        /// <summary>Connects to a native application in the host machine.</summary>
        /// <param name="application">The name of the registered application to connect to.</param>
        /// <returns>Port through which messages can be sent and received with the application</returns>
        ValueTask<Port> ConnectNative(string application);

        /// <summary>Retrieves the JavaScript 'window' object for the background page running inside the current extension/app. If the background page is an event page, the system will ensure it is loaded before calling the callback. If there is no background page, an error is set.</summary>
        /// <returns>The JavaScript 'window' object for the background page.</returns>
        ValueTask<JsonElement> GetBackgroundPage();

        /// <summary>Returns information about the current browser.</summary>
        /// <returns></returns>
        ValueTask<BrowserInfo> GetBrowserInfo();

        /// <summary>Returns details about the app or extension from the manifest. The object returned is a serialization of the full $(topic:manifest)[manifest file].</summary>
        /// <returns>The manifest details.</returns>
        ValueTask<JsonElement> GetManifest();

        /// <summary>Returns information about the current platform.</summary>
        /// <returns></returns>
        ValueTask<PlatformInfo> GetPlatformInfo();

        /// <summary>Converts a relative path within an app/extension install directory to a fully-qualified URL.</summary>
        /// <param name="path">A path to a resource within an app/extension expressed relative to its install directory.</param>
        /// <returns>The fully-qualified URL to the resource.</returns>
        ValueTask<string> GetURL(string path);

        /// <summary>Gets the 'id' property.</summary>
        /// <returns>The ID of the extension/app.</returns>
        ValueTask<string> GetId();

        /// <summary>Gets the 'lastError' property.</summary>
        /// <returns>This will be defined during an API method callback if there was an error</returns>
        ValueTask<LastError> GetLastError();

        /// <summary>Open your Extension's options page, if possible.<br />The precise behavior may depend on your manifest's <c>$(topic:optionsV2)[options_ui]</c> or <c>$(topic:options)[options_page]</c> key, or what the browser happens to support at the time.<br />If your Extension does not declare an options page, or the browser failed to create one for some other reason, the callback will set $(ref:lastError).<br /></summary>
        ValueTask OpenOptionsPage();

        /// <summary>Reloads the app or extension.</summary>
        ValueTask Reload();

        /// <summary>Sends a single message to event listeners within your extension/app or a different extension/app. Similar to $(ref:runtime.connect) but only sends a single message, with an optional response. If sending to your extension, the $(ref:runtime.onMessage) event will be fired in each page, or $(ref:runtime.onMessageExternal), if a different extension. Note that extensions cannot send messages to content scripts using this method. To send messages to content scripts, use $(ref:tabs.sendMessage).</summary>
        /// <param name="extensionId">The ID of the extension/app to send the message to. If omitted, the message will be sent to your own extension/app. Required if sending messages from a web page for $(topic:manifest/externally_connectable)[web messaging].</param>
        /// <param name="message"></param>
        /// <param name="options"></param>
        /// <returns>The JSON response object sent by the handler of the message. If an error occurs while connecting to the extension, the callback will be called with no arguments and $(ref:runtime.lastError) will be set to the error message.</returns>
        ValueTask<JsonElement> SendMessage(string extensionId, object message, object options);

        /// <summary>Send a single message to a native application.</summary>
        /// <param name="application">The name of the native messaging host.</param>
        /// <param name="message">The message that will be passed to the native messaging host.</param>
        /// <returns>The response message sent by the native messaging host. If an error occurs while connecting to the native messaging host, the callback will be called with no arguments and $(ref:runtime.lastError) will be set to the error message.</returns>
        ValueTask<JsonElement> SendNativeMessage(string application, object message);

        /// <summary>Sets the URL to be visited upon uninstallation. This may be used to clean up server-side data, do analytics, and implement surveys. Maximum 255 characters.</summary>
        /// <param name="url">URL to be opened after the extension is uninstalled. This URL must have an http: or https: scheme. Set an empty string to not open a new tab upon uninstallation.</param>
        ValueTask SetUninstallURL(string url);
    }
}
