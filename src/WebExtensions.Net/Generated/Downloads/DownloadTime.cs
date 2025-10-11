using System.Text.Json.Serialization;
using WebExtensions.Net.ExtensionTypes;

namespace WebExtensions.Net.Downloads;

// Multitype Class
/// <summary>A time specified as a Date object, a number or string representing milliseconds since the epoch, or an ISO 8601 string</summary>
[JsonConverter(typeof(MultiTypeJsonConverter<DownloadTime>))]
public partial class DownloadTime : BaseMultiTypeObject
{
    private readonly string valueString;
    private readonly Date valueDate;

    /// <summary>Creates a new instance of <see cref="DownloadTime" />.</summary>
    /// <param name="value">The value.</param>
    public DownloadTime(string value) : base(value, typeof(string))
    {
        valueString = value;
    }

    /// <summary>Creates a new instance of <see cref="DownloadTime" />.</summary>
    /// <param name="value">The value.</param>
    public DownloadTime(Date value) : base(value, typeof(Date))
    {
        valueDate = value;
    }

    /// <summary>Converts from <see cref="DownloadTime" /> to <see cref="string" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator string(DownloadTime value) => value.valueString;

    /// <summary>Converts from <see cref="string" /> to <see cref="DownloadTime" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator DownloadTime(string value) => new(value);

    /// <summary>Converts from <see cref="DownloadTime" /> to <see cref="Date" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator Date(DownloadTime value) => value.valueDate;

    /// <summary>Converts from <see cref="Date" /> to <see cref="DownloadTime" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator DownloadTime(Date value) => new(value);
}
