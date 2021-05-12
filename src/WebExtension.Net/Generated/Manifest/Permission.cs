namespace WebExtension.Net.Manifest
{
    // Multitype Class
    /// <summary></summary>
    public class Permission
    {
        private readonly PermissionNoPrompt valuePermissionNoPrompt;
        private readonly OptionalPermission valueOptionalPermission;
        private readonly object currentValue = null;

        /// <summary>Creates a new instance of <see cref="Permission" />.</summary>
        /// <param name="value">The value.</param>
        public Permission(PermissionNoPrompt value)
        {
            valuePermissionNoPrompt = value;
            currentValue = value;
        }

        /// <summary>Creates a new instance of <see cref="Permission" />.</summary>
        /// <param name="value">The value.</param>
        public Permission(OptionalPermission value)
        {
            valueOptionalPermission = value;
            currentValue = value;
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

        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}
