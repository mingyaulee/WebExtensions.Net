using System.Text.Json.Serialization;

namespace WebExtension.Net.WebRequest
{
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<CertificateTransparencyStatus>))]
    public enum CertificateTransparencyStatus
    {
        /// <summary>not_applicable</summary>
        [EnumValue("not_applicable")]
        Not_applicable,

        /// <summary>policy_compliant</summary>
        [EnumValue("policy_compliant")]
        Policy_compliant,

        /// <summary>policy_not_enough_scts</summary>
        [EnumValue("policy_not_enough_scts")]
        Policy_not_enough_scts,

        /// <summary>policy_not_diverse_scts</summary>
        [EnumValue("policy_not_diverse_scts")]
        Policy_not_diverse_scts,
    }
}
