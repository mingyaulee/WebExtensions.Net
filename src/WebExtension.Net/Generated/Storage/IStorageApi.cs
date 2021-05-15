using System.Threading.Tasks;

namespace WebExtension.Net.Storage
{
    /// <summary>Use the <c>browser.storage</c> API to store, retrieve, and track changes to user data.</summary>
    public interface IStorageApi
    {
        /// <summary>Fired when one or more items change.</summary>
        OnChangedEvent OnChanged { get; }

        /// <summary>Gets the 'local' property.</summary>
        /// <returns>Items in the <c>local</c> storage area are local to each machine.</returns>
        ValueTask<StorageArea> GetLocal();

        /// <summary>Gets the 'managed' property.</summary>
        /// <returns>Items in the <c>managed</c> storage area are set by administrators or native applications, and are read-only for the extension; trying to modify this namespace results in an error.</returns>
        ValueTask<StorageArea> GetManaged();

        /// <summary>Gets the 'sync' property.</summary>
        /// <returns>Items in the <c>sync</c> storage area are synced by the browser.</returns>
        ValueTask<StorageAreaSync> GetSync();
    }
}
