namespace WebExtension.Net.Manifest
{
    // Multitype Class
    /// <summary></summary>
    public class PermissionNoPrompt
    {
        private readonly string valueString;
        private readonly object currentValue = null;

        /// <summary>Creates a new instance of <see cref="PermissionNoPrompt" />.</summary>
        public PermissionNoPrompt()
        {
        }

        /// <summary>Creates a new instance of <see cref="PermissionNoPrompt" />.</summary>
        /// <param name="value">The value.</param>
        public PermissionNoPrompt(string value)
        {
            valueString = value;
            currentValue = value;
        }

        /// <summary>Converts from <see cref="PermissionNoPrompt" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(PermissionNoPrompt value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="PermissionNoPrompt" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator PermissionNoPrompt(string value) => new(value);

        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}
