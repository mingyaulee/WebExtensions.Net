using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Events
{
    // Class Definition
    /// <summary>
    /// Description of a declarative rule for handling events.
    /// </summary>
    public class Rule : BaseObject
    {
        
        // Property Definition
        private string _id;
        /// <summary>
        /// Optional identifier that allows referencing this rule.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id
        {
            get
            {
                InitializeProperty("id", _id);
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        
        // Property Definition
        private IEnumerable<string> _tags;
        /// <summary>
        /// Tags can be used to annotate rules and perform operations on sets of rules.
        /// </summary>
        [JsonPropertyName("tags")]
        public IEnumerable<string> Tags
        {
            get
            {
                InitializeProperty("tags", _tags);
                return _tags;
            }
            set
            {
                _tags = value;
            }
        }
        
        // Property Definition
        private IEnumerable<object> _conditions;
        /// <summary>
        /// List of conditions that can trigger the actions.
        /// </summary>
        [JsonPropertyName("conditions")]
        public IEnumerable<object> Conditions
        {
            get
            {
                InitializeProperty("conditions", _conditions);
                return _conditions;
            }
            set
            {
                _conditions = value;
            }
        }
        
        // Property Definition
        private IEnumerable<object> _actions;
        /// <summary>
        /// List of actions that are triggered if one of the condtions is fulfilled.
        /// </summary>
        [JsonPropertyName("actions")]
        public IEnumerable<object> Actions
        {
            get
            {
                InitializeProperty("actions", _actions);
                return _actions;
            }
            set
            {
                _actions = value;
            }
        }
        
        // Property Definition
        private int? _priority;
        /// <summary>
        /// Optional priority of this rule. Defaults to 100.
        /// </summary>
        [JsonPropertyName("priority")]
        public int? Priority
        {
            get
            {
                InitializeProperty("priority", _priority);
                return _priority;
            }
            set
            {
                _priority = value;
            }
        }
    }
}

