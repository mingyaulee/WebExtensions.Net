using JsBind.Net;

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
        public StorageArea Local => GetProperty<StorageArea>("local");

        /// <inheritdoc />
        public StorageArea Managed => GetProperty<StorageArea>("managed");

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
        public StorageAreaWithUsage Session => GetProperty<StorageAreaWithUsage>("session");

        /// <inheritdoc />
        public StorageAreaWithUsage Sync => GetProperty<StorageAreaWithUsage>("sync");
    }
}
