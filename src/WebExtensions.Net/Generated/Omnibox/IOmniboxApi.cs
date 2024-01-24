using System.Threading.Tasks;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Omnibox
{
    /// <summary>The omnibox API allows you to register a keyword with Firefox's address bar.</summary>
    public partial interface IOmniboxApi
    {
        /// <summary>User has deleted a suggested result.</summary>
        OnDeleteSuggestionEvent OnDeleteSuggestion { get; }

        /// <summary>User has ended the keyword input session without accepting the input.</summary>
        Event OnInputCancelled { get; }

        /// <summary>User has changed what is typed into the omnibox.</summary>
        OnInputChangedEvent OnInputChanged { get; }

        /// <summary>User has accepted what is typed into the omnibox.</summary>
        OnInputEnteredEvent OnInputEntered { get; }

        /// <summary>User has started a keyword input session by typing the extension's keyword. This is guaranteed to be sent exactly once per input session, and before any onInputChanged events.</summary>
        Event OnInputStarted { get; }

        /// <summary>Sets the description and styling for the default suggestion. The default suggestion is the text that is displayed in the first suggestion row underneath the URL bar.</summary>
        /// <param name="suggestion">A partial SuggestResult object, without the 'content' parameter.</param>
        ValueTask SetDefaultSuggestion(DefaultSuggestResult suggestion);
    }
}
