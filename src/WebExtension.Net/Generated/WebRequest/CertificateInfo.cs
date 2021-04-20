using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtension.Net.WebRequest
{
    // Type Class
    /// <summary>Contains the certificate properties of the request if it is a secure request.</summary>
    public class CertificateInfo : BaseObject
    {
        private object _fingerprint;
        private bool _isBuiltInRoot;
        private string _issuer;
        private IEnumerable<int?> _rawDER;
        private string _serialNumber;
        private string _subject;
        private object _subjectPublicKeyInfoDigest;
        private object _validity;

        /// <summary></summary>
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

        /// <summary></summary>
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

        /// <summary></summary>
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

        /// <summary></summary>
        [JsonPropertyName("rawDER")]
        public IEnumerable<int?> RawDER
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

        /// <summary></summary>
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

        /// <summary></summary>
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

        /// <summary></summary>
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

        /// <summary>Contains start and end timestamps.</summary>
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
    }
}
