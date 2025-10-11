using System.Text.Json.Serialization;

namespace WebExtensions.Net.SidebarAction;

// Multitype Class
/// <summary>Either a relative image path or a dictionary {size -> relative image path} pointing to icon to be set. If the icon is specified as a dictionary, the actual image to be used is chosen depending on screen's pixel density. If the number of image pixels that fit into one screen space unit equals <c>scale</c>, then image with size <c>scale</c> * 19 will be selected. Initially only scales 1 and 2 will be supported. At least one image must be specified. Note that 'details.path = foo' is equivalent to 'details.imageData = {'19': foo}'</summary>
[JsonConverter(typeof(MultiTypeJsonConverter<Path>))]
public partial class Path : BaseMultiTypeObject
{
    private readonly string valueString;

    /// <summary>Creates a new instance of <see cref="Path" />.</summary>
    /// <param name="value">The value.</param>
    public Path(string value) : base(value, typeof(string))
    {
        valueString = value;
    }

    /// <summary>Creates a new instance of <see cref="Path" />.</summary>
    /// <param name="value">The value.</param>
    public Path(object value) : base(value, typeof(object))
    {
    }

    /// <summary>Converts from <see cref="Path" /> to <see cref="string" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator string(Path value) => value.valueString;

    /// <summary>Converts from <see cref="string" /> to <see cref="Path" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator Path(string value) => new(value);
}
