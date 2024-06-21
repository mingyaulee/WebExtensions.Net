using JsBind.Net;
using System.Threading.Tasks;

namespace WebExtensions.Net.Permissions
{
    /// <summary></summary>
    [JsAccessPath("permissions")]
    public partial interface IPermissionsApi
    {
        /// <summary>Fired when the extension acquires new permissions.</summary>
        [JsAccessPath("onAdded")]
        OnAddedEvent OnAdded { get; }

        /// <summary>Fired when permissions are removed from the extension.</summary>
        [JsAccessPath("onRemoved")]
        OnRemovedEvent OnRemoved { get; }

        /// <summary>Check if the extension has the given permissions.</summary>
        /// <param name="permissions"></param>
        /// <returns></returns>
        [JsAccessPath("contains")]
        ValueTask<bool> Contains(AnyPermissions permissions);

        /// <summary>Get a list of all the extension's permissions.</summary>
        /// <returns></returns>
        [JsAccessPath("getAll")]
        ValueTask<AnyPermissions> GetAll();

        /// <summary>Relinquish the given permissions.</summary>
        /// <param name="permissions"></param>
        [JsAccessPath("remove")]
        ValueTask Remove(PermissionsType permissions);

        /// <summary>Request the given permissions.</summary>
        /// <param name="permissions"></param>
        /// <returns></returns>
        [JsAccessPath("request")]
        ValueTask<bool> Request(PermissionsType permissions);
    }
}
