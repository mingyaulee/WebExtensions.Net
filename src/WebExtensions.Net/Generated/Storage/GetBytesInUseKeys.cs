using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Storage;

// Multitype Class
/// <summary>A single key or list of keys to get the total usage for. An empty list will return 0. Pass in <c>null</c> to get the total usage of all of storage.</summary>
[JsonConverter(typeof(MultiTypeJsonConverter<GetBytesInUseKeys>))]
public partial class GetBytesInUseKeys : BaseMultiTypeObject
{
    private readonly string valueString;

    /// <summary>Creates a new instance of <see cref="GetBytesInUseKeys" />.</summary>
    /// <param name="value">The value.</param>
    public GetBytesInUseKeys(string value) : base(value, typeof(string))
    {
        valueString = value;
    }

    /// <summary>Creates a new instance of <see cref="GetBytesInUseKeys" />.</summary>
    /// <param name="value">The value.</param>
    public GetBytesInUseKeys(IEnumerable<string> value) : base(value, typeof(IEnumerable<string>))
    {
    }

    /// <summary>Converts from <see cref="GetBytesInUseKeys" /> to <see cref="string" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator string(GetBytesInUseKeys value) => value.valueString;

    /// <summary>Converts from <see cref="string" /> to <see cref="GetBytesInUseKeys" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator GetBytesInUseKeys(string value) => new(value);
}
