/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.WebRequest
{
    /// Class Definition
    /// <summary>Contains the security properties of the request (ie. SSL/TLS information).</summary>
    public class SecurityInfo
    {
        
        /// Property Definition
        /// <summary></summary>
        [JsonPropertyName("state")]
        public string State { get; set; }
        
        /// Property Definition
        /// <summary>Error message if state is "broken"</summary>
        [JsonPropertyName("errorMessage")]
        public string ErrorMessage { get; set; }
        
        /// Property Definition
        /// <summary>Protocol version if state is "secure"</summary>
        [JsonPropertyName("protocolVersion")]
        public string ProtocolVersion { get; set; }
        
        /// Property Definition
        /// <summary>The cipher suite used in this request if state is "secure".</summary>
        [JsonPropertyName("cipherSuite")]
        public string CipherSuite { get; set; }
        
        /// Property Definition
        /// <summary>The key exchange algorithm used in this request if state is "secure".</summary>
        [JsonPropertyName("keaGroupName")]
        public string KeaGroupName { get; set; }
        
        /// Property Definition
        /// <summary>The signature scheme used in this request if state is "secure".</summary>
        [JsonPropertyName("signatureSchemeName")]
        public string SignatureSchemeName { get; set; }
        
        /// Property Definition
        /// <summary>Certificate data if state is "secure".  Will only contain one entry unless <code>certificateChain</code> is passed as an option.</summary>
        [JsonPropertyName("certificates")]
        public IEnumerable<CertificateInfo> Certificates { get; set; }
        
        /// Property Definition
        /// <summary>The domain name does not match the certificate domain.</summary>
        [JsonPropertyName("isDomainMismatch")]
        public bool? IsDomainMismatch { get; set; }
        
        /// Property Definition
        /// <summary></summary>
        [JsonPropertyName("isExtendedValidation")]
        public bool? IsExtendedValidation { get; set; }
        
        /// Property Definition
        /// <summary>The certificate is either expired or is not yet valid.  See <code>CertificateInfo.validity</code> for start and end dates.</summary>
        [JsonPropertyName("isNotValidAtThisTime")]
        public bool? IsNotValidAtThisTime { get; set; }
        
        /// Property Definition
        /// <summary></summary>
        [JsonPropertyName("isUntrusted")]
        public bool? IsUntrusted { get; set; }
        
        /// Property Definition
        /// <summary>Certificate transparency compliance per RFC 6962.  See <code>https://www.certificate-transparency.org/what-is-ct</code> for more information.</summary>
        [JsonPropertyName("certificateTransparencyStatus")]
        public CertificateTransparencyStatus CertificateTransparencyStatus { get; set; }
        
        /// Property Definition
        /// <summary>True if host uses Strict Transport Security and state is "secure".</summary>
        [JsonPropertyName("hsts")]
        public bool? Hsts { get; set; }
        
        /// Property Definition
        /// <summary>True if host uses Public Key Pinning and state is "secure".</summary>
        [JsonPropertyName("hpkp")]
        public string Hpkp { get; set; }
        
        /// Property Definition
        /// <summary>list of reasons that cause the request to be considered weak, if state is "weak"</summary>
        [JsonPropertyName("weaknessReasons")]
        public IEnumerable<TransportWeaknessReasons> WeaknessReasons { get; set; }
    }
}

