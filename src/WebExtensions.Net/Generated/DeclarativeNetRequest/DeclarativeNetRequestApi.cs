using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.DeclarativeNetRequest
{
    /// <inheritdoc />
    /// <param name="jsRuntime">The JS runtime adapter.</param>
    /// <param name="accessPath">The base API access path.</param>
    public partial class DeclarativeNetRequestApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "declarativeNetRequest")), IDeclarativeNetRequestApi
    {
        /// <inheritdoc />
        public string DYNAMIC_RULESET_ID => "_dynamic";

        /// <inheritdoc />
        public double GUARANTEED_MINIMUM_STATIC_RULES => GetProperty<double>(nameof(GUARANTEED_MINIMUM_STATIC_RULES));

        /// <inheritdoc />
        public double MAX_NUMBER_OF_DISABLED_STATIC_RULES => GetProperty<double>(nameof(MAX_NUMBER_OF_DISABLED_STATIC_RULES));

        /// <inheritdoc />
        public double MAX_NUMBER_OF_DYNAMIC_AND_SESSION_RULES => GetProperty<double>(nameof(MAX_NUMBER_OF_DYNAMIC_AND_SESSION_RULES));

        /// <inheritdoc />
        public double MAX_NUMBER_OF_DYNAMIC_RULES => GetProperty<double>(nameof(MAX_NUMBER_OF_DYNAMIC_RULES));

        /// <inheritdoc />
        public double MAX_NUMBER_OF_ENABLED_STATIC_RULESETS => GetProperty<double>(nameof(MAX_NUMBER_OF_ENABLED_STATIC_RULESETS));

        /// <inheritdoc />
        public double MAX_NUMBER_OF_REGEX_RULES => GetProperty<double>(nameof(MAX_NUMBER_OF_REGEX_RULES));

        /// <inheritdoc />
        public double MAX_NUMBER_OF_SESSION_RULES => GetProperty<double>(nameof(MAX_NUMBER_OF_SESSION_RULES));

        /// <inheritdoc />
        public double MAX_NUMBER_OF_STATIC_RULESETS => GetProperty<double>(nameof(MAX_NUMBER_OF_STATIC_RULESETS));

        /// <inheritdoc />
        public string SESSION_RULESET_ID => "_session";

        /// <inheritdoc />
        public virtual ValueTask<int> GetAvailableStaticRuleCount()
            => InvokeAsync<int>("getAvailableStaticRuleCount");

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<int>> GetDisabledRuleIds(GetDisabledRuleIdsOptions options)
            => InvokeAsync<IEnumerable<int>>("getDisabledRuleIds", options);

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<Rule>> GetDynamicRules(GetRulesFilter filter = null)
            => InvokeAsync<IEnumerable<Rule>>("getDynamicRules", filter);

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<string>> GetEnabledRulesets()
            => InvokeAsync<IEnumerable<string>>("getEnabledRulesets");

        /// <inheritdoc />
        public virtual ValueTask<IEnumerable<Rule>> GetSessionRules(GetRulesFilter filter = null)
            => InvokeAsync<IEnumerable<Rule>>("getSessionRules", filter);

        /// <inheritdoc />
        public virtual ValueTask<IsRegexSupportedCallbackResult> IsRegexSupported(RegexOptions regexOptions)
            => InvokeAsync<IsRegexSupportedCallbackResult>("isRegexSupported", regexOptions);

        /// <inheritdoc />
        public virtual ValueTask<TestMatchOutcomeCallbackResult> TestMatchOutcome(Request request, TestMatchOutcomeOptions options = null)
            => InvokeAsync<TestMatchOutcomeCallbackResult>("testMatchOutcome", request, options);

        /// <inheritdoc />
        public virtual ValueTask UpdateDynamicRules(UpdateDynamicRulesOptions options)
            => InvokeVoidAsync("updateDynamicRules", options);

        /// <inheritdoc />
        public virtual ValueTask UpdateEnabledRulesets(UpdateRulesetOptions updateRulesetOptions)
            => InvokeVoidAsync("updateEnabledRulesets", updateRulesetOptions);

        /// <inheritdoc />
        public virtual ValueTask UpdateSessionRules(UpdateSessionRulesOptions options)
            => InvokeVoidAsync("updateSessionRules", options);

        /// <inheritdoc />
        public virtual ValueTask UpdateStaticRules(UpdateStaticRulesOptions options)
            => InvokeVoidAsync("updateStaticRules", options);
    }
}
