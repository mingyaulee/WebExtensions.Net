using System.Text.Json.Serialization;

namespace WebExtensions.Net.Menus;

// Multitype Class
/// <summary>The ID of a parent menu item; this makes the item a child of a previously added item.</summary>
[JsonConverter(typeof(MultiTypeJsonConverter<CreatePropertiesParentId>))]
public partial class CreatePropertiesParentId : BaseMultiTypeObject
{
    private readonly int valueInt;
    private readonly string valueString;

    /// <summary>Creates a new instance of <see cref="CreatePropertiesParentId" />.</summary>
    /// <param name="value">The value.</param>
    public CreatePropertiesParentId(int value) : base(value, typeof(int))
    {
        valueInt = value;
    }

    /// <summary>Creates a new instance of <see cref="CreatePropertiesParentId" />.</summary>
    /// <param name="value">The value.</param>
    public CreatePropertiesParentId(string value) : base(value, typeof(string))
    {
        valueString = value;
    }

    /// <summary>Converts from <see cref="CreatePropertiesParentId" /> to <see cref="int" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator int(CreatePropertiesParentId value) => value.valueInt;

    /// <summary>Converts from <see cref="int" /> to <see cref="CreatePropertiesParentId" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator CreatePropertiesParentId(int value) => new(value);

    /// <summary>Converts from <see cref="CreatePropertiesParentId" /> to <see cref="string" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator string(CreatePropertiesParentId value) => value.valueString;

    /// <summary>Converts from <see cref="string" /> to <see cref="CreatePropertiesParentId" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator CreatePropertiesParentId(string value) => new(value);
}
