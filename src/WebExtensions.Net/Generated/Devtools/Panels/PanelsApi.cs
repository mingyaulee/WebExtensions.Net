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
