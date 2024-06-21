using JsBind.Net;

namespace WebExtensions.Net.Storage
{
    /// <summary>Use the <c>browser.storage</c> API to store, retrieve, and track changes to user data.</summary>
    [JsAccessPath("storage")]
    public partial interface IStorageApi
    {
        /// <summary>Items in the <c>local</c> storage area are local to each machine.</summary>
        [JsAccessPath("local")]
        StorageArea Local { get; }

        /// <summary>Items in the <c>managed</c> storage area are set by administrators or native applications, and are read-only for the extension; trying to modify this namespace results in an error.</summary>
        [JsAccessPath("managed")]
        StorageArea Managed { get; }

        /// <summary>Fired when one or more items change.</summary>
        [JsAccessPath("onChanged")]
        OnChangedEvent OnChanged { get; }

        /// <summary>Items in the <c>session</c> storage area are kept in memory, and only until the either browser or extension is closed or reloaded.</summary>
        [JsAccessPath("session")]
        StorageArea Session { get; }

        /// <summary>Items in the <c>sync</c> storage area are synced by the browser.</summary>
        [JsAccessPath("sync")]
        StorageAreaSync Sync { get; }
    }
}
