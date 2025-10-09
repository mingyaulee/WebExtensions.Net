using JsBind.Net;
using WebExtensions.Net.Types;

namespace WebExtensions.Net.BrowserSettings.ColorManagement
{
    /// <inheritdoc />
    /// <param name="jsRuntime">The JS runtime adapter.</param>
    /// <param name="accessPath">The base API access path.</param>
    public partial class ColorManagementApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "colorManagement")), IColorManagementApi
    {
        /// <inheritdoc />
        public Setting Mode => GetProperty<Setting>("mode");

        /// <inheritdoc />
        public Setting UseNativeSRGB => GetProperty<Setting>("useNativeSRGB");

        /// <inheritdoc />
        public Setting UseWebRenderCompositor => GetProperty<Setting>("useWebRenderCompositor");
    }
}
