using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.DeclarativeNetRequest
{
    /// <summary>Use the declarativeNetRequest API to block or modify network requests by specifying declarative rules.</summary>
    public partial interface IDeclarativeNetRequestApi
    {
        /// <summary>Returns the current set of session scoped rules for the extension.</summary>
        /// <returns></returns>
        ValueTask<IEnumerable<Rule>> GetSessionRules();

        /// <summary>Checks if any of the extension's declarativeNetRequest rules would match a hypothetical request.</summary>
        /// <param name="request">The details of the request to test.</param>
        /// <returns></returns>
        ValueTask<Result> TestMatchOutcome(Request request);

        /// <summary>Modifies the current set of session scoped rules for the extension. The rules with IDs listed in options.removeRuleIds are first removed, and then the rules given in options.addRules are added. These rules are not persisted across sessions and are backed in memory.</summary>
        /// <param name="options"></param>
        ValueTask UpdateSessionRules(Options options);
    }
}
