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

        /// <summary>Returns all dynamically registered content scripts for this extension that match the given filter.</summary>
        /// <param name="filter">An object to filter the extension's dynamically registered scripts.</param>
        /// <returns></returns>
        ValueTask<IEnumerable<RegisteredContentScript>> GetRegisteredContentScripts(ContentScriptFilter filter);

        /// <summary>Inserts a CSS stylesheet into a target context. If multiple frames are specified, unsuccessful injections are ignored.</summary>
        /// <param name="injection">The details of the styles to insert.</param>
        ValueTask InsertCSS(CSSInjection injection);

        /// <summary>Registers one or more content scripts for this extension.</summary>
        /// <param name="scripts">Contains a list of scripts to be registered. If there are errors during script parsing/file validation, or if the IDs specified already exist, then no scripts are registered.</param>
        ValueTask RegisterContentScripts(IEnumerable<RegisteredContentScript> scripts);

        /// <summary>Removes a CSS stylesheet that was previously inserted by this extension from a target context.</summary>
        /// <param name="injection">The details of the styles to remove. Note that the <c>css</c>, <c>files</c>, and <c>origin</c> properties must exactly match the stylesheet inserted through <c>insertCSS</c>. Attempting to remove a non-existent stylesheet is a no-op.</param>
        ValueTask RemoveCSS(CSSInjection injection);

        /// <summary>Unregisters one or more content scripts for this extension.</summary>
        /// <param name="filter">If specified, only unregisters dynamic content scripts which match the filter. Otherwise, all of the extension's dynamic content scripts are unregistered.</param>
        ValueTask UnregisterContentScripts(ContentScriptFilter filter);

        /// <summary>Updates one or more content scripts for this extension.</summary>
        /// <param name="scripts">Contains a list of scripts to be updated. If there are errors during script parsing/file validation, or if the IDs specified do not already exist, then no scripts are updated.</param>
        ValueTask UpdateContentScripts(IEnumerable<ScriptsArrayItem> scripts);
    }
}
