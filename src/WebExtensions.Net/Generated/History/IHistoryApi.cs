using JsBind.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebExtensions.Net.History;

/// <summary>Use the <c>browser.history</c> API to interact with the browser's record of visited pages. You can add, remove, and query for URLs in the browser's history. To override the history page with your own version, see $(topic:override)[Override Pages].</summary>
[JsAccessPath("history")]
public partial interface IHistoryApi
{
    /// <summary>Fired when the title of a URL is changed in the browser history.</summary>
    [JsAccessPath("onTitleChanged")]
    OnTitleChangedEvent OnTitleChanged { get; }

    /// <summary>Fired when a URL is visited, providing the HistoryItem data for that URL.  This event fires before the page has loaded.</summary>
    [JsAccessPath("onVisited")]
    OnVisitedEvent OnVisited { get; }

    /// <summary>Fired when one or more URLs are removed from the history service.  When all visits have been removed the URL is purged from history.</summary>
    [JsAccessPath("onVisitRemoved")]
    OnVisitRemovedEvent OnVisitRemoved { get; }

    /// <summary>Adds a URL to the history with a default visitTime of the current time and a default $(topic:transition-types)[transition type] of "link".</summary>
    /// <param name="details"></param>
    [JsAccessPath("addUrl")]
    ValueTask AddUrl(AddUrlDetails details);

    /// <summary>Deletes all items from the history.</summary>
    [JsAccessPath("deleteAll")]
    ValueTask DeleteAll();

    /// <summary>Removes all items within the specified date range from the history.  Pages will not be removed from the history unless all visits fall within the range.</summary>
    /// <param name="range"></param>
    [JsAccessPath("deleteRange")]
    ValueTask DeleteRange(Range range);

    /// <summary>Removes all occurrences of the given URL from the history.</summary>
    /// <param name="details"></param>
    [JsAccessPath("deleteUrl")]
    ValueTask DeleteUrl(DeleteUrlDetails details);

    /// <summary>Retrieves information about visits to a URL.</summary>
    /// <param name="details"></param>
    /// <returns></returns>
    [JsAccessPath("getVisits")]
    ValueTask<IEnumerable<VisitItem>> GetVisits(GetVisitsDetails details);

    /// <summary>Searches the history for the last visit time of each page matching the query.</summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [JsAccessPath("search")]
    ValueTask<IEnumerable<HistoryItem>> Search(Query query);
}
