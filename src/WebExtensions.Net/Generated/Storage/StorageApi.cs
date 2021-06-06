using System.Threading.Tasks;

namespace WebExtensions.Net.Storage
{
    /// <inheritdoc />
    public partial class StorageApi : BaseApi, IStorageApi
    {
        private OnChangedEvent _onChanged;

        /// <summary>Creates a new instance of <see cref="StorageApi" />.</summary>
        /// <param name="webExtensionsJSRuntime">Web Extension JS Runtime</param>
        public StorageApi(IWebExtensionsJSRuntime webExtensionsJSRuntime) : base(webExtensionsJSRuntime, "storage")
        {
        }

        /// <inheritdoc />
        public OnChangedEvent OnChanged
        {
            get
            {
                if (_onChanged is null)
                {
                    _onChanged = new OnChangedEvent();
                    InitializeProperty("onChanged", _onChanged);
                }
                return _onChanged;
            }
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
