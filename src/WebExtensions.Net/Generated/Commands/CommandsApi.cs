using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.Commands
{
    /// <inheritdoc />
    /// <param name="jsRuntime">The JS runtime adapter.</param>
    /// <param name="accessPath">The base API access path.</param>
    public partial class CommandsApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "commands")), ICommandsApi
    {
        private OnChangedEvent _onChanged;
        private OnCommandEvent _onCommand;

        /// <inheritdoc />
        public OnChangedEvent OnChanged
        {
            get
            {
                if (_onChanged is null)
                {
                    _onChanged = new OnChangedEvent();
                    _onChanged.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onChanged"));
                }
                return _onChanged;
            }
        }

        /// <inheritdoc />
        public OnCommandEvent OnCommand
        {
            get
            {
                if (_onCommand is null)
                {
                    _onCommand = new OnCommandEvent();
                    _onCommand.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onCommand"));
                }
                return _onCommand;
            }
        }

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<Command>> GetAll()
            => InvokeAsync<IEnumerable<Command>>("getAll");

        /// <inheritdoc />
        public virtual void OpenShortcutSettings()
            => InvokeVoid("openShortcutSettings");

        /// <inheritdoc />
        public virtual void Reset(string name)
            => InvokeVoid("reset", name);

        /// <inheritdoc />
        public virtual void Update(Detail detail)
            => InvokeVoid("update", detail);
    }
}
