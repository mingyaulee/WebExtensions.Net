using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.Commands
{
    /// <inheritdoc />
    public partial class CommandsApi : BaseApi, ICommandsApi
    {
        private OnCommandEvent _onCommand;

        /// <summary>Creates a new instance of <see cref="CommandsApi" />.</summary>
        /// <param name="webExtensionsJSRuntime">Web Extension JS Runtime</param>
        public CommandsApi(IWebExtensionsJSRuntime webExtensionsJSRuntime) : base(webExtensionsJSRuntime, "commands")
        {
        }

        /// <inheritdoc />
        public OnCommandEvent OnCommand
        {
            get
            {
                if (_onCommand is null)
                {
                    _onCommand = new OnCommandEvent();
                    InitializeProperty("onCommand", _onCommand);
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
