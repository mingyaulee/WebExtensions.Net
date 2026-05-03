using System.Text.Json.Serialization;

namespace WebExtensions.Net.Management;

/// <summary>How the extension was installed.'dl''dt'development'/dt''dd'The extension was loaded unpacked in developer mode,'/dd''dt'normal'/dt''dd'The extension was installed normally via an .xpi file'/dd''dt'sideload'/dt''dd'The extension was installed by other software on the machine'/dd''dt'admin'/dt''dd'The extension was installed by policy'/dd''dt'other'/dt''dd'The extension was installed by other means.'/dd''/dl'</summary>
[JsonConverter(typeof(EnumStringConverter<ExtensionInstallType>))]
public enum ExtensionInstallType
{
    /// <summary>development</summary>
    [EnumValue("development")]
    Development,

    /// <summary>normal</summary>
    [EnumValue("normal")]
    Normal,

    /// <summary>sideload</summary>
    [EnumValue("sideload")]
    Sideload,

    /// <summary>admin</summary>
    [EnumValue("admin")]
    Admin,

    /// <summary>other</summary>
    [EnumValue("other")]
    Other,
}
