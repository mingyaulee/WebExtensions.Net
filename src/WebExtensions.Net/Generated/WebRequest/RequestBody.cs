﻿using JsBind.Net;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.WebRequest;

// Type Class
/// <summary>Contains the HTTP request body data. Only provided if extraInfoSpec contains 'requestBody'.</summary>
[BindAllProperties]
public partial class RequestBody : BaseObject
{
    /// <summary>Errors when obtaining request body data.</summary>
    [JsAccessPath("error")]
    [JsonPropertyName("error")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Error { get; set; }

    /// <summary>If the request method is POST and the body is a sequence of key-value pairs encoded in UTF8, encoded as either multipart/form-data, or application/x-www-form-urlencoded, this dictionary is present and for each key contains the list of all values for that key. If the data is of another media type, or if it is malformed, the dictionary is not present. An example value of this dictionary is {'key': ['value1', 'value2']}.</summary>
    [JsAccessPath("formData")]
    [JsonPropertyName("formData")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object FormData { get; set; }

    /// <summary>If the request method is PUT or POST, and the body is not already parsed in formData, then the unparsed request body elements are contained in this array.</summary>
    [JsAccessPath("raw")]
    [JsonPropertyName("raw")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<UploadData> Raw { get; set; }
}
