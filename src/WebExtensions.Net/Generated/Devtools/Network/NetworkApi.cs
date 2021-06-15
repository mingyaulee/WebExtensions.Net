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
        /// <param name="webExtensionsJSRuntime">Web Extension JS Runtime</param>
        public NetworkApi(IWebExtensionsJSRuntime webExtensionsJSRuntime) : base(webExtensionsJSRuntime, "devtools.network")
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
                    InitializeProperty("onNavigated", _onNavigated);
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
                    InitializeProperty("onRequestFinished", _onRequestFinished);
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
