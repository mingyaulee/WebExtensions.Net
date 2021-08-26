using JsBind.Net;
using System.Threading.Tasks;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.Devtools.Panels
{
    /// <inheritdoc />
    public partial class PanelsApi : BaseApi, IPanelsApi
    {
        private OnThemeChangedEvent _onThemeChanged;

        /// <summary>Creates a new instance of <see cref="PanelsApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public PanelsApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "panels"))
        {
        }

        /// <inheritdoc />
        public OnThemeChangedEvent OnThemeChanged
        {
            get
            {
                if (_onThemeChanged is null)
                {
                    _onThemeChanged = new OnThemeChangedEvent();
                    _onThemeChanged.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onThemeChanged"));
                }
                return _onThemeChanged;
            }
        }

        /// <inheritdoc />
        public virtual ValueTask<ExtensionPanel> Create(string title, string iconPath, ExtensionUrl pagePath)
        {
            return InvokeAsync<ExtensionPanel>("create", title, iconPath, pagePath);
        }

        /// <inheritdoc />
        public virtual ValueTask<ExtensionPanel> Create(string title, ExtensionUrl iconPath, ExtensionUrl pagePath)
        {
            return InvokeAsync<ExtensionPanel>("create", title, iconPath, pagePath);
        }

        /// <inheritdoc />
        public virtual ValueTask<ElementsPanel> GetElements()
        {
            return GetPropertyAsync<ElementsPanel>("elements");
        }

        /// <inheritdoc />
        public virtual ValueTask<SourcesPanel> GetSources()
        {
            return GetPropertyAsync<SourcesPanel>("sources");
        }

        /// <inheritdoc />
        public virtual ValueTask<string> GetThemeName()
        {
            return GetPropertyAsync<string>("themeName");
        }
    }
}
