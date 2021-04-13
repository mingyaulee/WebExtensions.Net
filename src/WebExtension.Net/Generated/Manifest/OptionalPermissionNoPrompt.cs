namespace WebExtension.Net.Manifest
{
    // Multitype Class
    /// <summary></summary>
    public class OptionalPermissionNoPrompt
    {
        private readonly string valueString;
        private readonly object currentValue = null;

        /// <summary>Creates a new instance of <see cref="OptionalPermissionNoPrompt" />.</summary>
        /// <param name="value">The value.</param>
        public OptionalPermissionNoPrompt(string value)
        {
            valueString = value;
            currentValue = value;
        }

        /// <summary>Converts from <see cref="OptionalPermissionNoPrompt" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator string(OptionalPermissionNoPrompt value) => value.valueString;

        /// <summary>Converts from <see cref="string" /> to <see cref="OptionalPermissionNoPrompt" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator OptionalPermissionNoPrompt(string value) => new(value);

        /// <inheritdoc />
        public override string ToString()
        {
            return currentValue?.ToString();
        }
    }
}
