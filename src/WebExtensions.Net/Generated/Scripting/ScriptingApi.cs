using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.Scripting
{
    /// <inheritdoc />
    public partial class ScriptingApi : BaseApi, IScriptingApi
    {
        /// <summary>Creates a new instance of <see cref="ScriptingApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public ScriptingApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "scripting"))
        {
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<InjectionResult>> ExecuteScript(ScriptInjection injection)
        {
            return InvokeAsync<IEnumerable<InjectionResult>>("executeScript", injection);
        }
    }
}
