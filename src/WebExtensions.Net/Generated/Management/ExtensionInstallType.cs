using System.Text.Json.Serialization;

namespace WebExtensions.Net.Management
{
    /// <summary>How the extension was installed. One of<br /><c>development</c>: The extension was loaded unpacked in developer mode,<br /><c>normal</c>: The extension was installed normally via an .xpi file,<br /><c>sideload</c>: The extension was installed by other software on the machine,<br /><c>other</c>: The extension was installed by other means.</summary>
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

        /// <summary>other</summary>
        [EnumValue("other")]
        Other,
    }
}
