using System.Text.Json.Serialization;

namespace WebExtensions.Net.TabGroups;

/// <summary>The group's color, using 'grey' spelling for compatibility with Chromium.</summary>
[JsonConverter(typeof(EnumStringConverter<Color>))]
public enum Color
{
    /// <summary>blue</summary>
    [EnumValue("blue")]
    Blue,

    /// <summary>cyan</summary>
    [EnumValue("cyan")]
    Cyan,

    /// <summary>grey</summary>
    [EnumValue("grey")]
    Grey,

    /// <summary>green</summary>
    [EnumValue("green")]
    Green,

    /// <summary>orange</summary>
    [EnumValue("orange")]
    Orange,

    /// <summary>pink</summary>
    [EnumValue("pink")]
    Pink,

    /// <summary>purple</summary>
    [EnumValue("purple")]
    Purple,

    /// <summary>red</summary>
    [EnumValue("red")]
    Red,

    /// <summary>yellow</summary>
    [EnumValue("yellow")]
    Yellow,
}
