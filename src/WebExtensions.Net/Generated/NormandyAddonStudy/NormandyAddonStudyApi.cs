using JsBind.Net;

namespace WebExtensions.Net.NormandyAddonStudy
{
    /// <inheritdoc />
    /// <param name="jsRuntime">The JS runtime adapter.</param>
    /// <param name="accessPath">The base API access path.</param>
    public partial class NormandyAddonStudyApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "normandyAddonStudy")), INormandyAddonStudyApi
    {
        private OnUnenrollEvent _onUnenroll;

        /// <inheritdoc />
        public OnUnenrollEvent OnUnenroll
        {
            get
            {
                if (_onUnenroll is null)
                {
                    _onUnenroll = new OnUnenrollEvent();
                    _onUnenroll.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onUnenroll"));
                }
                return _onUnenroll;
            }
        }

        /// <inheritdoc />
        public virtual void EndStudy(string reason)
            => InvokeVoid("endStudy", reason);

        /// <inheritdoc />
        public virtual void GetClientMetadata()
            => InvokeVoid("getClientMetadata");

        /// <inheritdoc />
        public virtual void GetStudy()
            => InvokeVoid("getStudy");
    }
}
