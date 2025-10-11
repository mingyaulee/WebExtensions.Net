using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Events;

// Multitype Class
/// <summary></summary>
[JsonConverter(typeof(MultiTypeJsonConverter<Port>))]
public partial class Port : BaseMultiTypeObject
{
    private readonly int valueInt;

    /// <summary>Creates a new instance of <see cref="Port" />.</summary>
    /// <param name="value">The value.</param>
    public Port(int value) : base(value, typeof(int))
    {
        valueInt = value;
    }

    /// <summary>Creates a new instance of <see cref="Port" />.</summary>
    /// <param name="value">The value.</param>
    public Port(IEnumerable<int> value) : base(value, typeof(IEnumerable<int>))
    {
    }

    /// <summary>Converts from <see cref="Port" /> to <see cref="int" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator int(Port value) => value.valueInt;

    /// <summary>Converts from <see cref="int" /> to <see cref="Port" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator Port(int value) => new(value);
}
