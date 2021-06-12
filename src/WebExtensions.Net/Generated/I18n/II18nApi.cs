using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.I18n
{
    /// <summary>Use the <c>browser.i18n</c> infrastructure to implement internationalization across your whole app or extension.</summary>
    public partial interface II18nApi
    {
        /// <summary>Detects the language of the provided text using CLD.</summary>
        /// <param name="text">User input string to be translated.</param>
        /// <returns>LanguageDetectionResult object that holds detected langugae reliability and array of DetectedLanguage</returns>
        ValueTask<Result> DetectLanguage(string text);

        /// <summary>Gets the accept-languages of the browser. This is different from the locale used by the browser; to get the locale, use $(ref:i18n.getUILanguage).</summary>
        /// <returns>Array of LanguageCode</returns>
        ValueTask<IEnumerable<LanguageCode>> GetAcceptLanguages();

        /// <summary>Gets the localized string for the specified message. If the message is missing, this method returns an empty string (''). If the format of the <c>getMessage()</c> call is wrong - for example, <em>messageName</em> is not a string or the <em>substitutions</em> array has more than 9 elements - this method returns <c>undefined</c>.</summary>
        /// <param name="messageName">The name of the message, as specified in the <c>$(topic:i18n-messages)[messages.json]</c> file.</param>
        /// <param name="substitutions">Substitution strings, if the message requires any.</param>
        /// <returns>Message localized for current locale.</returns>
        ValueTask<string> GetMessage(string messageName, object substitutions);

        /// <summary>Gets the browser UI language of the browser. This is different from $(ref:i18n.getAcceptLanguages) which returns the preferred user languages.</summary>
        /// <returns>The browser UI language code such as en-US or fr-FR.</returns>
        ValueTask<string> GetUILanguage();
    }
}
