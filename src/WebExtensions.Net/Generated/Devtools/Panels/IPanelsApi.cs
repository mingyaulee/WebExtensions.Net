using JsBind.Net;
using System.Threading.Tasks;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.Devtools.Panels
{
    /// <summary>Use the <c>chrome.devtools.panels</c> API to integrate your extension into Developer Tools window UI: create your own panels, access existing panels, and add sidebars.</summary>
    [JsAccessPath("panels")]
    public partial interface IPanelsApi
    {
        /// <summary>Elements panel.</summary>
        [JsAccessPath("elements")]
        ElementsPanel Elements { get; }

        /// <summary>Fired when the devtools theme changes.</summary>
        [JsAccessPath("onThemeChanged")]
        OnThemeChangedEvent OnThemeChanged { get; }

        /// <summary>Sources panel.</summary>
        [JsAccessPath("sources")]
        SourcesPanel Sources { get; }

        /// <summary>The name of the current devtools theme.</summary>
        [JsAccessPath("themeName")]
        string ThemeName { get; }

        /// <summary>Creates an extension panel.</summary>
        /// <param name="title">Title that is displayed next to the extension icon in the Developer Tools toolbar.</param>
        /// <param name="iconPath">Path of the panel's icon relative to the extension directory, or an empty string to use the default extension icon as the panel icon.</param>
        /// <param name="pagePath">Path of the panel's HTML page relative to the extension directory.</param>
        /// <returns>An ExtensionPanel object representing the created panel.</returns>
        [JsAccessPath("create")]
        ValueTask<ExtensionPanel> Create(string title, string iconPath, ExtensionUrl pagePath);

        /// <summary>Creates an extension panel.</summary>
        /// <param name="title">Title that is displayed next to the extension icon in the Developer Tools toolbar.</param>
        /// <param name="iconPath">Path of the panel's icon relative to the extension directory, or an empty string to use the default extension icon as the panel icon.</param>
        /// <param name="pagePath">Path of the panel's HTML page relative to the extension directory.</param>
        /// <returns>An ExtensionPanel object representing the created panel.</returns>
        [JsAccessPath("create")]
        ValueTask<ExtensionPanel> Create(string title, ExtensionUrl iconPath, ExtensionUrl pagePath);
    }
}
