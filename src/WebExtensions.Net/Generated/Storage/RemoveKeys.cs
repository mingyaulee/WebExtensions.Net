using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Storage;

// Multitype Class
/// <summary>A single key or a list of keys for items to remove.</summary>
[JsonConverter(typeof(MultiTypeJsonConverter<RemoveKeys>))]
public partial class RemoveKeys : BaseMultiTypeObject
{
    private readonly string valueString;

    /// <summary>Creates a new instance of <see cref="RemoveKeys" />.</summary>
    /// <param name="value">The value.</param>
    public RemoveKeys(string value) : base(value, typeof(string))
    {
        valueString = value;
    }

    /// <summary>Creates a new instance of <see cref="RemoveKeys" />.</summary>
    /// <param name="value">The value.</param>
    public RemoveKeys(IEnumerable<string> value) : base(value, typeof(IEnumerable<string>))
    {
    }

    /// <summary>Converts from <see cref="RemoveKeys" /> to <see cref="string" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator string(RemoveKeys value) => value.valueString;

    /// <summary>Converts from <see cref="string" /> to <see cref="RemoveKeys" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator RemoveKeys(string value) => new(value);
}
