using System.Threading.Tasks;

namespace WebExtension.Net.Storage
{
    /// <summary>Use the <c>browser.storage</c> API to store, retrieve, and track changes to user data.</summary>
    public interface IStorageApi
    {
        /// <summary></summary>
        /// <returns>Items in the <c>sync</c> storage area are synced by the browser.</returns>
        ValueTask<StorageAreaSync> GetSync();

        /// <summary></summary>
        /// <returns>Items in the <c>local</c> storage area are local to each machine.</returns>
        ValueTask<StorageArea> GetLocal();

        /// <summary></summary>
        /// <returns>Items in the <c>managed</c> storage area are set by administrators or native applications, and are read-only for the extension; trying to modify this namespace results in an error.</returns>
        ValueTask<StorageArea> GetManaged();
    }
}
