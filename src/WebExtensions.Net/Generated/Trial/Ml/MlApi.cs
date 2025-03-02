using JsBind.Net;

namespace WebExtensions.Net.Trial.Ml
{
    /// <inheritdoc />
    public partial class MlApi : BaseApi, IMlApi
    {
        private OnProgressEvent _onProgress;

        /// <summary>Creates a new instance of <see cref="MlApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public MlApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "ml"))
        {
        }

        /// <inheritdoc />
        public OnProgressEvent OnProgress
        {
            get
            {
                if (_onProgress is null)
                {
                    _onProgress = new OnProgressEvent();
                    _onProgress.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onProgress"));
                }
                return _onProgress;
            }
        }

        /// <inheritdoc />
        public virtual void CreateEngine(CreateEngineRequest CreateEngineRequest)
            => InvokeVoid("createEngine", CreateEngineRequest);

        /// <inheritdoc />
        public virtual void DeleteCachedModels()
            => InvokeVoid("deleteCachedModels");

        /// <inheritdoc />
        public virtual void RunEngine(RunEngineRequest RunEngineRequest)
            => InvokeVoid("runEngine", RunEngineRequest);
    }
}
