using WebExtensions.Net.Devtools.InspectedWindow;
using WebExtensions.Net.Devtools.Network;
using WebExtensions.Net.Devtools.Panels;

namespace WebExtensions.Net.Devtools
{
    /// <summary></summary>
    public partial interface IDevtoolsApi
    {
        /// <summary>Use the <c>chrome.devtools.inspectedWindow</c> API to interact with the inspected window: obtain the tab ID for the inspected page, evaluate the code in the context of the inspected window, reload the page, or obtain the list of resources within the page.</summary>
        IInspectedWindowApi InspectedWindow { get; }

        /// <summary>Use the <c>chrome.devtools.network</c> API to retrieve the information about network requests displayed by the Developer Tools in the Network panel.</summary>
        INetworkApi Network { get; }

        /// <summary>Use the <c>chrome.devtools.panels</c> API to integrate your extension into Developer Tools window UI: create your own panels, access existing panels, and add sidebars.</summary>
        IPanelsApi Panels { get; }
    }
}
