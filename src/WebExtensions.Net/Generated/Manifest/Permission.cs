using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest
{
    // Multitype Class
    /// <summary></summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<Permission>))]
    public partial class Permission : BaseMultiTypeObject
    {
        private readonly PermissionNoPrompt valuePermissionNoPrompt;
        private readonly OptionalPermission valueOptionalPermission;

        /// <summary>Creates a new instance of <see cref="Permission" />.</summary>
        /// <param name="value">The value.</param>
        public Permission(PermissionNoPrompt value) : base(value, typeof(PermissionNoPrompt))
        {
            valuePermissionNoPrompt = value;
        }

        /// <summary>Creates a new instance of <see cref="Permission" />.</summary>
        /// <param name="value">The value.</param>
        public Permission(OptionalPermission value) : base(value, typeof(OptionalPermission))
        {
            valueOptionalPermission = value;
        }

        /// <summary>Converts from <see cref="Permission" /> to <see cref="PermissionNoPrompt" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator PermissionNoPrompt(Permission value) => value.valuePermissionNoPrompt;

        /// <summary>Converts from <see cref="PermissionNoPrompt" /> to <see cref="Permission" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator Permission(PermissionNoPrompt value) => new(value);

        /// <summary>Converts from <see cref="Permission" /> to <see cref="OptionalPermission" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator OptionalPermission(Permission value) => value.valueOptionalPermission;

        /// <summary>Converts from <see cref="OptionalPermission" /> to <see cref="Permission" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator Permission(OptionalPermission value) => new(value);
    }
}
