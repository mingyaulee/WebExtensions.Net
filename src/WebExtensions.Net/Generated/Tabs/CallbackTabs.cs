using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs;

// Multitype Class
/// <summary>Details about the moved tabs.</summary>
[JsonConverter(typeof(MultiTypeJsonConverter<CallbackTabs>))]
public partial class CallbackTabs : BaseMultiTypeObject
{
    private readonly Tab valueTab;

    /// <summary>Creates a new instance of <see cref="CallbackTabs" />.</summary>
    /// <param name="value">The value.</param>
    public CallbackTabs(Tab value) : base(value, typeof(Tab))
    {
        valueTab = value;
    }

    /// <summary>Creates a new instance of <see cref="CallbackTabs" />.</summary>
    /// <param name="value">The value.</param>
    public CallbackTabs(IEnumerable<Tab> value) : base(value, typeof(IEnumerable<Tab>))
    {
    }

    /// <summary>Converts from <see cref="CallbackTabs" /> to <see cref="Tab" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator Tab(CallbackTabs value) => value.valueTab;

    /// <summary>Converts from <see cref="Tab" /> to <see cref="CallbackTabs" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator CallbackTabs(Tab value) => new(value);
}
