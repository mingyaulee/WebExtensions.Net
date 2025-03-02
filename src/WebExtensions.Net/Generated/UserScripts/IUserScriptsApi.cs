using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.UserScripts
{
    /// <summary></summary>
    [JsAccessPath("userScripts")]
    public partial interface IUserScriptsApi
    {
        /// <summary>Event called when a new userScript global has been created</summary>
        [JsAccessPath("onBeforeScript")]
        OnBeforeScriptEvent OnBeforeScript { get; }

        /// <summary>Configures the environment for scripts running in a USER_SCRIPT world.</summary>
        /// <param name="properties">The desired configuration for a USER_SCRIPT world.</param>
        [JsAccessPath("configureWorld")]
        void ConfigureWorld(WorldProperties properties);

        /// <summary>Returns all dynamically-registered user scripts for this extension.</summary>
        /// <param name="filter">If specified, this method returns only the user scripts that match it.</param>
        /// <returns>List of registered user scripts.</returns>
        [JsAccessPath("getScripts")]
        ValueTask<IEnumerable<RegisteredUserScript>> GetScripts(UserScriptFilter filter = null);

        /// <summary>Returns all registered USER_SCRIPT world configurations.</summary>
        /// <returns>All configurations registered with configureWorld().</returns>
        [JsAccessPath("getWorldConfigurations")]
        ValueTask<IEnumerable<WorldProperties>> GetWorldConfigurations();

        /// <summary>Register a user script programmatically given its $(ref:userScripts.UserScriptOptions), and resolves to an object with the unregister() function</summary>
        /// <param name="userScriptOptions"></param>
        /// <returns>An object that represents a user script registered programmatically</returns>
        [JsAccessPath("register")]
        ValueTask<LegacyRegisteredUserScript> Register(UserScriptOptions userScriptOptions);

        /// <summary>Registers one or more user scripts for this extension.</summary>
        /// <param name="scripts">List of user scripts to be registered.</param>
        [JsAccessPath("register")]
        void Register(IEnumerable<RegisteredUserScript> scripts);

        /// <summary>Resets the configuration for a given world. That world will fall back to the default world's configuration.</summary>
        /// <param name="worldId">The ID of the USER_SCRIPT world to reset. If omitted or empty, resets the default world's configuration.</param>
        [JsAccessPath("resetWorldConfiguration")]
        void ResetWorldConfiguration(string worldId = null);

        /// <summary>Unregisters all dynamically-registered user scripts for this extension.</summary>
        /// <param name="filter">If specified, this method unregisters only the user scripts that match it.</param>
        [JsAccessPath("unregister")]
        void Unregister(UserScriptFilter filter = null);

        /// <summary>Updates one or more user scripts for this extension.</summary>
        /// <param name="scripts">List of user scripts to be updated.</param>
        [JsAccessPath("update")]
        void Update(IEnumerable<Script> scripts);
    }
}
