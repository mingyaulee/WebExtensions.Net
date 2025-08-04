using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Tabs
{
    // Multitype Class
    /// <summary>The tab ID or list of tab IDs to add to the specified group.</summary>
    [JsonConverter(typeof(MultiTypeJsonConverter<OptionsTabIds>))]
    public partial class OptionsTabIds : BaseMultiTypeObject
    {
        private readonly int valueInt;

        /// <summary>Creates a new instance of <see cref="OptionsTabIds" />.</summary>
        /// <param name="value">The value.</param>
        public OptionsTabIds(int value) : base(value, typeof(int))
        {
            valueInt = value;
        }

        /// <summary>Creates a new instance of <see cref="OptionsTabIds" />.</summary>
        /// <param name="value">The value.</param>
        public OptionsTabIds(IEnumerable<int> value) : base(value, typeof(IEnumerable<int>))
        {
        }

        /// <summary>Converts from <see cref="OptionsTabIds" /> to <see cref="int" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator int(OptionsTabIds value) => value.valueInt;

        /// <summary>Converts from <see cref="int" /> to <see cref="OptionsTabIds" />.</summary>
        /// <param name="value">The value to convert from.</param>
        public static implicit operator OptionsTabIds(int value) => new(value);
    }
}
