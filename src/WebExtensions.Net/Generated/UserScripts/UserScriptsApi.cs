using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.UserScripts
{
    /// <inheritdoc />
    public partial class UserScriptsApi : BaseApi, IUserScriptsApi
    {
        private OnBeforeScriptEvent _onBeforeScript;

        /// <summary>Creates a new instance of <see cref="UserScriptsApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public UserScriptsApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "userScripts"))
        {
        }

        /// <inheritdoc />
        public OnBeforeScriptEvent OnBeforeScript
        {
            get
            {
                if (_onBeforeScript is null)
                {
                    _onBeforeScript = new OnBeforeScriptEvent();
                    _onBeforeScript.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onBeforeScript"));
                }
                return _onBeforeScript;
            }
        }

        /// <inheritdoc />
        public virtual void ConfigureWorld(WorldProperties properties)
            => InvokeVoid("configureWorld", properties);

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<RegisteredUserScript>> GetScripts(UserScriptFilter filter = null)
            => InvokeAsync<IEnumerable<RegisteredUserScript>>("getScripts", filter);

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<WorldProperties>> GetWorldConfigurations()
            => InvokeAsync<IEnumerable<WorldProperties>>("getWorldConfigurations");

        /// <inheritdoc />
        public virtual ValueTask<LegacyRegisteredUserScript> Register(UserScriptOptions userScriptOptions)
            => InvokeAsync<LegacyRegisteredUserScript>("register", userScriptOptions);

        /// <inheritdoc />
        public virtual void Register(IEnumerable<RegisteredUserScript> scripts)
            => InvokeVoid("register", scripts);

        /// <inheritdoc />
        public virtual void ResetWorldConfiguration(string worldId = null)
            => InvokeVoid("resetWorldConfiguration", worldId);

        /// <inheritdoc />
        public virtual void Unregister(UserScriptFilter filter = null)
            => InvokeVoid("unregister", filter);

        /// <inheritdoc />
        public virtual void Update(IEnumerable<Script> scripts)
            => InvokeVoid("update", scripts);
    }
}
