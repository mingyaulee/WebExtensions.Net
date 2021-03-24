// This file is auto generated at 2021-03-24T04:51:22

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

