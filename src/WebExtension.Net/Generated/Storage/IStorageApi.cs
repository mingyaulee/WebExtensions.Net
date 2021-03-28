using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.Storage
{
    /// <summary>
    /// Use the <c>browser.storage</c> API to store, retrieve, and track changes to user data.
    /// </summary>
    public interface IStorageApi
    {
        
        
        // Property Getter Function Definition Interface
        /// <summary>
        /// Items in the <c>sync</c> storage area are synced by the browser.
        /// </summary>
        /// <returns></returns>
        ValueTask<StorageAreaSync> GetSync();
        
        // Property Getter Function Definition Interface
        /// <summary>
        /// Items in the <c>local</c> storage area are local to each machine.
        /// </summary>
        /// <returns></returns>
        ValueTask<StorageArea> GetLocal();
        
        // Property Getter Function Definition Interface
        /// <summary>
        /// Items in the <c>managed</c> storage area are set by administrators or native applications, and are read-only for the extension; trying to modify this namespace results in an error.
        /// </summary>
        /// <returns></returns>
        ValueTask<StorageArea> GetManaged();
        
    }
}
