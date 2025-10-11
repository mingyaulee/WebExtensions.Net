﻿using JsBind.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtensions.Net.Storage;

// Type Class
/// <summary></summary>
[BindAllProperties]
public partial class StorageAreaWithUsage : BaseObject
{
    /// <summary>Removes all items from storage.</summary>
    [JsAccessPath("clear")]
    public virtual ValueTask Clear()
        => InvokeVoidAsync("clear");

    /// <summary>Gets one or more items from storage.</summary>
    /// <param name="keys">A single key to get, list of keys to get, or a dictionary specifying default values (see description of the object).  An empty list or object will return an empty result object.  Pass in <c>null</c> to get the entire contents of storage.</param>
    /// <returns>Object with items in their key-value mappings.</returns>
    [JsAccessPath("get")]
    public virtual ValueTask<JsonElement> Get(StorageAreaWithUsageGetKeys keys = null)
        => InvokeAsync<JsonElement>("get", keys);

    /// <summary>Gets the amount of space (in bytes) being used by one or more items.</summary>
    /// <param name="keys">A single key or list of keys to get the total usage for. An empty list will return 0. Pass in <c>null</c> to get the total usage of all of storage.</param>
    /// <returns>Amount of space being used in storage, in bytes.</returns>
    [JsAccessPath("getBytesInUse")]
    public virtual ValueTask<int> GetBytesInUse(StorageAreaWithUsageGetBytesInUseKeys keys = null)
        => InvokeAsync<int>("getBytesInUse", keys);

    /// <summary>Removes one or more items from storage.</summary>
    /// <param name="keys">A single key or a list of keys for items to remove.</param>
    [JsAccessPath("remove")]
    public virtual ValueTask Remove(StorageAreaWithUsageRemoveKeys keys)
        => InvokeVoidAsync("remove", keys);

    /// <summary>Sets multiple items.</summary>
    /// <param name="items">An object which gives each key/value pair to update storage with. Any other key/value pairs in storage will not be affected.<br />Primitive values such as numbers will serialize as expected. Values with a <c>typeof</c> <c>"object"</c> and <c>"function"</c> will typically serialize to <c>{}</c>, with the exception of <c>Array</c> (serializes as expected), <c>Date</c>, and <c>Regex</c> (serialize using their <c>String</c> representation).<br /></param>
    [JsAccessPath("set")]
    public virtual ValueTask Set(object items)
        => InvokeVoidAsync("set", items);
}
