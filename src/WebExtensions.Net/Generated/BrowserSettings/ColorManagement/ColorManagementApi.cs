using JsBind.Net;
using WebExtensions.Net.Types;

namespace WebExtensions.Net.BrowserSettings.ColorManagement
{
    /// <inheritdoc />
    public partial class ColorManagementApi : BaseApi, IColorManagementApi
    {
        /// <summary>Creates a new instance of <see cref="ColorManagementApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public ColorManagementApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "colorManagement"))
        {
        }

        /// <inheritdoc />
        public Setting Mode => GetProperty<Setting>("mode");

        /// <inheritdoc />
        public Setting UseNativeSRGB => GetProperty<Setting>("useNativeSRGB");

        /// <inheritdoc />
        public Setting UseWebRenderCompositor => GetProperty<Setting>("useWebRenderCompositor");
    }
}
