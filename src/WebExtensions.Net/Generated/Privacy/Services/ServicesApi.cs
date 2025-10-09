using JsBind.Net;
using WebExtensions.Net.Types;

namespace WebExtensions.Net.Privacy.Services
{
    /// <inheritdoc />
    /// <param name="jsRuntime">The JS runtime adapter.</param>
    /// <param name="accessPath">The base API access path.</param>
    public partial class ServicesApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "services")), IServicesApi
    {
        /// <inheritdoc />
        public Setting PasswordSavingEnabled => GetProperty<Setting>("passwordSavingEnabled");
    }
}
