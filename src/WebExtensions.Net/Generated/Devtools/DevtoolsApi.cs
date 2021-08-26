using JsBind.Net;
using WebExtensions.Net.Devtools.InspectedWindow;
using WebExtensions.Net.Devtools.Network;
using WebExtensions.Net.Devtools.Panels;

namespace WebExtensions.Net.Devtools
{
    /// <inheritdoc />
    public partial class DevtoolsApi : BaseApi, IDevtoolsApi
    {
        private IInspectedWindowApi _inspectedWindow;
        private INetworkApi _network;
        private IPanelsApi _panels;

        /// <summary>Creates a new instance of <see cref="DevtoolsApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public DevtoolsApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "devtools"))
        {
        }

        /// <inheritdoc />
        public IInspectedWindowApi InspectedWindow
        {
            get
            {
                if (_inspectedWindow is null)
                {
                    _inspectedWindow = new InspectedWindowApi(JsRuntime, AccessPath);
                }
                return _inspectedWindow;
            }
        }

        /// <inheritdoc />
        public INetworkApi Network
        {
            get
            {
                if (_network is null)
                {
                    _network = new NetworkApi(JsRuntime, AccessPath);
                }
                return _network;
            }
        }

        /// <inheritdoc />
        public IPanelsApi Panels
        {
            get
            {
                if (_panels is null)
                {
                    _panels = new PanelsApi(JsRuntime, AccessPath);
                }
                return _panels;
            }
        }
    }
}
