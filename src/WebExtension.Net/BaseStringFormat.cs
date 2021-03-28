using System;
using System.Text.RegularExpressions;

namespace WebExtension.Net
{
    /// <summary>
    /// Base class for types that has a format pattern
    /// </summary>
    public class BaseStringFormat
    {
        private readonly string value;

        /// <summary>
        /// Creates a new instance of the BaseStringFormat class
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <param name="format">The format pattern.</param>
        public BaseStringFormat(string value, string format)
        {
            this.value = value;
            if (!string.IsNullOrEmpty(format) && !Regex.IsMatch(value, format))
            {
                throw new ArgumentException($"The value '{value}' does not match the format '{format}' specified for type {this.GetType().Name}.");
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return value;
        }
    }
}
