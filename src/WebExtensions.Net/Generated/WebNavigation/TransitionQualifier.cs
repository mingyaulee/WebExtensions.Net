using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebNavigation
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<TransitionQualifier>))]
    public enum TransitionQualifier
    {
        /// <summary>client_redirect</summary>
        [EnumValue("client_redirect")]
        ClientRedirect,

        /// <summary>server_redirect</summary>
        [EnumValue("server_redirect")]
        ServerRedirect,

        /// <summary>forward_back</summary>
        [EnumValue("forward_back")]
        ForwardBack,

        /// <summary>from_address_bar</summary>
        [EnumValue("from_address_bar")]
        FromAddressBar,
    }
}
