using System.Collections.Generic;
using System.Threading.Tasks;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.Management
{
    /// <summary>The <c>browser.management</c> API provides ways to manage the list of extensions that are installed and running.</summary>
    public partial interface IManagementApi
    {
        /// <summary>Fired when an addon has been disabled.</summary>
        OnDisabledEvent OnDisabled { get; }

        /// <summary>Fired when an addon has been enabled.</summary>
        OnEnabledEvent OnEnabled { get; }

        /// <summary>Fired when an addon has been installed.</summary>
        OnInstalledEvent OnInstalled { get; }

        /// <summary>Fired when an addon has been uninstalled.</summary>
        OnUninstalledEvent OnUninstalled { get; }

        /// <summary>Returns information about the installed extension that has the given ID.</summary>
        /// <param name="id">The ID from an item of $(ref:management.ExtensionInfo).</param>
        /// <returns></returns>
        ValueTask<ExtensionInfo> Get(ExtensionID id);

        /// <summary>Returns a list of information about installed extensions.</summary>
        /// <returns></returns>
        ValueTask<IEnumerable<ExtensionInfo>> GetAll();

        /// <summary>Returns information about the calling extension. Note: This function can be used without requesting the 'management' permission in the manifest.</summary>
        /// <returns></returns>
        ValueTask<ExtensionInfo> GetSelf();

        /// <summary>Installs and enables a theme extension from the given url.</summary>
        /// <param name="options"></param>
        /// <returns></returns>
        ValueTask<Result> Install(InstallOptions options);

        /// <summary>Enables or disables the given add-on.</summary>
        /// <param name="id">ID of the add-on to enable/disable.</param>
        /// <param name="enabled">Whether to enable or disable the add-on.</param>
        ValueTask SetEnabled(string id, bool enabled);

        /// <summary>Uninstalls the calling extension. Note: This function can be used without requesting the 'management' permission in the manifest.</summary>
        /// <param name="options"></param>
        ValueTask UninstallSelf(UninstallSelfOptions options);
    }
}
