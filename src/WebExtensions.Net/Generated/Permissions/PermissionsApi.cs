using JsBind.Net;
using System.Threading.Tasks;

namespace WebExtensions.Net.Permissions
{
    /// <inheritdoc />
    public partial class PermissionsApi : BaseApi, IPermissionsApi
    {
        private OnAddedEvent _onAdded;
        private OnRemovedEvent _onRemoved;

        /// <summary>Creates a new instance of <see cref="PermissionsApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public PermissionsApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "permissions"))
        {
        }

        /// <inheritdoc />
        public OnAddedEvent OnAdded
        {
            get
            {
                if (_onAdded is null)
                {
                    _onAdded = new OnAddedEvent();
                    _onAdded.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onAdded"));
                }
                return _onAdded;
            }
        }

        /// <inheritdoc />
        public OnRemovedEvent OnRemoved
        {
            get
            {
                if (_onRemoved is null)
                {
                    _onRemoved = new OnRemovedEvent();
                    _onRemoved.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onRemoved"));
                }
                return _onRemoved;
            }
        }

        /// <inheritdoc />
        public virtual ValueTask<bool> Contains(AnyPermissions permissions)
        {
            return InvokeAsync<bool>("contains", permissions);
        }

        /// <inheritdoc />
        public virtual ValueTask<AnyPermissions> GetAll()
        {
            return InvokeAsync<AnyPermissions>("getAll");
        }

        /// <inheritdoc />
        public virtual ValueTask Remove(PermissionsType permissions)
        {
            return InvokeVoidAsync("remove", permissions);
        }

        /// <inheritdoc />
        public virtual ValueTask<bool> Request(PermissionsType permissions)
        {
            return InvokeAsync<bool>("request", permissions);
        }
    }
}
