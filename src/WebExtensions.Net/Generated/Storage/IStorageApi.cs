namespace WebExtensions.Net.Storage
{
    /// <summary>Use the <c>browser.storage</c> API to store, retrieve, and track changes to user data.</summary>
    public partial interface IStorageApi
    {
        /// <summary>Items in the <c>local</c> storage area are local to each machine.</summary>
        StorageArea Local { get; }

        /// <summary>Items in the <c>managed</c> storage area are set by administrators or native applications, and are read-only for the extension; trying to modify this namespace results in an error.</summary>
        StorageArea Managed { get; }

        /// <summary>Fired when one or more items change.</summary>
        OnChangedEvent OnChanged { get; }

        /// <summary>Items in the <c>session</c> storage area are kept in memory, and only until the either browser or extension is closed or reloaded.</summary>
        StorageArea Session { get; }

        /// <summary>Items in the <c>sync</c> storage area are synced by the browser.</summary>
        StorageAreaSync Sync { get; }
    }
}
