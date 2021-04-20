using System.Text.Json.Serialization;

namespace WebExtension.Net.Manifest
{
    // Type Class
    /// <summary>Contents of manifest.json for a static theme</summary>
    public class ThemeManifest : BaseObject
    {
        private ThemeType _dark_theme;
        private string _default_locale;
        private object _icons;
        private ThemeType _theme;
        private ThemeExperiment _theme_experiment;

        /// <summary></summary>
        [JsonPropertyName("dark_theme")]
        public ThemeType Dark_theme
        {
            get
            {
                InitializeProperty("dark_theme", _dark_theme);
                return _dark_theme;
            }
            set
            {
                _dark_theme = value;
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
        [JsonPropertyName("theme")]
        public ThemeType Theme
        {
            get
            {
                InitializeProperty("theme", _theme);
                return _theme;
            }
            set
            {
                _theme = value;
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
    }
}
