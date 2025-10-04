﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace WebExtensions.Net.Generator.Models.Schema
{
    [DebuggerDisplay("{Name}")]
    public class EventDefinition : TypeReference
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("extraParameters")]
        public IEnumerable<ParameterDefinition>? ExtraParameters { get; set; }
    }
}
