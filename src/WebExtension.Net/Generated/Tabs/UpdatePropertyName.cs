/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Tabs
{
    /// Enum Definition
    /// <summary>Event names supported in onUpdated.</summary>
    [JsonConverter(typeof(EnumStringConverter<UpdatePropertyName>))]
    public enum UpdatePropertyName
    {
        [EnumValue("attention")]
        Attention,
        [EnumValue("audible")]
        Audible,
        [EnumValue("discarded")]
        Discarded,
        [EnumValue("favIconUrl")]
        FavIconUrl,
        [EnumValue("hidden")]
        Hidden,
        [EnumValue("isArticle")]
        IsArticle,
        [EnumValue("mutedInfo")]
        MutedInfo,
        [EnumValue("pinned")]
        Pinned,
        [EnumValue("sharingState")]
        SharingState,
        [EnumValue("status")]
        Status,
        [EnumValue("title")]
        Title,
        [EnumValue("url")]
        Url,
    }
}

