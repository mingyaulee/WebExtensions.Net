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
            => InvokeAsync<IEnumerable<InjectionResult>>("executeScript", injection);

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<RegisteredContentScript>> GetRegisteredContentScripts(ContentScriptFilter filter = null)
            => InvokeAsync<IEnumerable<RegisteredContentScript>>("getRegisteredContentScripts", filter);

        /// <inheritdoc />
        public virtual ValueTask InsertCSS(CSSInjection injection)
            => InvokeVoidAsync("insertCSS", injection);

        /// <inheritdoc />
        public virtual ValueTask RegisterContentScripts(IEnumerable<RegisteredContentScript> scripts)
            => InvokeVoidAsync("registerContentScripts", scripts);

        /// <inheritdoc />
        public virtual ValueTask RemoveCSS(CSSInjection injection)
            => InvokeVoidAsync("removeCSS", injection);

        /// <inheritdoc />
        public virtual ValueTask UnregisterContentScripts(ContentScriptFilter filter = null)
            => InvokeVoidAsync("unregisterContentScripts", filter);

        /// <inheritdoc />
        public virtual ValueTask UpdateContentScripts(IEnumerable<Script> scripts)
            => InvokeVoidAsync("updateContentScripts", scripts);
    }
}
