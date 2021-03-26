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
    [JsonConverter(typeof(EnumStringConverter<OnBeforeSendHeadersOptions>))]
    public enum OnBeforeSendHeadersOptions
    {
        /// <summary>requestHeaders</summary>
        [EnumValue("requestHeaders")]
        RequestHeaders,
        /// <summary>blocking</summary>
        [EnumValue("blocking")]
        Blocking,
    }
}

