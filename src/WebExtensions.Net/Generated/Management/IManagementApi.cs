using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.Management;

/// <summary>The <c>browser.management</c> API provides ways to manage the list of extensions that are installed and running.</summary>
[JsAccessPath("management")]
public partial interface IManagementApi
{
    /// <summary>Fired when an addon has been disabled.</summary>
    [JsAccessPath("onDisabled")]
    OnDisabledEvent OnDisabled { get; }

    /// <summary>Fired when an addon has been enabled.</summary>
    [JsAccessPath("onEnabled")]
    OnEnabledEvent OnEnabled { get; }

    /// <summary>Fired when an addon has been installed.</summary>
    [JsAccessPath("onInstalled")]
    OnInstalledEvent OnInstalled { get; }

    /// <summary>Fired when an addon has been uninstalled.</summary>
    [JsAccessPath("onUninstalled")]
    OnUninstalledEvent OnUninstalled { get; }

    /// <summary>Returns information about the installed extension that has the given ID.</summary>
    /// <param name="id">The ID from an item of $(ref:management.ExtensionInfo).</param>
    /// <returns></returns>
    [JsAccessPath("get")]
    ValueTask<ExtensionInfo> Get(ExtensionID id);

    /// <summary>Returns a list of information about installed extensions.</summary>
    /// <returns></returns>
    [JsAccessPath("getAll")]
    ValueTask<IEnumerable<ExtensionInfo>> GetAll();

    /// <summary>Returns information about the calling extension. Note: This function can be used without requesting the 'management' permission in the manifest.</summary>
    /// <returns></returns>
    [JsAccessPath("getSelf")]
    ValueTask<ExtensionInfo> GetSelf();

    /// <summary>Installs and enables a theme extension from the given url.</summary>
    /// <param name="options"></param>
    /// <returns></returns>
    [JsAccessPath("install")]
    ValueTask<Result> Install(InstallOptions options);

    /// <summary>Enables or disables the given add-on.</summary>
    /// <param name="id">ID of the add-on to enable/disable.</param>
    /// <param name="enabled">Whether to enable or disable the add-on.</param>
    [JsAccessPath("setEnabled")]
    ValueTask SetEnabled(string id, bool enabled);

    /// <summary>Uninstalls the calling extension. Note: This function can be used without requesting the 'management' permission in the manifest.</summary>
    /// <param name="options"></param>
    [JsAccessPath("uninstallSelf")]
    ValueTask UninstallSelf(UninstallSelfOptions options = null);
}
