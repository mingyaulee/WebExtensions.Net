using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.Storage
{
    /// <inheritdoc />
    public class StorageApi : BaseApi, IStorageApi
    {
        /// <summary>Creates a new instance of StorageApi.</summary>
        /// <param name="webExtensionJSRuntime">Web Extension JS Runtime</param>
        public StorageApi(WebExtensionJSRuntime webExtensionJSRuntime) : base(webExtensionJSRuntime, "storage")
        {
        }

        
        
        // Property Getter Function Definition
        /// <summary>
        /// Items in the <c>sync</c> storage area are synced by the browser.
        /// </summary>
        /// <returns></returns>
        public virtual ValueTask<StorageAreaSync> GetSync()
        {
            return GetPropertyAsync<StorageAreaSync>("sync");
        }
        
        // Property Getter Function Definition
        /// <summary>
        /// Items in the <c>local</c> storage area are local to each machine.
        /// </summary>
        /// <returns></returns>
        public virtual ValueTask<StorageArea> GetLocal()
        {
            return GetPropertyAsync<StorageArea>("local");
        }
        
        // Property Getter Function Definition
        /// <summary>
        /// Items in the <c>managed</c> storage area are set by administrators or native applications, and are read-only for the extension; trying to modify this namespace results in an error.
        /// </summary>
        /// <returns></returns>
        public virtual ValueTask<StorageArea> GetManaged()
        {
            return GetPropertyAsync<StorageArea>("managed");
        }
        
    }
}
