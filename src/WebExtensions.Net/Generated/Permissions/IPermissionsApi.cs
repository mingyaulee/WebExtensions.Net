using System.Threading.Tasks;

namespace WebExtensions.Net.Permissions
{
    /// <summary></summary>
    public partial interface IPermissionsApi
    {
        /// <summary>Fired when the extension acquires new permissions.</summary>
        OnAddedEvent OnAdded { get; }

        /// <summary>Fired when permissions are removed from the extension.</summary>
        OnRemovedEvent OnRemoved { get; }

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
