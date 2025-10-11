using System.Text.Json.Serialization;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.Permissions;

// Multitype Class
/// <summary></summary>
[JsonConverter(typeof(MultiTypeJsonConverter<OptionalPermissionOrOptionalOnlyPermission>))]
public partial class OptionalPermissionOrOptionalOnlyPermission : BaseMultiTypeObject
{
    private readonly OptionalPermission valueOptionalPermission;
    private readonly OptionalOnlyPermission valueOptionalOnlyPermission;

    /// <summary>Creates a new instance of <see cref="OptionalPermissionOrOptionalOnlyPermission" />.</summary>
    /// <param name="value">The value.</param>
    public OptionalPermissionOrOptionalOnlyPermission(OptionalPermission value) : base(value, typeof(OptionalPermission))
    {
        valueOptionalPermission = value;
    }

    /// <summary>Creates a new instance of <see cref="OptionalPermissionOrOptionalOnlyPermission" />.</summary>
    /// <param name="value">The value.</param>
    public OptionalPermissionOrOptionalOnlyPermission(OptionalOnlyPermission value) : base(value, typeof(OptionalOnlyPermission))
    {
        valueOptionalOnlyPermission = value;
    }

    /// <summary>Converts from <see cref="OptionalPermissionOrOptionalOnlyPermission" /> to <see cref="OptionalPermission" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator OptionalPermission(OptionalPermissionOrOptionalOnlyPermission value) => value.valueOptionalPermission;

    /// <summary>Converts from <see cref="OptionalPermission" /> to <see cref="OptionalPermissionOrOptionalOnlyPermission" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator OptionalPermissionOrOptionalOnlyPermission(OptionalPermission value) => new(value);

    /// <summary>Converts from <see cref="OptionalPermissionOrOptionalOnlyPermission" /> to <see cref="OptionalOnlyPermission" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator OptionalOnlyPermission(OptionalPermissionOrOptionalOnlyPermission value) => value.valueOptionalOnlyPermission;

    /// <summary>Converts from <see cref="OptionalOnlyPermission" /> to <see cref="OptionalPermissionOrOptionalOnlyPermission" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator OptionalPermissionOrOptionalOnlyPermission(OptionalOnlyPermission value) => new(value);
}
