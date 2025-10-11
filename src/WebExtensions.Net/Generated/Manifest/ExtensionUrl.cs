using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest;

// String Format Class
/// <summary></summary>
[JsonConverter(typeof(StringFormatJsonConverter<ExtensionUrl>))]
public partial class ExtensionUrl(string value) : BaseStringFormat(value, FORMAT, PATTERN)
{
    private const string FORMAT = "strictRelativeUrl";
    private const string PATTERN = "";

    /// <summary>Converts from <see cref="ExtensionUrl" /> to <see cref="string" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator string(ExtensionUrl value) => value.Value;

    /// <summary>Converts from <see cref="string" /> to <see cref="ExtensionUrl" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator ExtensionUrl(string value) => new(value);
}
