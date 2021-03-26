using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.WebRequest
{
    // Class Definition
    /// <summary>
    /// Contains data uploaded in a URL request.
    /// </summary>
    public class UploadData : BaseObject
    {
        
        // Property Definition
        private object _bytes;
        /// <summary>
        /// An ArrayBuffer with a copy of the data.
        /// </summary>
        [JsonPropertyName("bytes")]
        public object Bytes
        {
            get
            {
                InitializeProperty("bytes", _bytes);
                return _bytes;
            }
            set
            {
                _bytes = value;
            }
        }
        
        // Property Definition
        private string _file;
        /// <summary>
        /// A string with the file's path and name.
        /// </summary>
        [JsonPropertyName("file")]
        public string File
        {
            get
            {
                InitializeProperty("file", _file);
                return _file;
            }
            set
            {
                _file = value;
            }
        }
    }
}

