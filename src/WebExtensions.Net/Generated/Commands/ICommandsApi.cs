using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.Commands
{
    /// <summary>Use the commands API to add keyboard shortcuts that trigger actions in your extension, for example, an action to open the browser action or send a command to the xtension.</summary>
    [JsAccessPath("commands")]
    public partial interface ICommandsApi
    {
        /// <summary>Fired when a registered command's shortcut is changed.</summary>
        [JsAccessPath("onChanged")]
        OnChangedEvent OnChanged { get; }

        /// <summary>Fired when a registered command is activated using a keyboard shortcut.</summary>
        [JsAccessPath("onCommand")]
        OnCommandEvent OnCommand { get; }

        /// <summary>Returns all the registered extension commands for this extension and their shortcut (if active).</summary>
        /// <returns></returns>
        [JsAccessPath("getAll")]
        ValueTask<IEnumerable<Command>> GetAll();

        /// <summary>Open extension shortcuts configuration page.</summary>
        [JsAccessPath("openShortcutSettings")]
        void OpenShortcutSettings();

        /// <summary>Reset a command's details to what is specified in the manifest.</summary>
        /// <param name="name">The name of the command.</param>
        [JsAccessPath("reset")]
        void Reset(string name);

        /// <summary>Update the details of an already defined command.</summary>
        /// <param name="detail">The new description for the command.</param>
        [JsAccessPath("update")]
        void Update(Detail detail);
    }
}
