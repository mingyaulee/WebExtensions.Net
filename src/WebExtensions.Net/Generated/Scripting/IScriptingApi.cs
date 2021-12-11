using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.Scripting
{
    /// <summary>Use the scripting API to execute script in different contexts.</summary>
    public partial interface IScriptingApi
    {
        /// <summary>Injects a script into a target context. The script will be run at <c>document_idle</c>.</summary>
        /// <param name="injection">The details of the script which to inject.</param>
        /// <returns></returns>
        ValueTask<IEnumerable<InjectionResult>> ExecuteScript(ScriptInjection injection);
    }
}
