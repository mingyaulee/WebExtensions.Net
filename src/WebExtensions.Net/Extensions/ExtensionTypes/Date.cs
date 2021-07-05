using System;

namespace WebExtensions.Net.ExtensionTypes
{
    public partial class Date
    {
        /// <summary>Converts from <see cref="DateTime" /> to <see cref="Date" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator Date(DateTime value) => new((EpochTime)value);
    }
}
