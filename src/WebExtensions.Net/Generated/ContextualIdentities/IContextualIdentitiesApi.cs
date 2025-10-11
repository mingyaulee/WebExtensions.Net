using JsBind.Net;
using System.Collections.Generic;

namespace WebExtensions.Net.ContextualIdentities;

/// <summary>Use the <c>browser.contextualIdentities</c> API to query and modify contextual identity, also called as containers.</summary>
[JsAccessPath("contextualIdentities")]
public partial interface IContextualIdentitiesApi
{
    /// <summary>Fired when a new container is created.</summary>
    [JsAccessPath("onCreated")]
    OnCreatedEvent OnCreated { get; }

    /// <summary>Fired when a container is removed.</summary>
    [JsAccessPath("onRemoved")]
    OnRemovedEvent OnRemoved { get; }

    /// <summary>Fired when a container is updated.</summary>
    [JsAccessPath("onUpdated")]
    OnUpdatedEvent OnUpdated { get; }

    /// <summary>Creates a contextual identity with the given data.</summary>
    /// <param name="details">Details about the contextual identity being created.</param>
    [JsAccessPath("create")]
    void Create(CreateDetails details);

    /// <summary>Retrieves information about a single contextual identity.</summary>
    /// <param name="cookieStoreId">The ID of the contextual identity cookie store. </param>
    [JsAccessPath("get")]
    void Get(string cookieStoreId);

    /// <summary>Reorder one or more contextual identities by their cookieStoreIDs to a given position.</summary>
    /// <param name="cookieStoreIds">The ID or list of IDs of the contextual identity cookie stores. </param>
    /// <param name="position">The position the contextual identity should move to.</param>
    [JsAccessPath("move")]
    void Move(string cookieStoreIds, int position);

    /// <summary>Reorder one or more contextual identities by their cookieStoreIDs to a given position.</summary>
    /// <param name="cookieStoreIds">The ID or list of IDs of the contextual identity cookie stores. </param>
    /// <param name="position">The position the contextual identity should move to.</param>
    [JsAccessPath("move")]
    void Move(IEnumerable<string> cookieStoreIds, int position);

    /// <summary>Retrieves all contextual identities</summary>
    /// <param name="details">Information to filter the contextual identities being retrieved.</param>
    [JsAccessPath("query")]
    void Query(QueryDetails details);

    /// <summary>Deletes a contextual identity by its cookie Store ID.</summary>
    /// <param name="cookieStoreId">The ID of the contextual identity cookie store. </param>
    [JsAccessPath("remove")]
    void Remove(string cookieStoreId);

    /// <summary>Updates a contextual identity with the given data.</summary>
    /// <param name="cookieStoreId">The ID of the contextual identity cookie store. </param>
    /// <param name="details">Details about the contextual identity being created.</param>
    [JsAccessPath("update")]
    void Update(string cookieStoreId, UpdateDetails details);
}
