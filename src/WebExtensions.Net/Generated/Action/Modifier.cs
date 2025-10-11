using System.Text.Json.Serialization;

namespace WebExtensions.Net.ActionNs;

/// <summary></summary>
[JsonConverter(typeof(EnumStringConverter<Modifier>))]
public enum Modifier
{
    /// <summary>Shift</summary>
    [EnumValue("Shift")]
    Shift,

    /// <summary>Alt</summary>
    [EnumValue("Alt")]
    Alt,

    /// <summary>Command</summary>
    [EnumValue("Command")]
    Command,

    /// <summary>Ctrl</summary>
    [EnumValue("Ctrl")]
    Ctrl,

    /// <summary>MacCtrl</summary>
    [EnumValue("MacCtrl")]
    MacCtrl,
}
