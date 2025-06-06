using JsBind.Net;

namespace WebExtensions.Net.GeckoProfiler
{
    /// <inheritdoc />
    public partial class GeckoProfilerApi : BaseApi, IGeckoProfilerApi
    {
        private OnRunningEvent _onRunning;

        /// <summary>Creates a new instance of <see cref="GeckoProfilerApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public GeckoProfilerApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "geckoProfiler"))
        {
        }

        /// <inheritdoc />
        public OnRunningEvent OnRunning
        {
            get
            {
                if (_onRunning is null)
                {
                    _onRunning = new OnRunningEvent();
                    _onRunning.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onRunning"));
                }
                return _onRunning;
            }
        }

        /// <inheritdoc />
        public virtual void DumpProfileToFile(string fileName)
            => InvokeVoid("dumpProfileToFile", fileName);

        /// <inheritdoc />
        public virtual void GetProfile()
            => InvokeVoid("getProfile");

        /// <inheritdoc />
        public virtual void GetProfileAsArrayBuffer()
            => InvokeVoid("getProfileAsArrayBuffer");

        /// <inheritdoc />
        public virtual void GetProfileAsGzippedArrayBuffer()
            => InvokeVoid("getProfileAsGzippedArrayBuffer");

        /// <inheritdoc />
        public virtual void GetSymbols(string debugName, string breakpadId)
            => InvokeVoid("getSymbols", debugName, breakpadId);

        /// <inheritdoc />
        public virtual void Pause()
            => InvokeVoid("pause");

        /// <inheritdoc />
        public virtual void Resume()
            => InvokeVoid("resume");

        /// <inheritdoc />
        public virtual void Start(Settings settings)
            => InvokeVoid("start", settings);

        /// <inheritdoc />
        public virtual void Stop()
            => InvokeVoid("stop");
    }
}
