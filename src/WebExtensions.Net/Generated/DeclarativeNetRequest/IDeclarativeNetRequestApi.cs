using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.DeclarativeNetRequest
{
    /// <summary>Use the declarativeNetRequest API to block or modify network requests by specifying declarative rules.</summary>
    public partial interface IDeclarativeNetRequestApi
    {
        /// <summary>Ruleset ID for the dynamic rules added by the extension.</summary>
        string DYNAMIC_RULESET_ID { get; }

        /// <summary>The minimum number of static rules guaranteed to an extension across its enabled static rulesets. Any rules above this limit will count towards the global static rule limit.</summary>
        double GUARANTEED_MINIMUM_STATIC_RULES { get; }

        /// <summary>The maximum number of dynamic and session rules an extension can add. NOTE: in the Firefox we are enforcing this limit to the session and dynamic rules count separately, instead of enforcing it to the rules count for both combined as the Chrome implementation does.</summary>
        double MAX_NUMBER_OF_DYNAMIC_AND_SESSION_RULES { get; }

        /// <summary>The maximum number of static Rulesets an extension can enable at any one time.</summary>
        double MAX_NUMBER_OF_ENABLED_STATIC_RULESETS { get; }

        /// <summary>The maximum number of regular expression rules that an extension can add. This limit is evaluated separately for the set of session rules, dynamic rules and those specified in the rule_resources file.</summary>
        double MAX_NUMBER_OF_REGEX_RULES { get; }

        /// <summary>The maximum number of static Rulesets an extension can specify as part of the rule_resources manifest key.</summary>
        double MAX_NUMBER_OF_STATIC_RULESETS { get; }

        /// <summary>Ruleset ID for the session-scoped rules added by the extension.</summary>
        string SESSION_RULESET_ID { get; }

        /// <summary>Returns the remaining number of static rules an extension can enable</summary>
        /// <returns></returns>
        ValueTask<int> GetAvailableStaticRuleCount();

        /// <summary>Returns the current set of dynamic rules for the extension.</summary>
        /// <returns></returns>
        ValueTask<IEnumerable<Rule>> GetDynamicRules();

        /// <summary>Returns the ids for the current set of enabled static rulesets.</summary>
        /// <returns></returns>
        ValueTask<IEnumerable<string>> GetEnabledRulesets();

        /// <summary>Returns the current set of session scoped rules for the extension.</summary>
        /// <returns></returns>
        ValueTask<IEnumerable<Rule>> GetSessionRules();

        /// <summary>Checks if the given regular expression will be supported as a 'regexFilter' rule condition.</summary>
        /// <param name="regexOptions"></param>
        /// <returns></returns>
        ValueTask<IsRegexSupportedCallbackResult> IsRegexSupported(RegexOptions regexOptions);

        /// <summary>Checks if any of the extension's declarativeNetRequest rules would match a hypothetical request.</summary>
        /// <param name="request">The details of the request to test.</param>
        /// <param name="options"></param>
        /// <returns></returns>
        ValueTask<TestMatchOutcomeCallbackResult> TestMatchOutcome(Request request, TestMatchOutcomeOptions options = null);

        /// <summary>Modifies the current set of dynamic rules for the extension. The rules with IDs listed in options.removeRuleIds are first removed, and then the rules given in options.addRules are added. These rules are persisted across browser sessions and extension updates.</summary>
        /// <param name="options"></param>
        ValueTask UpdateDynamicRules(UpdateDynamicRulesOptions options);

        /// <summary>Returns the ids for the current set of enabled static rulesets.</summary>
        /// <param name="updateRulesetOptions"></param>
        ValueTask UpdateEnabledRulesets(UpdateRulesetOptions updateRulesetOptions);

        /// <summary>Modifies the current set of session scoped rules for the extension. The rules with IDs listed in options.removeRuleIds are first removed, and then the rules given in options.addRules are added. These rules are not persisted across sessions and are backed in memory.</summary>
        /// <param name="options"></param>
        ValueTask UpdateSessionRules(UpdateSessionRulesOptions options);
    }
}
