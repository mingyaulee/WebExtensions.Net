﻿using System.Diagnostics;
using System.Text.Json.Serialization;
using WebExtensions.Net.Generator.JsonConverters;

namespace WebExtensions.Net.Generator.Models.Schema
{
    [DebuggerDisplay("{Name}")]
    public class ParameterDefinition : TypeReference
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("optional"), JsonConverter(typeof(BooleanStringConverter))]
        public string? Optional { get; set; }

        [JsonIgnore]
        public bool IsOptional => !string.IsNullOrEmpty(Optional);

        [JsonPropertyName("default")]
        public object? Default { get; set; }
    }
}
