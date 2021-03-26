using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Runtime
{
    // Class Definition
    /// <summary>
    /// An object containing information about the current browser.
    /// </summary>
    public class BrowserInfo : BaseObject
    {
        
        // Property Definition
        private string _name;
        /// <summary>
        /// The name of the browser, for example 'Firefox'.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get
            {
                InitializeProperty("name", _name);
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        
        // Property Definition
        private string _vendor;
        /// <summary>
        /// The name of the browser vendor, for example 'Mozilla'.
        /// </summary>
        [JsonPropertyName("vendor")]
        public string Vendor
        {
            get
            {
                InitializeProperty("vendor", _vendor);
                return _vendor;
            }
            set
            {
                _vendor = value;
            }
        }
        
        // Property Definition
        private string _version;
        /// <summary>
        /// The browser's version, for example '42.0.0' or '0.8.1pre'.
        /// </summary>
        [JsonPropertyName("version")]
        public string Version
        {
            get
            {
                InitializeProperty("version", _version);
                return _version;
            }
            set
            {
                _version = value;
            }
        }
        
        // Property Definition
        private string _buildID;
        /// <summary>
        /// The browser's build ID/date, for example '20160101'.
        /// </summary>
        [JsonPropertyName("buildID")]
        public string BuildID
        {
            get
            {
                InitializeProperty("buildID", _buildID);
                return _buildID;
            }
            set
            {
                _buildID = value;
            }
        }
    }
}

