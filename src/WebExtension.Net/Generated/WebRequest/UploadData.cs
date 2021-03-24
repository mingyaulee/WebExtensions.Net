// This file is auto generated at 2021-03-24T04:51:22

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
    public class UploadData
    {
        
        // Property Definition
        /// <summary>
        /// An ArrayBuffer with a copy of the data.
        /// </summary>
        [JsonPropertyName("bytes")]
        public object Bytes { get; set; }
        
        // Property Definition
        /// <summary>
        /// A string with the file's path and name.
        /// </summary>
        [JsonPropertyName("file")]
        public string File { get; set; }
    }
}

