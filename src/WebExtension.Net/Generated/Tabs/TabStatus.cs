// This file is auto generated at 2021-03-24T04:51:22

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Tabs
{
    // Enum Definition
    /// <summary>
    /// Whether the tabs have completed loading.
    /// </summary>
    [JsonConverter(typeof(EnumStringConverter<TabStatus>))]
    public enum TabStatus
    {
        /// <summary>loading</summary>
        [EnumValue("loading")]
        Loading,
        /// <summary>complete</summary>
        [EnumValue("complete")]
        Complete,
    }
}

