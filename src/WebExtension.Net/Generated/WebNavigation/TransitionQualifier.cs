/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.WebNavigation
{
    /// Enum Definition
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<TransitionQualifier>))]
    public enum TransitionQualifier
    {
        [EnumValue("client_redirect")]
        Client_redirect,
        [EnumValue("server_redirect")]
        Server_redirect,
        [EnumValue("forward_back")]
        Forward_back,
        [EnumValue("from_address_bar")]
        From_address_bar,
    }
}

