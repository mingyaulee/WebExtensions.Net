/// This file is auto generated at 2021-03-19T09:46:29

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Events
{
    /// Class Definition
    /// <summary>Description of a declarative rule for handling events.</summary>
    public class Rule
    {
        
        /// Property Definition
        /// <summary>Optional identifier that allows referencing this rule.</summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        /// Property Definition
        /// <summary>Tags can be used to annotate rules and perform operations on sets of rules.</summary>
        [JsonPropertyName("tags")]
        public IEnumerable<string> Tags { get; set; }
        
        /// Property Definition
        /// <summary>List of conditions that can trigger the actions.</summary>
        [JsonPropertyName("conditions")]
        public IEnumerable<object> Conditions { get; set; }
        
        /// Property Definition
        /// <summary>List of actions that are triggered if one of the condtions is fulfilled.</summary>
        [JsonPropertyName("actions")]
        public IEnumerable<object> Actions { get; set; }
        
        /// Property Definition
        /// <summary>Optional priority of this rule. Defaults to 100.</summary>
        [JsonPropertyName("priority")]
        public int? Priority { get; set; }
    }
}

