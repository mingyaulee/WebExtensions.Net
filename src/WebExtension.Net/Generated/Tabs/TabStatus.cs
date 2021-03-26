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

