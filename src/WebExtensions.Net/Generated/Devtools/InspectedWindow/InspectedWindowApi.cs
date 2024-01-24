using JsBind.Net;
using System.Threading.Tasks;

namespace WebExtensions.Net.Devtools.InspectedWindow
{
    /// <inheritdoc />
    public partial class InspectedWindowApi : BaseApi, IInspectedWindowApi
    {
        /// <summary>Creates a new instance of <see cref="InspectedWindowApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public InspectedWindowApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "inspectedWindow"))
        {
        }

        /// <inheritdoc />
        public int TabId => GetProperty<int>("tabId");

        /// <inheritdoc />
        public virtual ValueTask<EvalResult> Eval(string expression, object options)
        {
            return InvokeAsync<EvalResult>("eval", expression, options);
        }

        /// <inheritdoc />
        public virtual ValueTask Reload(ReloadOptions reloadOptions)
        {
            return InvokeVoidAsync("reload", reloadOptions);
        }
    }
}
