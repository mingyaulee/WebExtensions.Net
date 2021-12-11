using System.Threading.Tasks;
using WebExtensions.Net.Types;

namespace WebExtensions.Net.BrowserSettings.ColorManagement
{
    /// <summary>Use the <c>browserSettings.colorManagement</c> API to query and set items related to color management.</summary>
    public partial interface IColorManagementApi
    {
        /// <summary>Gets the 'mode' property.</summary>
        /// <returns>This setting controls the mode used for color management and must be a string from $(ref:browserSettings.ColorManagementMode)</returns>
        ValueTask<Setting> GetMode();

        /// <summary>Gets the 'useNativeSRGB' property.</summary>
        /// <returns>This boolean setting controls whether or not native sRGB color management is used.</returns>
        ValueTask<Setting> GetUseNativeSRGB();

        /// <summary>Gets the 'useWebRenderCompositor' property.</summary>
        /// <returns>This boolean setting controls whether or not the WebRender compositor is used.</returns>
        ValueTask<Setting> GetUseWebRenderCompositor();
    }
}
