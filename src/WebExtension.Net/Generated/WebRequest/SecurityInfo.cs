using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.WebRequest
{
    // Class Definition
    /// <summary>
    /// Contains the security properties of the request (ie. SSL/TLS information).
    /// </summary>
    public class SecurityInfo : BaseObject
    {
        
        // Property Definition
        private string _state;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("state")]
        public string State
        {
            get
            {
                InitializeProperty("state", _state);
                return _state;
            }
            set
            {
                _state = value;
            }
        }
        
        // Property Definition
        private string _errorMessage;
        /// <summary>
        /// Error message if state is "broken"
        /// </summary>
        [JsonPropertyName("errorMessage")]
        public string ErrorMessage
        {
            get
            {
                InitializeProperty("errorMessage", _errorMessage);
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
            }
        }
        
        // Property Definition
        private string _protocolVersion;
        /// <summary>
        /// Protocol version if state is "secure"
        /// </summary>
        [JsonPropertyName("protocolVersion")]
        public string ProtocolVersion
        {
            get
            {
                InitializeProperty("protocolVersion", _protocolVersion);
                return _protocolVersion;
            }
            set
            {
                _protocolVersion = value;
            }
        }
        
        // Property Definition
        private string _cipherSuite;
        /// <summary>
        /// The cipher suite used in this request if state is "secure".
        /// </summary>
        [JsonPropertyName("cipherSuite")]
        public string CipherSuite
        {
            get
            {
                InitializeProperty("cipherSuite", _cipherSuite);
                return _cipherSuite;
            }
            set
            {
                _cipherSuite = value;
            }
        }
        
        // Property Definition
        private string _keaGroupName;
        /// <summary>
        /// The key exchange algorithm used in this request if state is "secure".
        /// </summary>
        [JsonPropertyName("keaGroupName")]
        public string KeaGroupName
        {
            get
            {
                InitializeProperty("keaGroupName", _keaGroupName);
                return _keaGroupName;
            }
            set
            {
                _keaGroupName = value;
            }
        }
        
        // Property Definition
        private string _signatureSchemeName;
        /// <summary>
        /// The signature scheme used in this request if state is "secure".
        /// </summary>
        [JsonPropertyName("signatureSchemeName")]
        public string SignatureSchemeName
        {
            get
            {
                InitializeProperty("signatureSchemeName", _signatureSchemeName);
                return _signatureSchemeName;
            }
            set
            {
                _signatureSchemeName = value;
            }
        }
        
        // Property Definition
        private IEnumerable<CertificateInfo> _certificates;
        /// <summary>
        /// Certificate data if state is "secure".  Will only contain one entry unless <c>certificateChain</c> is passed as an option.
        /// </summary>
        [JsonPropertyName("certificates")]
        public IEnumerable<CertificateInfo> Certificates
        {
            get
            {
                InitializeProperty("certificates", _certificates);
                return _certificates;
            }
            set
            {
                _certificates = value;
            }
        }
        
        // Property Definition
        private bool? _isDomainMismatch;
        /// <summary>
        /// The domain name does not match the certificate domain.
        /// </summary>
        [JsonPropertyName("isDomainMismatch")]
        public bool? IsDomainMismatch
        {
            get
            {
                InitializeProperty("isDomainMismatch", _isDomainMismatch);
                return _isDomainMismatch;
            }
            set
            {
                _isDomainMismatch = value;
            }
        }
        
        // Property Definition
        private bool? _isExtendedValidation;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("isExtendedValidation")]
        public bool? IsExtendedValidation
        {
            get
            {
                InitializeProperty("isExtendedValidation", _isExtendedValidation);
                return _isExtendedValidation;
            }
            set
            {
                _isExtendedValidation = value;
            }
        }
        
        // Property Definition
        private bool? _isNotValidAtThisTime;
        /// <summary>
        /// The certificate is either expired or is not yet valid.  See <c>CertificateInfo.validity</c> for start and end dates.
        /// </summary>
        [JsonPropertyName("isNotValidAtThisTime")]
        public bool? IsNotValidAtThisTime
        {
            get
            {
                InitializeProperty("isNotValidAtThisTime", _isNotValidAtThisTime);
                return _isNotValidAtThisTime;
            }
            set
            {
                _isNotValidAtThisTime = value;
            }
        }
        
        // Property Definition
        private bool? _isUntrusted;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("isUntrusted")]
        public bool? IsUntrusted
        {
            get
            {
                InitializeProperty("isUntrusted", _isUntrusted);
                return _isUntrusted;
            }
            set
            {
                _isUntrusted = value;
            }
        }
        
        // Property Definition
        private CertificateTransparencyStatus _certificateTransparencyStatus;
        /// <summary>
        /// Certificate transparency compliance per RFC 6962.  See <c>https://www.certificate-transparency.org/what-is-ct</c> for more information.
        /// </summary>
        [JsonPropertyName("certificateTransparencyStatus")]
        public CertificateTransparencyStatus CertificateTransparencyStatus
        {
            get
            {
                InitializeProperty("certificateTransparencyStatus", _certificateTransparencyStatus);
                return _certificateTransparencyStatus;
            }
            set
            {
                _certificateTransparencyStatus = value;
            }
        }
        
        // Property Definition
        private bool? _hsts;
        /// <summary>
        /// True if host uses Strict Transport Security and state is "secure".
        /// </summary>
        [JsonPropertyName("hsts")]
        public bool? Hsts
        {
            get
            {
                InitializeProperty("hsts", _hsts);
                return _hsts;
            }
            set
            {
                _hsts = value;
            }
        }
        
        // Property Definition
        private string _hpkp;
        /// <summary>
        /// True if host uses Public Key Pinning and state is "secure".
        /// </summary>
        [JsonPropertyName("hpkp")]
        public string Hpkp
        {
            get
            {
                InitializeProperty("hpkp", _hpkp);
                return _hpkp;
            }
            set
            {
                _hpkp = value;
            }
        }
        
        // Property Definition
        private IEnumerable<TransportWeaknessReasons> _weaknessReasons;
        /// <summary>
        /// list of reasons that cause the request to be considered weak, if state is "weak"
        /// </summary>
        [JsonPropertyName("weaknessReasons")]
        public IEnumerable<TransportWeaknessReasons> WeaknessReasons
        {
            get
            {
                InitializeProperty("weaknessReasons", _weaknessReasons);
                return _weaknessReasons;
            }
            set
            {
                _weaknessReasons = value;
            }
        }
    }
}

