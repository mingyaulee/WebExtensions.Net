using System.Text.Json.Serialization;

namespace WebExtensions.Net.Downloads;

/// <summary></summary>
[JsonConverter(typeof(EnumStringConverter<InterruptReason>))]
public enum InterruptReason
{
    /// <summary>FILE_FAILED</summary>
    [EnumValue("FILE_FAILED")]
    FILEFAILED,

    /// <summary>FILE_ACCESS_DENIED</summary>
    [EnumValue("FILE_ACCESS_DENIED")]
    FILEACCESSDENIED,

    /// <summary>FILE_NO_SPACE</summary>
    [EnumValue("FILE_NO_SPACE")]
    FILENOSPACE,

    /// <summary>FILE_NAME_TOO_LONG</summary>
    [EnumValue("FILE_NAME_TOO_LONG")]
    FILENAMETOOLONG,

    /// <summary>FILE_TOO_LARGE</summary>
    [EnumValue("FILE_TOO_LARGE")]
    FILETOOLARGE,

    /// <summary>FILE_VIRUS_INFECTED</summary>
    [EnumValue("FILE_VIRUS_INFECTED")]
    FILEVIRUSINFECTED,

    /// <summary>FILE_TRANSIENT_ERROR</summary>
    [EnumValue("FILE_TRANSIENT_ERROR")]
    FILETRANSIENTERROR,

    /// <summary>FILE_BLOCKED</summary>
    [EnumValue("FILE_BLOCKED")]
    FILEBLOCKED,

    /// <summary>FILE_SECURITY_CHECK_FAILED</summary>
    [EnumValue("FILE_SECURITY_CHECK_FAILED")]
    FILESECURITYCHECKFAILED,

    /// <summary>FILE_TOO_SHORT</summary>
    [EnumValue("FILE_TOO_SHORT")]
    FILETOOSHORT,

    /// <summary>NETWORK_FAILED</summary>
    [EnumValue("NETWORK_FAILED")]
    NETWORKFAILED,

    /// <summary>NETWORK_TIMEOUT</summary>
    [EnumValue("NETWORK_TIMEOUT")]
    NETWORKTIMEOUT,

    /// <summary>NETWORK_DISCONNECTED</summary>
    [EnumValue("NETWORK_DISCONNECTED")]
    NETWORKDISCONNECTED,

    /// <summary>NETWORK_SERVER_DOWN</summary>
    [EnumValue("NETWORK_SERVER_DOWN")]
    NETWORKSERVERDOWN,

    /// <summary>NETWORK_INVALID_REQUEST</summary>
    [EnumValue("NETWORK_INVALID_REQUEST")]
    NETWORKINVALIDREQUEST,

    /// <summary>SERVER_FAILED</summary>
    [EnumValue("SERVER_FAILED")]
    SERVERFAILED,

    /// <summary>SERVER_NO_RANGE</summary>
    [EnumValue("SERVER_NO_RANGE")]
    SERVERNORANGE,

    /// <summary>SERVER_BAD_CONTENT</summary>
    [EnumValue("SERVER_BAD_CONTENT")]
    SERVERBADCONTENT,

    /// <summary>SERVER_UNAUTHORIZED</summary>
    [EnumValue("SERVER_UNAUTHORIZED")]
    SERVERUNAUTHORIZED,

    /// <summary>SERVER_CERT_PROBLEM</summary>
    [EnumValue("SERVER_CERT_PROBLEM")]
    SERVERCERTPROBLEM,

    /// <summary>SERVER_FORBIDDEN</summary>
    [EnumValue("SERVER_FORBIDDEN")]
    SERVERFORBIDDEN,

    /// <summary>USER_CANCELED</summary>
    [EnumValue("USER_CANCELED")]
    USERCANCELED,

    /// <summary>USER_SHUTDOWN</summary>
    [EnumValue("USER_SHUTDOWN")]
    USERSHUTDOWN,

    /// <summary>CRASH</summary>
    [EnumValue("CRASH")]
    CRASH,
}
