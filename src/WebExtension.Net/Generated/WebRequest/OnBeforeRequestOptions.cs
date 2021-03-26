using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.WebRequest
{
    // Enum Definition
    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(EnumStringConverter<OnBeforeRequestOptions>))]
    public enum OnBeforeRequestOptions
    {
        /// <summary>blocking</summary>
        [EnumValue("blocking")]
        Blocking,
        /// <summary>requestBody</summary>
        [EnumValue("requestBody")]
        RequestBody,
    }
}

