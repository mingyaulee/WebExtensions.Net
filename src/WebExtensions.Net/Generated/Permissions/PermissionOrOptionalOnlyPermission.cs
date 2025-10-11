using System.Text.Json.Serialization;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.Permissions;

// Multitype Class
/// <summary></summary>
[JsonConverter(typeof(MultiTypeJsonConverter<PermissionOrOptionalOnlyPermission>))]
public partial class PermissionOrOptionalOnlyPermission : BaseMultiTypeObject
{
    private readonly Permission valuePermission;
    private readonly OptionalOnlyPermission valueOptionalOnlyPermission;

    /// <summary>Creates a new instance of <see cref="PermissionOrOptionalOnlyPermission" />.</summary>
    /// <param name="value">The value.</param>
    public PermissionOrOptionalOnlyPermission(Permission value) : base(value, typeof(Permission))
    {
        valuePermission = value;
    }

    /// <summary>Creates a new instance of <see cref="PermissionOrOptionalOnlyPermission" />.</summary>
    /// <param name="value">The value.</param>
    public PermissionOrOptionalOnlyPermission(OptionalOnlyPermission value) : base(value, typeof(OptionalOnlyPermission))
    {
        valueOptionalOnlyPermission = value;
    }

    /// <summary>Converts from <see cref="PermissionOrOptionalOnlyPermission" /> to <see cref="Permission" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator Permission(PermissionOrOptionalOnlyPermission value) => value.valuePermission;

    /// <summary>Converts from <see cref="Permission" /> to <see cref="PermissionOrOptionalOnlyPermission" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator PermissionOrOptionalOnlyPermission(Permission value) => new(value);

    /// <summary>Converts from <see cref="PermissionOrOptionalOnlyPermission" /> to <see cref="OptionalOnlyPermission" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator OptionalOnlyPermission(PermissionOrOptionalOnlyPermission value) => value.valueOptionalOnlyPermission;

    /// <summary>Converts from <see cref="OptionalOnlyPermission" /> to <see cref="PermissionOrOptionalOnlyPermission" />.</summary>
    /// <param name="value">The value to convert from.</param>
    public static implicit operator PermissionOrOptionalOnlyPermission(OptionalOnlyPermission value) => new(value);
}
