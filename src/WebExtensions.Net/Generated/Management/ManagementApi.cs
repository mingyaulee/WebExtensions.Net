using System.Collections.Generic;
using System.Threading.Tasks;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.Management
{
    /// <inheritdoc />
    public partial class ManagementApi : BaseApi, IManagementApi
    {
        private OnDisabledEvent _onDisabled;
        private OnEnabledEvent _onEnabled;
        private OnInstalledEvent _onInstalled;
        private OnUninstalledEvent _onUninstalled;

        /// <summary>Creates a new instance of <see cref="ManagementApi" />.</summary>
        /// <param name="webExtensionsJSRuntime">Web Extension JS Runtime</param>
        public ManagementApi(IWebExtensionsJSRuntime webExtensionsJSRuntime) : base(webExtensionsJSRuntime, "management")
        {
        }

        /// <inheritdoc />
        public OnDisabledEvent OnDisabled
        {
            get
            {
                if (_onDisabled is null)
                {
                    _onDisabled = new OnDisabledEvent();
                    InitializeProperty("onDisabled", _onDisabled);
                }
                return _onDisabled;
            }
        }

        /// <inheritdoc />
        public OnEnabledEvent OnEnabled
        {
            get
            {
                if (_onEnabled is null)
                {
                    _onEnabled = new OnEnabledEvent();
                    InitializeProperty("onEnabled", _onEnabled);
                }
                return _onEnabled;
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
        public OnUninstalledEvent OnUninstalled
        {
            get
            {
                if (_onUninstalled is null)
                {
                    _onUninstalled = new OnUninstalledEvent();
                    InitializeProperty("onUninstalled", _onUninstalled);
                }
                return _onUninstalled;
            }
        }

        /// <inheritdoc />
        public virtual ValueTask<ExtensionInfo> Get(ExtensionID id)
        {
            return InvokeAsync<ExtensionInfo>("get", id);
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<ExtensionInfo>> GetAll()
        {
            return InvokeAsync<IEnumerable<ExtensionInfo>>("getAll");
        }

        /// <inheritdoc />
        public virtual ValueTask<ExtensionInfo> GetSelf()
        {
            return InvokeAsync<ExtensionInfo>("getSelf");
        }

        /// <inheritdoc />
        public virtual ValueTask<Result> Install(InstallOptions options)
        {
            return InvokeAsync<Result>("install", options);
        }

        /// <inheritdoc />
        public virtual ValueTask SetEnabled(string id, bool enabled)
        {
            return InvokeVoidAsync("setEnabled", id, enabled);
        }

        /// <inheritdoc />
        public virtual ValueTask UninstallSelf(UninstallSelfOptions options)
        {
            return InvokeVoidAsync("uninstallSelf", options);
        }
    }
}
