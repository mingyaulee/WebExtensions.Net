/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Tabs
{
    /// Enum Definition
    /// <summary>Whether the tabs have completed loading.</summary>
    [JsonConverter(typeof(EnumStringConverter<TabStatus>))]
    public enum TabStatus
    {
        [EnumValue("loading")]
        Loading,
        [EnumValue("complete")]
        Complete,
    }
}

