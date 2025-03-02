using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Runtime
{
    /// <inheritdoc />
    public partial class RuntimeApi : BaseApi, IRuntimeApi
    {
        private OnConnectEvent _onConnect;
        private OnConnectExternalEvent _onConnectExternal;
        private OnInstalledEvent _onInstalled;
        private OnMessageEvent _onMessage;
        private OnMessageExternalEvent _onMessageExternal;
        private OnPerformanceWarningEvent _onPerformanceWarning;
        private Event _onStartup;
        private Event _onSuspend;
        private Event _onSuspendCanceled;
        private OnUpdateAvailableEvent _onUpdateAvailable;
        private OnUserScriptConnectEvent _onUserScriptConnect;
        private OnUserScriptMessageEvent _onUserScriptMessage;

        /// <summary>Creates a new instance of <see cref="RuntimeApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public RuntimeApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "runtime"))
        {
        }

        /// <inheritdoc />
        public string Id => GetProperty<string>("id");

        /// <inheritdoc />
        public LastError LastError => GetProperty<LastError>("lastError");

        /// <inheritdoc />
        public OnConnectEvent OnConnect
        {
            get
            {
                if (_onConnect is null)
                {
                    _onConnect = new OnConnectEvent();
                    _onConnect.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onConnect"));
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
                    _onConnectExternal.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onConnectExternal"));
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
                    _onInstalled.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onInstalled"));
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
                    _onMessage.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onMessage"));
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
                    _onMessageExternal.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onMessageExternal"));
                }
                return _onMessageExternal;
            }
        }

        /// <inheritdoc />
        public OnPerformanceWarningEvent OnPerformanceWarning
        {
            get
            {
                if (_onPerformanceWarning is null)
                {
                    _onPerformanceWarning = new OnPerformanceWarningEvent();
                    _onPerformanceWarning.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onPerformanceWarning"));
                }
                return _onPerformanceWarning;
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
                    _onStartup.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onStartup"));
                }
                return _onStartup;
            }
        }

        /// <inheritdoc />
        public Event OnSuspend
        {
            get
            {
                if (_onSuspend is null)
                {
                    _onSuspend = new Event();
                    _onSuspend.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onSuspend"));
                }
                return _onSuspend;
            }
        }

        /// <inheritdoc />
        public Event OnSuspendCanceled
        {
            get
            {
                if (_onSuspendCanceled is null)
                {
                    _onSuspendCanceled = new Event();
                    _onSuspendCanceled.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onSuspendCanceled"));
                }
                return _onSuspendCanceled;
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
                    _onUpdateAvailable.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onUpdateAvailable"));
                }
                return _onUpdateAvailable;
            }
        }

        /// <inheritdoc />
        public OnUserScriptConnectEvent OnUserScriptConnect
        {
            get
            {
                if (_onUserScriptConnect is null)
                {
                    _onUserScriptConnect = new OnUserScriptConnectEvent();
                    _onUserScriptConnect.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onUserScriptConnect"));
                }
                return _onUserScriptConnect;
            }
        }

        /// <inheritdoc />
        public OnUserScriptMessageEvent OnUserScriptMessage
        {
            get
            {
                if (_onUserScriptMessage is null)
                {
                    _onUserScriptMessage = new OnUserScriptMessageEvent();
                    _onUserScriptMessage.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onUserScriptMessage"));
                }
                return _onUserScriptMessage;
            }
        }

        /// <inheritdoc />
        public virtual Port Connect(string extensionId = null, ConnectInfo connectInfo = null)
            => Invoke<Port>("connect", extensionId, connectInfo);

        /// <inheritdoc />
        public virtual Port ConnectNative(string application)
            => Invoke<Port>("connectNative", application);

        /// <inheritdoc />
        public virtual ValueTask<JsonElement> GetBackgroundPage()
            => InvokeAsync<JsonElement>("getBackgroundPage");

        /// <inheritdoc />
        public virtual ValueTask<BrowserInfo> GetBrowserInfo()
            => InvokeAsync<BrowserInfo>("getBrowserInfo");

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<ExtensionContext>> GetContexts(ContextFilter filter)
            => InvokeAsync<IEnumerable<ExtensionContext>>("getContexts", filter);

        /// <inheritdoc />
        public virtual double GetFrameId(object target)
            => Invoke<double>("getFrameId", target);

        /// <inheritdoc />
        public virtual JsonElement GetManifest()
            => Invoke<JsonElement>("getManifest");

        /// <inheritdoc />
        public virtual ValueTask<PlatformInfo> GetPlatformInfo()
            => InvokeAsync<PlatformInfo>("getPlatformInfo");

        /// <inheritdoc />
        public virtual string GetURL(string path)
            => Invoke<string>("getURL", path);

        /// <inheritdoc />
        public virtual ValueTask OpenOptionsPage()
            => InvokeVoidAsync("openOptionsPage");

        /// <inheritdoc />
        public virtual void Reload()
            => InvokeVoid("reload");

        /// <inheritdoc />
        public virtual ValueTask<JsonElement> SendMessage(object message, object options = null)
            => InvokeAsync<JsonElement>("sendMessage", message, options);

        /// <inheritdoc />
        public virtual ValueTask<JsonElement> SendMessage(string extensionId, object message, object options = null)
            => InvokeAsync<JsonElement>("sendMessage", extensionId, message, options);

        /// <inheritdoc />
        public virtual ValueTask<JsonElement> SendNativeMessage(string application, object message)
            => InvokeAsync<JsonElement>("sendNativeMessage", application, message);

        /// <inheritdoc />
        public virtual ValueTask SetUninstallURL(string url = null)
            => InvokeVoidAsync("setUninstallURL", url);
    }
}
