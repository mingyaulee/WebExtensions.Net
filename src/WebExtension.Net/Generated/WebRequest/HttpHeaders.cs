using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.WebRequest
{
    // List Definition
    /// <summary>
    /// An array of HTTP headers. Each header is represented as a dictionary containing the keys <c>name</c> and either <c>value</c> or <c>binaryValue</c>.
    /// </summary>
    public class HttpHeaders : List<object>
    {
    }
}

