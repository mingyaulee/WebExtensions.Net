using System.Threading.Tasks;

namespace WebExtension.Net.Permissions
{
    /// <inheritdoc />
    public class PermissionsApi : BaseApi, IPermissionsApi
    {
        /// <summary>Creates a new instance of <see cref="PermissionsApi" />.</summary>
        /// <param name="webExtensionJSRuntime">Web Extension JS Runtime</param>
        public PermissionsApi(WebExtensionJSRuntime webExtensionJSRuntime) : base(webExtensionJSRuntime, "permissions")
        {
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
