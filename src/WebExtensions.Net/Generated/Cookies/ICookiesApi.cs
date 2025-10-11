using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.Cookies;

/// <summary>Use the <c>browser.cookies</c> API to query and modify cookies, and to be notified when they change.</summary>
[JsAccessPath("cookies")]
public partial interface ICookiesApi
{
    /// <summary>Fired when a cookie is set or removed. As a special case, note that updating a cookie's properties is implemented as a two step process: the cookie to be updated is first removed entirely, generating a notification with "cause" of "overwrite" .  Afterwards, a new cookie is written with the updated values, generating a second notification with "cause" "explicit".</summary>
    [JsAccessPath("onChanged")]
    OnChangedEvent OnChanged { get; }

    /// <summary>Retrieves information about a single cookie. If more than one cookie of the same name exists for the given URL, the one with the longest path will be returned. For cookies with the same path length, the cookie with the earliest creation time will be returned.</summary>
    /// <param name="details">Details to identify the cookie being retrieved.</param>
    /// <returns>Contains details about the cookie. This parameter is null if no such cookie was found.</returns>
    [JsAccessPath("get")]
    ValueTask<Cookie> Get(GetDetails details);

    /// <summary>Retrieves all cookies from a single cookie store that match the given information.  The cookies returned will be sorted, with those with the longest path first.  If multiple cookies have the same path length, those with the earliest creation time will be first.</summary>
    /// <param name="details">Information to filter the cookies being retrieved.</param>
    /// <returns>All the existing, unexpired cookies that match the given cookie info.</returns>
    [JsAccessPath("getAll")]
    ValueTask<IEnumerable<Cookie>> GetAll(GetAllDetails details);

    /// <summary>Lists all existing cookie stores.</summary>
    /// <returns>All the existing cookie stores.</returns>
    [JsAccessPath("getAllCookieStores")]
    ValueTask<IEnumerable<CookieStore>> GetAllCookieStores();

    /// <summary>Deletes a cookie by name.</summary>
    /// <param name="details">Information to identify the cookie to remove.</param>
    /// <returns>Contains details about the cookie that's been removed.  If removal failed for any reason, this will be "null", and $(ref:runtime.lastError) will be set.</returns>
    [JsAccessPath("remove")]
    ValueTask<CallbackDetails> Remove(RemoveDetails details);

    /// <summary>Sets a cookie with the given cookie data; may overwrite equivalent cookies if they exist.</summary>
    /// <param name="details">Details about the cookie being set.</param>
    /// <returns>Contains details about the cookie that's been set.  If setting failed for any reason, this will be "null", and $(ref:runtime.lastError) will be set.</returns>
    [JsAccessPath("set")]
    ValueTask<Cookie> Set(SetDetails details);
}
