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
    [JsonConverter(typeof(EnumStringConverter<TransportWeaknessReasons>))]
    public enum TransportWeaknessReasons
    {
        /// <summary>cipher</summary>
        [EnumValue("cipher")]
        Cipher,
    }
}

