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
    [JsonConverter(typeof(EnumStringConverter<OnSendHeadersOptions>))]
    public enum OnSendHeadersOptions
    {
        /// <summary>requestHeaders</summary>
        [EnumValue("requestHeaders")]
        RequestHeaders,
    }
}

