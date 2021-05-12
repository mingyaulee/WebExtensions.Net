using System.Threading.Tasks;

namespace WebExtension.Net.Permissions
{
    /// <summary></summary>
    public interface IPermissionsApi
    {
        /// <summary>Check if the extension has the given permissions.</summary>
        /// <param name="permissions"></param>
        /// <returns></returns>
        ValueTask<bool> Contains(AnyPermissions permissions);

        /// <summary>Get a list of all the extension's permissions.</summary>
        /// <returns></returns>
        ValueTask<AnyPermissions> GetAll();

        /// <summary>Relinquish the given permissions.</summary>
        /// <param name="permissions"></param>
        ValueTask Remove(PermissionsType permissions);

        /// <summary>Request the given permissions.</summary>
        /// <param name="permissions"></param>
        /// <returns></returns>
        ValueTask<bool> Request(PermissionsType permissions);
    }
}
