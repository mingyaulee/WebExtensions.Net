using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.WebNavigation
{
    // Enum Definition
    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(EnumStringConverter<TransitionQualifier>))]
    public enum TransitionQualifier
    {
        /// <summary>client_redirect</summary>
        [EnumValue("client_redirect")]
        Client_redirect,
        /// <summary>server_redirect</summary>
        [EnumValue("server_redirect")]
        Server_redirect,
        /// <summary>forward_back</summary>
        [EnumValue("forward_back")]
        Forward_back,
        /// <summary>from_address_bar</summary>
        [EnumValue("from_address_bar")]
        From_address_bar,
    }
}

