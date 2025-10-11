using JsBind.Net;
using System.Collections.Generic;

namespace WebExtensions.Net.ContextualIdentities;

/// <inheritdoc />
/// <param name="jsRuntime">The JS runtime adapter.</param>
/// <param name="accessPath">The base API access path.</param>
public partial class ContextualIdentitiesApi(IJsRuntimeAdapter jsRuntime, string accessPath) : BaseApi(jsRuntime, AccessPaths.Combine(accessPath, "contextualIdentities")), IContextualIdentitiesApi
{
    private OnCreatedEvent _onCreated;
    private OnRemovedEvent _onRemoved;
    private OnUpdatedEvent _onUpdated;

    /// <inheritdoc />
    public OnCreatedEvent OnCreated
    {
        get
        {
            if (_onCreated is null)
            {
                _onCreated = new OnCreatedEvent();
                _onCreated.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onCreated"));
            }
            return _onCreated;
        }
    }

    /// <inheritdoc />
    public OnRemovedEvent OnRemoved
    {
        get
        {
            if (_onRemoved is null)
            {
                _onRemoved = new OnRemovedEvent();
                _onRemoved.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onRemoved"));
            }
            return _onRemoved;
        }
    }

    /// <inheritdoc />
    public OnUpdatedEvent OnUpdated
    {
        get
        {
            if (_onUpdated is null)
            {
                _onUpdated = new OnUpdatedEvent();
                _onUpdated.Initialize(JsRuntime, AccessPaths.Combine(AccessPath, "onUpdated"));
            }
            return _onUpdated;
        }
    }

    /// <inheritdoc />
    public virtual void Create(CreateDetails details)
        => InvokeVoid("create", details);

    /// <inheritdoc />
    public virtual void Get(string cookieStoreId)
        => InvokeVoid("get", cookieStoreId);

    /// <inheritdoc />
    public virtual void Move(string cookieStoreIds, int position)
        => InvokeVoid("move", cookieStoreIds, position);

    /// <inheritdoc />
    public virtual void Move(IEnumerable<string> cookieStoreIds, int position)
        => InvokeVoid("move", cookieStoreIds, position);

    /// <inheritdoc />
    public virtual void Query(QueryDetails details)
        => InvokeVoid("query", details);

    /// <inheritdoc />
    public virtual void Remove(string cookieStoreId)
        => InvokeVoid("remove", cookieStoreId);

    /// <inheritdoc />
    public virtual void Update(string cookieStoreId, UpdateDetails details)
        => InvokeVoid("update", cookieStoreId, details);
}
