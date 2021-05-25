using System.Text.Json;
using System.Threading.Tasks;
using WebExtension.Net.Events;

namespace WebExtension.Net.Runtime
{
    /// <inheritdoc />
    public partial class RuntimeApi : BaseApi, IRuntimeApi
    {
        private OnConnectEvent _onConnect;
        private OnConnectExternalEvent _onConnectExternal;
        private OnInstalledEvent _onInstalled;
        private OnMessageEvent _onMessage;
        private OnMessageExternalEvent _onMessageExternal;
        private Event _onStartup;
        private OnUpdateAvailableEvent _onUpdateAvailable;

        /// <summary>Creates a new instance of <see cref="RuntimeApi" />.</summary>
        /// <param name="webExtensionJSRuntime">Web Extension JS Runtime</param>
        public RuntimeApi(IWebExtensionJSRuntime webExtensionJSRuntime) : base(webExtensionJSRuntime, "runtime")
        {
        }

        /// <inheritdoc />
        public OnConnectEvent OnConnect
        {
            get
            {
                if (_onConnect is null)
                {
                    _onConnect = new OnConnectEvent();
                    InitializeProperty("onConnect", _onConnect);
                }
                return _onConnect;
            }
        }

        /// <inheritdoc />
        public OnConnectExternalEvent OnConnectExternal
        {
            get
            {
                if (_onConnectExternal is null)
                {
                    _onConnectExternal = new OnConnectExternalEvent();
                    InitializeProperty("onConnectExternal", _onConnectExternal);
                }
                return _onConnectExternal;
            }
        }

        /// <inheritdoc />
        public OnInstalledEvent OnInstalled
        {
            get
            {
                if (_onInstalled is null)
                {
                    _onInstalled = new OnInstalledEvent();
                    InitializeProperty("onInstalled", _onInstalled);
                }
                return _onInstalled;
            }
        }

        /// <inheritdoc />
        public OnMessageEvent OnMessage
        {
            get
            {
                if (_onMessage is null)
                {
                    _onMessage = new OnMessageEvent();
                    InitializeProperty("onMessage", _onMessage);
                }
                return _onMessage;
            }
        }

        /// <inheritdoc />
        public OnMessageExternalEvent OnMessageExternal
        {
            get
            {
                if (_onMessageExternal is null)
                {
                    _onMessageExternal = new OnMessageExternalEvent();
                    InitializeProperty("onMessageExternal", _onMessageExternal);
                }
                return _onMessageExternal;
            }
        }

        /// <inheritdoc />
        public Event OnStartup
        {
            get
            {
                if (_onStartup is null)
                {
                    _onStartup = new Event();
                    InitializeProperty("onStartup", _onStartup);
                }
                return _onStartup;
            }
        }

        /// <inheritdoc />
        public OnUpdateAvailableEvent OnUpdateAvailable
        {
            get
            {
                if (_onUpdateAvailable is null)
                {
                    _onUpdateAvailable = new OnUpdateAvailableEvent();
                    InitializeProperty("onUpdateAvailable", _onUpdateAvailable);
                }
                return _onUpdateAvailable;
            }
        }

        /// <inheritdoc />
        public virtual ValueTask<Port> Connect(string extensionId, ConnectInfo connectInfo)
        {
            return InvokeAsync<Port>("connect", extensionId, connectInfo);
        }

        /// <inheritdoc />
        public virtual ValueTask<Port> ConnectNative(string application)
        {
            return InvokeAsync<Port>("connectNative", application);
        }

        /// <inheritdoc />
        public virtual ValueTask<JsonElement> GetBackgroundPage()
        {
            return InvokeAsync<JsonElement>("getBackgroundPage");
        }

        /// <inheritdoc />
        public virtual ValueTask<BrowserInfo> GetBrowserInfo()
        {
            return InvokeAsync<BrowserInfo>("getBrowserInfo");
        }

        /// <inheritdoc />
        public virtual ValueTask<JsonElement> GetManifest()
        {
            return InvokeAsync<JsonElement>("getManifest");
        }

        /// <inheritdoc />
        public virtual ValueTask<PlatformInfo> GetPlatformInfo()
        {
            return InvokeAsync<PlatformInfo>("getPlatformInfo");
        }

        /// <inheritdoc />
        public virtual ValueTask<string> GetURL(string path)
        {
            return InvokeAsync<string>("getURL", path);
        }

        /// <inheritdoc />
        public virtual ValueTask<string> GetId()
        {
            return GetPropertyAsync<string>("id");
        }

        /// <inheritdoc />
        public virtual ValueTask<LastError> GetLastError()
        {
            return GetPropertyAsync<LastError>("lastError");
        }

        /// <inheritdoc />
        public virtual ValueTask OpenOptionsPage()
        {
            return InvokeVoidAsync("openOptionsPage");
        }

        /// <inheritdoc />
        public virtual ValueTask Reload()
        {
            return InvokeVoidAsync("reload");
        }

        /// <inheritdoc />
        public virtual ValueTask<JsonElement> SendMessage(string extensionId, object message, object options)
        {
            return InvokeAsync<JsonElement>("sendMessage", extensionId, message, options);
        }

        /// <inheritdoc />
        public virtual ValueTask<JsonElement> SendNativeMessage(string application, object message)
        {
            return InvokeAsync<JsonElement>("sendNativeMessage", application, message);
        }

        /// <inheritdoc />
        public virtual ValueTask SetUninstallURL(string url)
        {
            return InvokeVoidAsync("setUninstallURL", url);
        }
    }
}
