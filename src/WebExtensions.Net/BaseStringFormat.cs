using System;
using System.Text.RegularExpressions;

namespace WebExtensions.Net
{
    /// <summary>
    /// Base class for types that has a format pattern
    /// </summary>
    public class BaseStringFormat
    {
        /// <summary>
        /// Creates a new instance of the BaseStringFormat class
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <param name="format">The string format.</param>
        /// <param name="pattern">The string pattern.</param>
        public BaseStringFormat(string value, string format, string pattern)
        {
            Value = value;

            if (!string.IsNullOrEmpty(pattern) && !Regex.IsMatch(value, pattern))
            {
                throw new ArgumentException($"The value '{value}' does not match the pattern '{pattern}' specified for type {GetType().Name}.");
            }

            if (!string.IsNullOrEmpty(format) && !IsValid(value, format))
            {
                throw new ArgumentException($"The value '{value}' does not match the format '{format}' specified for type {GetType().Name}.");
            }
        }

        /// <summary>
        /// The value.
        /// </summary>
        public string Value { get; }

        /// <inheritdoc />
        public override string ToString()
        {
            return Value;
        }

        private static bool IsValid(string value, string format)
        {
            if (format.Contains("url", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    _ = new Uri(value);
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            if (format == "date")
            {
                return DateTime.TryParse(value, out _);
            }

            return true;
        }
    }
}
