using System.Threading.Tasks;

namespace WebExtension.Net.Storage
{
    /// <inheritdoc />
    public class StorageApi : BaseApi, IStorageApi
    {
        /// <summary>Creates a new instance of <see cref="StorageApi" />.</summary>
        /// <param name="webExtensionJSRuntime">Web Extension JS Runtime</param>
        public StorageApi(WebExtensionJSRuntime webExtensionJSRuntime) : base(webExtensionJSRuntime, "storage")
        {
        }

        /// <inheritdoc />
        public virtual ValueTask<StorageArea> GetLocal()
        {
            return GetPropertyAsync<StorageArea>("local");
        }

        /// <inheritdoc />
        public virtual ValueTask<StorageArea> GetManaged()
        {
            return GetPropertyAsync<StorageArea>("managed");
        }

        /// <inheritdoc />
        public virtual ValueTask<StorageAreaSync> GetSync()
        {
            return GetPropertyAsync<StorageAreaSync>("sync");
        }
    }
}
