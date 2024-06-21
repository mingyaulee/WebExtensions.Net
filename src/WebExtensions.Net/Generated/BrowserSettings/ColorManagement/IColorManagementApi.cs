using JsBind.Net;
using WebExtensions.Net.Types;

namespace WebExtensions.Net.BrowserSettings.ColorManagement
{
    /// <summary>Use the <c>browserSettings.colorManagement</c> API to query and set items related to color management.</summary>
    [JsAccessPath("colorManagement")]
    public partial interface IColorManagementApi
    {
        /// <summary>This setting controls the mode used for color management and must be a string from $(ref:browserSettings.ColorManagementMode)</summary>
        [JsAccessPath("mode")]
        Setting Mode { get; }

        /// <summary>This boolean setting controls whether or not native sRGB color management is used.</summary>
        [JsAccessPath("useNativeSRGB")]
        Setting UseNativeSRGB { get; }

        /// <summary>This boolean setting controls whether or not the WebRender compositor is used.</summary>
        [JsAccessPath("useWebRenderCompositor")]
        Setting UseWebRenderCompositor { get; }
    }
}
