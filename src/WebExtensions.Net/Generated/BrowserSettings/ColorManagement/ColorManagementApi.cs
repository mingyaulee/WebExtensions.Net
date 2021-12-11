using JsBind.Net;
using System.Threading.Tasks;
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
        public virtual ValueTask<Setting> GetMode()
        {
            return GetPropertyAsync<Setting>("mode");
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetUseNativeSRGB()
        {
            return GetPropertyAsync<Setting>("useNativeSRGB");
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetUseWebRenderCompositor()
        {
            return GetPropertyAsync<Setting>("useWebRenderCompositor");
        }
    }
}
