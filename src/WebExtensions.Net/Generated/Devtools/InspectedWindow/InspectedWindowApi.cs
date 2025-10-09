using JsBind.Net;
using System.Threading.Tasks;

namespace WebExtensions.Net.Devtools.InspectedWindow
{
    /// <inheritdoc />
    /// <param name="jsRuntime">The JS runtime adapter.</param>
    /// <param name="accessPath">The base API access path.</param>
    public partial class InspectedWindowApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "inspectedWindow")), IInspectedWindowApi
    {
        /// <inheritdoc />
        public int TabId => GetProperty<int>("tabId");

        /// <inheritdoc />
        public virtual ValueTask<EvalResult> Eval(string expression, object options = null)
            => InvokeAsync<EvalResult>("eval", expression, options);

        /// <inheritdoc />
        public virtual void Reload(ReloadOptions reloadOptions = null)
            => InvokeVoid("reload", reloadOptions);
    }
}
