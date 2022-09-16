using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.DeclarativeNetRequest
{
    /// <inheritdoc />
    public partial class DeclarativeNetRequestApi : BaseApi, IDeclarativeNetRequestApi
    {
        /// <summary>Creates a new instance of <see cref="DeclarativeNetRequestApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public DeclarativeNetRequestApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "declarativeNetRequest"))
        {
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<Rule>> GetSessionRules()
        {
            return InvokeAsync<IEnumerable<Rule>>("getSessionRules");
        }

        /// <inheritdoc />
        public virtual ValueTask<Result> TestMatchOutcome(Request request)
        {
            return InvokeAsync<Result>("testMatchOutcome", request);
        }

        /// <inheritdoc />
        public virtual ValueTask UpdateSessionRules(Options options)
        {
            return InvokeVoidAsync("updateSessionRules", options);
        }
    }
}
