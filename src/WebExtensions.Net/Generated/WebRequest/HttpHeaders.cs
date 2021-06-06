using System.Collections.Generic;

namespace WebExtensions.Net.WebRequest
{
    // Array Class
    /// <summary>An array of HTTP headers. Each header is represented as a dictionary containing the keys <c>name</c> and either <c>value</c> or <c>binaryValue</c>.</summary>
    public class HttpHeaders : List<HttpHeadersArrayItem>
    {
    }
}
