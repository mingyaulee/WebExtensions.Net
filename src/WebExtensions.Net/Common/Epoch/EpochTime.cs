using System;
using System.Text.Json.Serialization;

namespace WebExtensions.Net
{
    /// <summary>
    /// Represents the Epoch time/Unix timestamp, can be created from an instance of <see cref="DateTime" /> or <see cref="double"/>.
    /// </summary>
    [JsonConverter(typeof(EpochTimeConverter))]
    public struct EpochTime
    {
        private static readonly DateTime epoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private readonly DateTime dateTimeValue;

        private EpochTime(DateTime dateTime)
        {
            dateTimeValue = dateTime;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return dateTimeValue.ToString();
        }

        /// <summary>Converts from <see cref="EpochTime" /> to <see cref="DateTime" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator DateTime(EpochTime value) => value.dateTimeValue;

        /// <summary>Converts from <see cref="DateTime" /> to <see cref="EpochTime" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator EpochTime(DateTime value) => new(value);

        /// <summary>Converts from <see cref="EpochTime" /> to <see cref="double" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator double(EpochTime value) => (value.dateTimeValue.ToUniversalTime() - epoch).TotalMilliseconds;

        /// <summary>Converts from <see cref="double" /> to <see cref="EpochTime" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator EpochTime(double value) => new(epoch.AddMilliseconds(value));
    }
}
