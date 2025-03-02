using JsBind.Net;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Find
{
    // Type Class
    /// <summary>Search parameters.</summary>
    [BindAllProperties]
    public partial class FindParams : BaseObject
    {
        /// <summary>Find only ranges with case sensitive match.</summary>
        [JsAccessPath("caseSensitive")]
        [JsonPropertyName("caseSensitive")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? CaseSensitive { get; set; }

        /// <summary>Find only ranges that match entire word.</summary>
        [JsAccessPath("entireWord")]
        [JsonPropertyName("entireWord")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? EntireWord { get; set; }

        /// <summary>Return range data which provides range data in a serializable form.</summary>
        [JsAccessPath("includeRangeData")]
        [JsonPropertyName("includeRangeData")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IncludeRangeData { get; set; }

        /// <summary>Return rectangle data which describes visual position of search results.</summary>
        [JsAccessPath("includeRectData")]
        [JsonPropertyName("includeRectData")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IncludeRectData { get; set; }

        /// <summary>Find only ranges with diacritic sensitive match.</summary>
        [JsAccessPath("matchDiacritics")]
        [JsonPropertyName("matchDiacritics")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? MatchDiacritics { get; set; }

        /// <summary>Tab to query. Defaults to the active tab.</summary>
        [JsAccessPath("tabId")]
        [JsonPropertyName("tabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId { get; set; }
    }
}
