using System.Threading.Tasks;
using WebExtensions.Net.Types;

namespace WebExtensions.Net.Privacy.Services
{
    /// <inheritdoc />
    public partial class ServicesApi : BaseApi, IServicesApi
    {
        /// <summary>Creates a new instance of <see cref="ServicesApi" />.</summary>
        /// <param name="webExtensionsJSRuntime">Web Extension JS Runtime</param>
        public ServicesApi(IWebExtensionsJSRuntime webExtensionsJSRuntime) : base(webExtensionsJSRuntime, "privacy.services")
        {
        }

        /// <inheritdoc />
        public virtual ValueTask<Setting> GetPasswordSavingEnabled()
        {
            return GetPropertyAsync<Setting>("passwordSavingEnabled");
        }
    }
}
