// This file is auto generated at 2021-03-24T04:51:22

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebExtension.Net.Manifest
{
    // Class Definition
    /// <summary>
    /// Represents a WebExtension manifest.json file
    /// </summary>
    public class WebExtensionManifest
    {
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("minimum_chrome_version")]
        public string Minimum_chrome_version { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("minimum_opera_version")]
        public string Minimum_opera_version { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("icons")]
        public object Icons { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("incognito")]
        public string Incognito { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("background")]
        public object Background { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("options_ui")]
        public object Options_ui { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("content_scripts")]
        public IEnumerable<ContentScript> Content_scripts { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("content_security_policy")]
        public object Content_security_policy { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("permissions")]
        public IEnumerable<PermissionOrOrigin> Permissions { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("optional_permissions")]
        public IEnumerable<OptionalPermissionOrOrigin> Optional_permissions { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("web_accessible_resources")]
        public IEnumerable<string> Web_accessible_resources { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("developer")]
        public object Developer { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("hidden")]
        public bool? Hidden { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("theme_experiment")]
        public ThemeExperiment Theme_experiment { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("sidebar_action")]
        public object Sidebar_action { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("experiment_apis")]
        public object Experiment_apis { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("commands")]
        public object Commands { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("browser_action")]
        public object Browser_action { get; set; }
        
        // Property Definition
        /// <summary>
        /// A list of protocol handler definitions.
        /// </summary>
        [JsonPropertyName("protocol_handlers")]
        public IEnumerable<ProtocolHandler> Protocol_handlers { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("devtools_page")]
        public ExtensionURL Devtools_page { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("chrome_settings_overrides")]
        public object Chrome_settings_overrides { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("page_action")]
        public object Page_action { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("chrome_url_overrides")]
        public object Chrome_url_overrides { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("user_scripts")]
        public object User_scripts { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("omnibox")]
        public object Omnibox { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("default_locale")]
        public string Default_locale { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("l10n_resources")]
        public IEnumerable<string> L10n_resources { get; set; }
        
        // Property Definition
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("telemetry")]
        public object Telemetry { get; set; }
    }
}

