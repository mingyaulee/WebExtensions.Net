using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.Commands
{
    /// <inheritdoc />
    public partial class CommandsApi : BaseApi, ICommandsApi
    {
        private OnChangedEvent _onChanged;
        private OnCommandEvent _onCommand;

        /// <summary>Creates a new instance of <see cref="CommandsApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public CommandsApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "commands"))
        {
        }

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
        {
            return InvokeAsync<IEnumerable<Command>>("getAll");
        }

        /// <inheritdoc />
        public virtual ValueTask Reset(string name)
        {
            return InvokeVoidAsync("reset", name);
        }

        /// <inheritdoc />
        public virtual ValueTask Update(Detail detail)
        {
            return InvokeVoidAsync("update", detail);
        }
    }
}
