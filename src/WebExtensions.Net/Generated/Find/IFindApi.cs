using JsBind.Net;

namespace WebExtensions.Net.Find
{
    /// <summary>Use the <c>browser.find</c> API to interact with the browser's <c>Find</c> interface.</summary>
    [JsAccessPath("find")]
    public partial interface IFindApi
    {
        /// <summary>Search for text in document and store found ranges in array, in document order.</summary>
        /// <param name="queryphrase">The string to search for.</param>
        /// <param name="params">Search parameters.</param>
        [JsAccessPath("find")]
        void Find(string queryphrase, FindParams @params = null);

        /// <summary>Highlight a range</summary>
        /// <param name="params">highlightResults parameters</param>
        [JsAccessPath("highlightResults")]
        void HighlightResults(HighlightResultsParams @params = null);

        /// <summary>Remove all highlighting from previous searches.</summary>
        /// <param name="tabId">Tab to highlight. Defaults to the active tab.</param>
        [JsAccessPath("removeHighlighting")]
        void RemoveHighlighting(int? tabId = null);
    }
}
