using JsBind.Net;
using System.Threading.Tasks;

namespace WebExtensions.Net.Idle
{
    /// <inheritdoc />
    public partial class IdleApi : BaseApi, IIdleApi
    {
        private OnStateChangedEvent _onStateChanged;

        /// <summary>Creates a new instance of <see cref="IdleApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public IdleApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "idle"))
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
                    _onStateChanged.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onStateChanged"));
                }
                return _onStateChanged;
            }
        }

        /// <inheritdoc />
        public virtual ValueTask<IdleState> QueryState(int detectionIntervalInSeconds)
            => InvokeAsync<IdleState>("queryState", detectionIntervalInSeconds);

        /// <inheritdoc />
        public virtual void SetDetectionInterval(int intervalInSeconds)
            => InvokeVoid("setDetectionInterval", intervalInSeconds);
    }
}
