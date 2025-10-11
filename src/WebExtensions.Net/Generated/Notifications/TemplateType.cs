using System.Text.Json.Serialization;

namespace WebExtensions.Net.Notifications;

/// <summary></summary>
[JsonConverter(typeof(EnumStringConverter<TemplateType>))]
public enum TemplateType
{
    /// <summary>basic</summary>
    [EnumValue("basic")]
    Basic,

    /// <summary>image</summary>
    [EnumValue("image")]
    Image,

    /// <summary>list</summary>
    [EnumValue("list")]
    List,

    /// <summary>progress</summary>
    [EnumValue("progress")]
    Progress,
}
