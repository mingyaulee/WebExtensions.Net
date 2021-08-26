using JsBind.Net;
using System.Threading.Tasks;

namespace WebExtensions.Net.Storage
{
    /// <inheritdoc />
    public partial class StorageApi : BaseApi, IStorageApi
    {
        private OnChangedEvent _onChanged;

        /// <summary>Creates a new instance of <see cref="StorageApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public StorageApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "storage"))
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
                    _onChanged.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onChanged"));
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
