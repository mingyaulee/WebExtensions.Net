using JsBind.Net;
using WebExtensions.Net.Trial.Ml;

namespace WebExtensions.Net.Trial
{
    /// <inheritdoc />
    public partial class TrialApi : BaseApi, ITrialApi
    {
        private IMlApi _ml;

        /// <summary>Creates a new instance of <see cref="TrialApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public TrialApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "trial"))
        {
        }

        /// <inheritdoc />
        public IMlApi Ml => _ml ??= new MlApi(JsRuntime, AccessPath);
    }
}
