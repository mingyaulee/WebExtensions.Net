using JsBind.Net;
using WebExtensions.Net.Trial.Ml;

namespace WebExtensions.Net.Trial
{
    /// <inheritdoc />
    /// <param name="jsRuntime">The JS runtime adapter.</param>
    /// <param name="accessPath">The base API access path.</param>
    public partial class TrialApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "trial")), ITrialApi
    {
        private IMlApi _ml;

        /// <inheritdoc />
        public IMlApi Ml => _ml ??= new MlApi(JsRuntime, AccessPath);
    }
}
