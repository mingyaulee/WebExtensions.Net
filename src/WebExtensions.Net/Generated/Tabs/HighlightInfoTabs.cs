using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs;

// Multitype Class
/// <summary>One or more tab indices to highlight.</summary>
[JsonConverter(typeof(MultiTypeJsonConverter<HighlightInfoTabs>))]
public partial class HighlightInfoTabs : BaseMultiTypeObject
{
    private readonly int valueInt;

    /// <summary>Creates a new instance of <see cref="HighlightInfoTabs" />.</summary>
    /// <param name="value">The value.</param>
    public HighlightInfoTabs(IEnumerable<int> value) : base(value, typeof(IEnumerable<int>))
    {
    }

    /// <summary>Creates a new instance of <see cref="HighlightInfoTabs" />.</summary>
    /// <param name="value">The value.</param>
    public HighlightInfoTabs(int value) : base(value, typeof(int))
    {
        valueInt = value;
    }

    /// <summary>Converts from <see cref="HighlightInfoTabs" /> to <see cref="int" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator int(HighlightInfoTabs value) => value.valueInt;

    /// <summary>Converts from <see cref="int" /> to <see cref="HighlightInfoTabs" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator HighlightInfoTabs(int value) => new(value);
}
