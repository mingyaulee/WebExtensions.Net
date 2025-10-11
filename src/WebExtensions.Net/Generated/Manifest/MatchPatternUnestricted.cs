using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest;

// String Format Class
/// <summary>Mostly unrestricted match patterns for privileged add-ons. This should technically be rejected for unprivileged add-ons, but, reasons. The MatchPattern class will still refuse privileged schemes for those extensions.</summary>
[JsonConverter(typeof(StringFormatJsonConverter<MatchPatternUnestricted>))]
public partial class MatchPatternUnestricted(string value) : BaseStringFormat(value, FORMAT, PATTERN)
{
    private const string FORMAT = "";
    private const string PATTERN = "^resource://(\\*|\\*\\.[^*/]+|[^*/]+)/.*$|^about:";

    /// <summary>Converts from <see cref="MatchPatternUnestricted" /> to <see cref="string" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator string(MatchPatternUnestricted value) => value.Value;

    /// <summary>Converts from <see cref="string" /> to <see cref="MatchPatternUnestricted" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator MatchPatternUnestricted(string value) => new(value);
}
