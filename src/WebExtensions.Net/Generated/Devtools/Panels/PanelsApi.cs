using JsBind.Net;
using System.Threading.Tasks;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.Devtools.Panels
{
    /// <inheritdoc />
    /// <param name="jsRuntime">The JS runtime adapter.</param>
    /// <param name="accessPath">The base API access path.</param>
    public partial class PanelsApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "panels")), IPanelsApi
    {
        private OnThemeChangedEvent _onThemeChanged;

        /// <inheritdoc />
        public ElementsPanel Elements => GetProperty<ElementsPanel>("elements");

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
        public SourcesPanel Sources => GetProperty<SourcesPanel>("sources");

        /// <inheritdoc />
        public string ThemeName => GetProperty<string>("themeName");

        /// <inheritdoc />
        public virtual ValueTask<ExtensionPanel> Create(string title, string iconPath, ExtensionUrl pagePath)
            => InvokeAsync<ExtensionPanel>("create", title, iconPath, pagePath);

        /// <inheritdoc />
        public virtual ValueTask<ExtensionPanel> Create(string title, ExtensionUrl iconPath, ExtensionUrl pagePath)
            => InvokeAsync<ExtensionPanel>("create", title, iconPath, pagePath);
    }
}
