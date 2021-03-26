using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.WebRequest
{
    // Class Definition
    /// <summary>
    /// Contains the certificate properties of the request if it is a secure request.
    /// </summary>
    public class CertificateInfo : BaseObject
    {
        
        // Property Definition
        private string _subject;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("subject")]
        public string Subject
        {
            get
            {
                InitializeProperty("subject", _subject);
                return _subject;
            }
            set
            {
                _subject = value;
            }
        }
        
        // Property Definition
        private string _issuer;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("issuer")]
        public string Issuer
        {
            get
            {
                InitializeProperty("issuer", _issuer);
                return _issuer;
            }
            set
            {
                _issuer = value;
            }
        }
        
        // Property Definition
        private object _validity;
        /// <summary>
        /// Contains start and end timestamps.
        /// </summary>
        [JsonPropertyName("validity")]
        public object Validity
        {
            get
            {
                InitializeProperty("validity", _validity);
                return _validity;
            }
            set
            {
                _validity = value;
            }
        }
        
        // Property Definition
        private object _fingerprint;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("fingerprint")]
        public object Fingerprint
        {
            get
            {
                InitializeProperty("fingerprint", _fingerprint);
                return _fingerprint;
            }
            set
            {
                _fingerprint = value;
            }
        }
        
        // Property Definition
        private string _serialNumber;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("serialNumber")]
        public string SerialNumber
        {
            get
            {
                InitializeProperty("serialNumber", _serialNumber);
                return _serialNumber;
            }
            set
            {
                _serialNumber = value;
            }
        }
        
        // Property Definition
        private bool _isBuiltInRoot;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("isBuiltInRoot")]
        public bool IsBuiltInRoot
        {
            get
            {
                InitializeProperty("isBuiltInRoot", _isBuiltInRoot);
                return _isBuiltInRoot;
            }
            set
            {
                _isBuiltInRoot = value;
            }
        }
        
        // Property Definition
        private object _subjectPublicKeyInfoDigest;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("subjectPublicKeyInfoDigest")]
        public object SubjectPublicKeyInfoDigest
        {
            get
            {
                InitializeProperty("subjectPublicKeyInfoDigest", _subjectPublicKeyInfoDigest);
                return _subjectPublicKeyInfoDigest;
            }
            set
            {
                _subjectPublicKeyInfoDigest = value;
            }
        }
        
        // Property Definition
        private IEnumerable<int> _rawDER;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("rawDER")]
        public IEnumerable<int> RawDER
        {
            get
            {
                InitializeProperty("rawDER", _rawDER);
                return _rawDER;
            }
            set
            {
                _rawDER = value;
            }
        }
    }
}

