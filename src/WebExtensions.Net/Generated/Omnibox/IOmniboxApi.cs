using JsBind.Net;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Omnibox;

/// <summary>The omnibox API allows you to register a keyword with Firefox's address bar.</summary>
[JsAccessPath("omnibox")]
public partial interface IOmniboxApi
{
    /// <summary>User has deleted a suggested result.</summary>
    [JsAccessPath("onDeleteSuggestion")]
    OnDeleteSuggestionEvent OnDeleteSuggestion { get; }

    /// <summary>User has ended the keyword input session without accepting the input.</summary>
    [JsAccessPath("onInputCancelled")]
    Event OnInputCancelled { get; }

    /// <summary>User has changed what is typed into the omnibox.</summary>
    [JsAccessPath("onInputChanged")]
    OnInputChangedEvent OnInputChanged { get; }

    /// <summary>User has accepted what is typed into the omnibox.</summary>
    [JsAccessPath("onInputEntered")]
    OnInputEnteredEvent OnInputEntered { get; }

    /// <summary>User has started a keyword input session by typing the extension's keyword. This is guaranteed to be sent exactly once per input session, and before any onInputChanged events.</summary>
    [JsAccessPath("onInputStarted")]
    Event OnInputStarted { get; }

    /// <summary>Sets the description and styling for the default suggestion. The default suggestion is the text that is displayed in the first suggestion row underneath the URL bar.</summary>
    /// <param name="suggestion">A partial SuggestResult object, without the 'content' parameter.</param>
    [JsAccessPath("setDefaultSuggestion")]
    void SetDefaultSuggestion(DefaultSuggestResult suggestion);
}
