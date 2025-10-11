using JsBind.Net;
using WebExtensions.Net.Events;

namespace WebExtensions.Net.Omnibox;

/// <inheritdoc />
/// <param name="jsRuntime">The JS runtime adapter.</param>
/// <param name="accessPath">The base API access path.</param>
public partial class OmniboxApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "omnibox")), IOmniboxApi
{
    private OnDeleteSuggestionEvent _onDeleteSuggestion;
    private Event _onInputCancelled;
    private OnInputChangedEvent _onInputChanged;
    private OnInputEnteredEvent _onInputEntered;
    private Event _onInputStarted;

    /// <inheritdoc />
    public OnDeleteSuggestionEvent OnDeleteSuggestion
    {
        get
        {
            if (_onDeleteSuggestion is null)
            {
                _onDeleteSuggestion = new OnDeleteSuggestionEvent();
                _onDeleteSuggestion.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onDeleteSuggestion"));
            }
            return _onDeleteSuggestion;
        }
    }

    /// <inheritdoc />
    public Event OnInputCancelled
    {
        get
        {
            if (_onInputCancelled is null)
            {
                _onInputCancelled = new Event();
                _onInputCancelled.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onInputCancelled"));
            }
            return _onInputCancelled;
        }
    }

    /// <inheritdoc />
    public OnInputChangedEvent OnInputChanged
    {
        get
        {
            if (_onInputChanged is null)
            {
                _onInputChanged = new OnInputChangedEvent();
                _onInputChanged.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onInputChanged"));
            }
            return _onInputChanged;
        }
    }

    /// <inheritdoc />
    public OnInputEnteredEvent OnInputEntered
    {
        get
        {
            if (_onInputEntered is null)
            {
                _onInputEntered = new OnInputEnteredEvent();
                _onInputEntered.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onInputEntered"));
            }
            return _onInputEntered;
        }
    }

    /// <inheritdoc />
    public Event OnInputStarted
    {
        get
        {
            if (_onInputStarted is null)
            {
                _onInputStarted = new Event();
                _onInputStarted.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onInputStarted"));
            }
            return _onInputStarted;
        }
    }

    /// <inheritdoc />
    public virtual void SetDefaultSuggestion(DefaultSuggestResult suggestion)
        => InvokeVoid("setDefaultSuggestion", suggestion);
}
