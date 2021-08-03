using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExtensions.Net.Search;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Search
{
    //Type Class
    ///<summary></summary>
    public class QueryInfo : BaseObject
    {
        private Disposition _disposition;
        private string _text;
        private int? _tabId;


        /// <summary>Optional, Location where search results should be displayed. CURRENT_TAB is the default.</summary>
        [JsonPropertyName("disposition")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Disposition Disposition
        {
            get
            {
                InitializeProperty("disposition", _disposition);
                return _disposition;
            }
            set
            {
                _disposition = value;
            }
        }


        /// <summary>Optional, Location where search results should be displayed. Cannot be used with disposition.</summary>
        [JsonPropertyName("tabId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabId
        {
            get
            {
                InitializeProperty("tabId", _tabId);
                return _tabId;
            }
            set
            {
                _tabId = value;
            }
        }

        /// <summary>String to query with the default search provider.</summary>
        [JsonPropertyName("text")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Text
        {
            get
            {
                InitializeProperty("text", _text);
                return _text;
            }
            set
            {
                _text = value;
            }
        }
    }
}
