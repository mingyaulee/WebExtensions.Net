using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs;

/// <summary>Event names supported in onUpdated.</summary>
[JsonConverter(typeof(EnumStringConverter<UpdatePropertyName>))]
public enum UpdatePropertyName
{
    /// <summary>attention</summary>
    [EnumValue("attention")]
    Attention,

    /// <summary>audible</summary>
    [EnumValue("audible")]
    Audible,

    /// <summary>autoDiscardable</summary>
    [EnumValue("autoDiscardable")]
    AutoDiscardable,

    /// <summary>discarded</summary>
    [EnumValue("discarded")]
    Discarded,

    /// <summary>favIconUrl</summary>
    [EnumValue("favIconUrl")]
    FavIconUrl,

    /// <summary>groupId</summary>
    [EnumValue("groupId")]
    GroupId,

    /// <summary>hidden</summary>
    [EnumValue("hidden")]
    Hidden,

    /// <summary>isArticle</summary>
    [EnumValue("isArticle")]
    IsArticle,

    /// <summary>mutedInfo</summary>
    [EnumValue("mutedInfo")]
    MutedInfo,

    /// <summary>pinned</summary>
    [EnumValue("pinned")]
    Pinned,

    /// <summary>sharingState</summary>
    [EnumValue("sharingState")]
    SharingState,

    /// <summary>status</summary>
    [EnumValue("status")]
    Status,

    /// <summary>title</summary>
    [EnumValue("title")]
    Title,

    /// <summary>url</summary>
    [EnumValue("url")]
    Url,
}
