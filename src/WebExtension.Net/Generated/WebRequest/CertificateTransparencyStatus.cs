/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.WebRequest
{
    /// Enum Definition
    /// <summary></summary>
    [JsonConverter(typeof(EnumStringConverter<CertificateTransparencyStatus>))]
    public enum CertificateTransparencyStatus
    {
        [EnumValue("not_applicable")]
        Not_applicable,
        [EnumValue("policy_compliant")]
        Policy_compliant,
        [EnumValue("policy_not_enough_scts")]
        Policy_not_enough_scts,
        [EnumValue("policy_not_diverse_scts")]
        Policy_not_diverse_scts,
    }
}

