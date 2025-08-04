using System.Text.Json.Serialization;

namespace WebExtensions.Net.Manifest
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<CommonDataCollectionPermission>))]
    public enum CommonDataCollectionPermission
    {
        /// <summary>authenticationInfo</summary>
        [EnumValue("authenticationInfo")]
        AuthenticationInfo,

        /// <summary>bookmarksInfo</summary>
        [EnumValue("bookmarksInfo")]
        BookmarksInfo,

        /// <summary>browsingActivity</summary>
        [EnumValue("browsingActivity")]
        BrowsingActivity,

        /// <summary>financialAndPaymentInfo</summary>
        [EnumValue("financialAndPaymentInfo")]
        FinancialAndPaymentInfo,

        /// <summary>healthInfo</summary>
        [EnumValue("healthInfo")]
        HealthInfo,

        /// <summary>locationInfo</summary>
        [EnumValue("locationInfo")]
        LocationInfo,

        /// <summary>personalCommunications</summary>
        [EnumValue("personalCommunications")]
        PersonalCommunications,

        /// <summary>personallyIdentifyingInfo</summary>
        [EnumValue("personallyIdentifyingInfo")]
        PersonallyIdentifyingInfo,

        /// <summary>searchTerms</summary>
        [EnumValue("searchTerms")]
        SearchTerms,

        /// <summary>websiteActivity</summary>
        [EnumValue("websiteActivity")]
        WebsiteActivity,

        /// <summary>websiteContent</summary>
        [EnumValue("websiteContent")]
        WebsiteContent,
    }
}
