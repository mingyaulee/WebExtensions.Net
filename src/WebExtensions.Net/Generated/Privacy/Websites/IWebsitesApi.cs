using JsBind.Net;
using WebExtensions.Net.Types;

namespace WebExtensions.Net.Privacy.Websites
{
    /// <summary>Use the <c>browser.privacy</c> API to control usage of the features in the browser that can affect a user's privacy.</summary>
    [JsAccessPath("websites")]
    public partial interface IWebsitesApi
    {
        /// <summary>Allow users to specify the default settings for allowing cookies, as well as whether all cookies should be created as non-persistent cookies. This setting's value is of type CookieConfig.</summary>
        [JsAccessPath("cookieConfig")]
        Setting CookieConfig { get; }

        /// <summary>If enabled, the browser will associate all data (including cookies, HSTS data, cached images, and more) for any third party domains with the domain in the address bar. This prevents third party trackers from using directly stored information to identify you across different websites, but may break websites where you login with a third party account (such as a Facebook or Google login.) The value of this preference is of type boolean, and the default value is <c>false</c>.</summary>
        [JsAccessPath("firstPartyIsolate")]
        Setting FirstPartyIsolate { get; }

        /// <summary>If enabled, the browser sends auditing pings when requested by a website (<c>&amp;lt;a ping&amp;gt;</c>). The value of this preference is of type boolean, and the default value is <c>true</c>.</summary>
        [JsAccessPath("hyperlinkAuditingEnabled")]
        Setting HyperlinkAuditingEnabled { get; }

        /// <summary>If enabled, the browser sends <c>referer</c> headers with your requests. Yes, the name of this preference doesn't match the misspelled header. No, we're not going to change it. The value of this preference is of type boolean, and the default value is <c>true</c>.</summary>
        [JsAccessPath("referrersEnabled")]
        Setting ReferrersEnabled { get; }

        /// <summary>If enabled, the browser attempts to appear similar to other users by reporting generic information to websites. This can prevent websites from uniquely identifying users. Examples of data that is spoofed include number of CPU cores, precision of JavaScript timers, the local timezone, and disabling features such as GamePad support, and the WebSpeech and Navigator APIs. The value of this preference is of type boolean, and the default value is <c>false</c>.</summary>
        [JsAccessPath("resistFingerprinting")]
        Setting ResistFingerprinting { get; }

        /// <summary>Allow users to specify the mode for tracking protection. This setting's value is of type TrackingProtectionModeOption, defaulting to <c>private_browsing_only</c>.</summary>
        [JsAccessPath("trackingProtectionMode")]
        Setting TrackingProtectionMode { get; }
    }
}
