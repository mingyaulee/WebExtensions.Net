using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest;

// Multitype Class
/// <summary>Same as MatchPattern above, but excludes 'all_urls'</summary>
/// <param name="value">The value.</param>
[JsonConverter(typeof(MultiTypeJsonConverter<MatchPatternRestricted>))]
public partial class MatchPatternRestricted(string value) : BaseMultiTypeObject(value, typeof(string))
{
    private readonly string valueString;

    /// <summary>Converts from <see cref="MatchPatternRestricted" /> to <see cref="string" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator string(MatchPatternRestricted value) => value.valueString;

    /// <summary>Converts from <see cref="string" /> to <see cref="MatchPatternRestricted" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator MatchPatternRestricted(string value) => new(value);
}
