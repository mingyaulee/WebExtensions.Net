using System.Threading.Tasks;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.Devtools.Panels
{
    /// <summary>Use the <c>chrome.devtools.panels</c> API to integrate your extension into Developer Tools window UI: create your own panels, access existing panels, and add sidebars.</summary>
    public partial interface IPanelsApi
    {
        /// <summary>Fired when the devtools theme changes.</summary>
        OnThemeChangedEvent OnThemeChanged { get; }

        /// <summary>Creates an extension panel.</summary>
        /// <param name="title">Title that is displayed next to the extension icon in the Developer Tools toolbar.</param>
        /// <param name="iconPath">Path of the panel's icon relative to the extension directory, or an empty string to use the default extension icon as the panel icon.</param>
        /// <param name="pagePath">Path of the panel's HTML page relative to the extension directory.</param>
        /// <returns>An ExtensionPanel object representing the created panel.</returns>
        ValueTask<ExtensionPanel> Create(string title, string iconPath, ExtensionUrl pagePath);

        /// <summary>Creates an extension panel.</summary>
        /// <param name="title">Title that is displayed next to the extension icon in the Developer Tools toolbar.</param>
        /// <param name="iconPath">Path of the panel's icon relative to the extension directory, or an empty string to use the default extension icon as the panel icon.</param>
        /// <param name="pagePath">Path of the panel's HTML page relative to the extension directory.</param>
        /// <returns>An ExtensionPanel object representing the created panel.</returns>
        ValueTask<ExtensionPanel> Create(string title, ExtensionUrl iconPath, ExtensionUrl pagePath);

        /// <summary>Gets the 'elements' property.</summary>
        /// <returns>Elements panel.</returns>
        ValueTask<ElementsPanel> GetElements();

        /// <summary>Gets the 'sources' property.</summary>
        /// <returns>Sources panel.</returns>
        ValueTask<SourcesPanel> GetSources();

        /// <summary>Gets the 'themeName' property.</summary>
        /// <returns>The name of the current devtools theme.</returns>
        ValueTask<string> GetThemeName();
    }
}
