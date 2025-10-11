using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest;

// Multitype Class
/// <summary></summary>
[JsonConverter(typeof(MultiTypeJsonConverter<ThemeColor>))]
public partial class ThemeColor : BaseMultiTypeObject
{
    private readonly string valueString;

    /// <summary>Creates a new instance of <see cref="ThemeColor" />.</summary>
    /// <param name="value">The value.</param>
    public ThemeColor(string value) : base(value, typeof(string))
    {
        valueString = value;
    }

    /// <summary>Creates a new instance of <see cref="ThemeColor" />.</summary>
    /// <param name="value">The value.</param>
    public ThemeColor(IEnumerable<int> value) : base(value, typeof(IEnumerable<int>))
    {
    }

    /// <summary>Creates a new instance of <see cref="ThemeColor" />.</summary>
    /// <param name="value">The value.</param>
    public ThemeColor(IEnumerable<double> value) : base(value, typeof(IEnumerable<double>))
    {
    }

    /// <summary>Converts from <see cref="ThemeColor" /> to <see cref="string" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator string(ThemeColor value) => value.valueString;

    /// <summary>Converts from <see cref="string" /> to <see cref="ThemeColor" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator ThemeColor(string value) => new(value);
}
