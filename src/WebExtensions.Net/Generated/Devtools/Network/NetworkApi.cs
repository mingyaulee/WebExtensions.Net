using JsBind.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtensions.Net.Devtools.Network
{
    /// <inheritdoc />
    public partial class NetworkApi : BaseApi, INetworkApi
    {
        private OnNavigatedEvent _onNavigated;
        private OnRequestFinishedEvent _onRequestFinished;

        /// <summary>Creates a new instance of <see cref="NetworkApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public NetworkApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "network"))
        {
        }

        /// <inheritdoc />
        public OnNavigatedEvent OnNavigated
        {
            get
            {
                if (_onNavigated is null)
                {
                    _onNavigated = new OnNavigatedEvent();
                    _onNavigated.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onNavigated"));
                }
                return _onNavigated;
            }
        }

        /// <inheritdoc />
        public OnRequestFinishedEvent OnRequestFinished
        {
            get
            {
                if (_onRequestFinished is null)
                {
                    _onRequestFinished = new OnRequestFinishedEvent();
                    _onRequestFinished.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onRequestFinished"));
                }
                return _onRequestFinished;
            }
        }

        /// <inheritdoc />
        public virtual ValueTask<JsonElement> GetHAR()
        {
            return InvokeAsync<JsonElement>("getHAR");
        }
    }
}
