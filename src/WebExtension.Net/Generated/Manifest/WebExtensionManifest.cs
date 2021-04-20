using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebExtension.Net.Manifest;

namespace WebExtension.Net.Manifest
{
    // Type Class
    /// <summary>Represents a WebExtension manifest.json file</summary>
    public class WebExtensionManifest : BaseObject
    {
        private object _background;
        private object _browser_action;
        private object _chrome_settings_overrides;
        private object _chrome_url_overrides;
        private object _commands;
        private IEnumerable<ContentScript> _content_scripts;
        private object _content_security_policy;
        private string _default_locale;
        private object _developer;
        private ExtensionURL _devtools_page;
        private bool? _hidden;
        private object _icons;
        private string _incognito;
        private IEnumerable<string> _l10n_resources;
        private string _minimum_chrome_version;
        private string _minimum_opera_version;
        private object _omnibox;
        private IEnumerable<OptionalPermissionOrOrigin> _optional_permissions;
        private object _options_ui;
        private object _page_action;
        private IEnumerable<PermissionOrOrigin> _permissions;
        private IEnumerable<ProtocolHandler> _protocol_handlers;
        private object _sidebar_action;
        private object _telemetry;
        private ThemeExperiment _theme_experiment;
        private object _user_scripts;
        private IEnumerable<string> _web_accessible_resources;

        /// <summary></summary>
        [JsonPropertyName("background")]
        public object Background
        {
            get
            {
                InitializeProperty("background", _background);
                return _background;
            }
            set
            {
                _background = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("browser_action")]
        public object Browser_action
        {
            get
            {
                InitializeProperty("browser_action", _browser_action);
                return _browser_action;
            }
            set
            {
                _browser_action = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("chrome_settings_overrides")]
        public object Chrome_settings_overrides
        {
            get
            {
                InitializeProperty("chrome_settings_overrides", _chrome_settings_overrides);
                return _chrome_settings_overrides;
            }
            set
            {
                _chrome_settings_overrides = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("chrome_url_overrides")]
        public object Chrome_url_overrides
        {
            get
            {
                InitializeProperty("chrome_url_overrides", _chrome_url_overrides);
                return _chrome_url_overrides;
            }
            set
            {
                _chrome_url_overrides = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("commands")]
        public object Commands
        {
            get
            {
                InitializeProperty("commands", _commands);
                return _commands;
            }
            set
            {
                _commands = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("content_scripts")]
        public IEnumerable<ContentScript> Content_scripts
        {
            get
            {
                InitializeProperty("content_scripts", _content_scripts);
                return _content_scripts;
            }
            set
            {
                _content_scripts = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("content_security_policy")]
        public object Content_security_policy
        {
            get
            {
                InitializeProperty("content_security_policy", _content_security_policy);
                return _content_security_policy;
            }
            set
            {
                _content_security_policy = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("default_locale")]
        public string Default_locale
        {
            get
            {
                InitializeProperty("default_locale", _default_locale);
                return _default_locale;
            }
            set
            {
                _default_locale = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("developer")]
        public object Developer
        {
            get
            {
                InitializeProperty("developer", _developer);
                return _developer;
            }
            set
            {
                _developer = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("devtools_page")]
        public ExtensionURL Devtools_page
        {
            get
            {
                InitializeProperty("devtools_page", _devtools_page);
                return _devtools_page;
            }
            set
            {
                _devtools_page = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("hidden")]
        public bool? Hidden
        {
            get
            {
                InitializeProperty("hidden", _hidden);
                return _hidden;
            }
            set
            {
                _hidden = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("icons")]
        public object Icons
        {
            get
            {
                InitializeProperty("icons", _icons);
                return _icons;
            }
            set
            {
                _icons = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("incognito")]
        public string Incognito
        {
            get
            {
                InitializeProperty("incognito", _incognito);
                return _incognito;
            }
            set
            {
                _incognito = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("l10n_resources")]
        public IEnumerable<string> L10n_resources
        {
            get
            {
                InitializeProperty("l10n_resources", _l10n_resources);
                return _l10n_resources;
            }
            set
            {
                _l10n_resources = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("minimum_chrome_version")]
        public string Minimum_chrome_version
        {
            get
            {
                InitializeProperty("minimum_chrome_version", _minimum_chrome_version);
                return _minimum_chrome_version;
            }
            set
            {
                _minimum_chrome_version = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("minimum_opera_version")]
        public string Minimum_opera_version
        {
            get
            {
                InitializeProperty("minimum_opera_version", _minimum_opera_version);
                return _minimum_opera_version;
            }
            set
            {
                _minimum_opera_version = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("omnibox")]
        public object Omnibox
        {
            get
            {
                InitializeProperty("omnibox", _omnibox);
                return _omnibox;
            }
            set
            {
                _omnibox = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("optional_permissions")]
        public IEnumerable<OptionalPermissionOrOrigin> Optional_permissions
        {
            get
            {
                InitializeProperty("optional_permissions", _optional_permissions);
                return _optional_permissions;
            }
            set
            {
                _optional_permissions = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("options_ui")]
        public object Options_ui
        {
            get
            {
                InitializeProperty("options_ui", _options_ui);
                return _options_ui;
            }
            set
            {
                _options_ui = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("page_action")]
        public object Page_action
        {
            get
            {
                InitializeProperty("page_action", _page_action);
                return _page_action;
            }
            set
            {
                _page_action = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("permissions")]
        public IEnumerable<PermissionOrOrigin> Permissions
        {
            get
            {
                InitializeProperty("permissions", _permissions);
                return _permissions;
            }
            set
            {
                _permissions = value;
            }
        }

        /// <summary>A list of protocol handler definitions.</summary>
        [JsonPropertyName("protocol_handlers")]
        public IEnumerable<ProtocolHandler> Protocol_handlers
        {
            get
            {
                InitializeProperty("protocol_handlers", _protocol_handlers);
                return _protocol_handlers;
            }
            set
            {
                _protocol_handlers = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("sidebar_action")]
        public object Sidebar_action
        {
            get
            {
                InitializeProperty("sidebar_action", _sidebar_action);
                return _sidebar_action;
            }
            set
            {
                _sidebar_action = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("telemetry")]
        public object Telemetry
        {
            get
            {
                InitializeProperty("telemetry", _telemetry);
                return _telemetry;
            }
            set
            {
                _telemetry = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("theme_experiment")]
        public ThemeExperiment Theme_experiment
        {
            get
            {
                InitializeProperty("theme_experiment", _theme_experiment);
                return _theme_experiment;
            }
            set
            {
                _theme_experiment = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("user_scripts")]
        public object User_scripts
        {
            get
            {
                InitializeProperty("user_scripts", _user_scripts);
                return _user_scripts;
            }
            set
            {
                _user_scripts = value;
            }
        }

        /// <summary></summary>
        [JsonPropertyName("web_accessible_resources")]
        public IEnumerable<string> Web_accessible_resources
        {
            get
            {
                InitializeProperty("web_accessible_resources", _web_accessible_resources);
                return _web_accessible_resources;
            }
            set
            {
                _web_accessible_resources = value;
            }
        }
    }
}
