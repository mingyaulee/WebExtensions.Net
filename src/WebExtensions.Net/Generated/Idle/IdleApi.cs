using System.Threading.Tasks;

namespace WebExtensions.Net.Idle
{
    /// <inheritdoc />
    public partial class IdleApi : BaseApi, IIdleApi
    {
        private OnStateChangedEvent _onStateChanged;

        /// <summary>Creates a new instance of <see cref="IdleApi" />.</summary>
        /// <param name="webExtensionsJSRuntime">Web Extension JS Runtime</param>
        public IdleApi(IWebExtensionsJSRuntime webExtensionsJSRuntime) : base(webExtensionsJSRuntime, "idle")
        {
        }

        /// <inheritdoc />
        public OnStateChangedEvent OnStateChanged
        {
            get
            {
                if (_onStateChanged is null)
                {
                    _onStateChanged = new OnStateChangedEvent();
                    InitializeProperty("onStateChanged", _onStateChanged);
                }
                return _onStateChanged;
            }
        }

        /// <inheritdoc />
        public virtual ValueTask<IdleState> QueryState(int detectionIntervalInSeconds)
        {
            return InvokeAsync<IdleState>("queryState", detectionIntervalInSeconds);
        }

        /// <inheritdoc />
        public virtual ValueTask SetDetectionInterval(int intervalInSeconds)
        {
            return InvokeVoidAsync("setDetectionInterval", intervalInSeconds);
        }
    }
}
