/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.WebRequest
{
    /// Class Definition
    /// <summary>Contains the certificate properties of the request if it is a secure request.</summary>
    public class CertificateInfo
    {
        
        /// Property Definition
        /// <summary></summary>
        [JsonPropertyName("subject")]
        public string Subject { get; set; }
        
        /// Property Definition
        /// <summary></summary>
        [JsonPropertyName("issuer")]
        public string Issuer { get; set; }
        
        /// Property Definition
        /// <summary>Contains start and end timestamps.</summary>
        [JsonPropertyName("validity")]
        public object Validity { get; set; }
        
        /// Property Definition
        /// <summary></summary>
        [JsonPropertyName("fingerprint")]
        public object Fingerprint { get; set; }
        
        /// Property Definition
        /// <summary></summary>
        [JsonPropertyName("serialNumber")]
        public string SerialNumber { get; set; }
        
        /// Property Definition
        /// <summary></summary>
        [JsonPropertyName("isBuiltInRoot")]
        public bool IsBuiltInRoot { get; set; }
        
        /// Property Definition
        /// <summary></summary>
        [JsonPropertyName("subjectPublicKeyInfoDigest")]
        public object SubjectPublicKeyInfoDigest { get; set; }
        
        /// Property Definition
        /// <summary></summary>
        [JsonPropertyName("rawDER")]
        public IEnumerable<int> RawDER { get; set; }
    }
}

