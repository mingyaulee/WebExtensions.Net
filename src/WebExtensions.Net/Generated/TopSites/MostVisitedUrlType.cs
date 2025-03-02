using System.Text.Json.Serialization;

namespace WebExtensions.Net.TopSites
{
    /// <summary>The entry type, either <c>url</c> for a normal page link, or <c>search</c> for a search shortcut.</summary>
    [JsonConverter(typeof(EnumStringConverter<MostVisitedUrlType>))]
    public enum MostVisitedUrlType
    {
        /// <summary>url</summary>
        [EnumValue("url")]
        Url,

        /// <summary>search</summary>
        [EnumValue("search")]
        Search,
    }
}
