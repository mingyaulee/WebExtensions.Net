using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.WebRequest
{
    // List Definition
    /// <summary>
    /// If the request has been classified this is an array of $(ref:UrlClassificationFlags).
    /// </summary>
    public class UrlClassificationParty : List<UrlClassificationFlags>
    {
    }
}

