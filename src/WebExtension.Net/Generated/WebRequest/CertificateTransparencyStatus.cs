// This file is auto generated at 2021-03-24T04:51:22

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.WebRequest
{
    // Enum Definition
    /// <summary>
    /// 
    /// </summary>
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

