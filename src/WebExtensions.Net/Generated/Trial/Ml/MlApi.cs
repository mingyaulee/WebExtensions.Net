using JsBind.Net;

namespace WebExtensions.Net.Trial.Ml
{
    /// <inheritdoc />
    /// <param name="jsRuntime">The JS runtime adapter.</param>
    /// <param name="accessPath">The base API access path.</param>
    public partial class MlApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "ml")), IMlApi
    {
        private OnProgressEvent _onProgress;

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
