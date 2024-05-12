using System.Threading.Tasks;

namespace WebExtensions.Net.Devtools.InspectedWindow
{
    /// <summary>Use the <c>chrome.devtools.inspectedWindow</c> API to interact with the inspected window: obtain the tab ID for the inspected page, evaluate the code in the context of the inspected window, reload the page, or obtain the list of resources within the page.</summary>
    public partial interface IInspectedWindowApi
    {
        /// <summary>The ID of the tab being inspected. This ID may be used with chrome.tabs.* API.</summary>
        int TabId { get; }

        /// <summary>Evaluates a JavaScript expression in the context of the main frame of the inspected page. The expression must evaluate to a JSON-compliant object, otherwise an exception is thrown. The eval function can report either a DevTools-side error or a JavaScript exception that occurs during evaluation. In either case, the <c>result</c> parameter of the callback is <c>undefined</c>. In the case of a DevTools-side error, the <c>isException</c> parameter is non-null and has <c>isError</c> set to true and <c>code</c> set to an error code. In the case of a JavaScript error, <c>isException</c> is set to true and <c>value</c> is set to the string value of thrown object.</summary>
        /// <param name="expression">An expression to evaluate.</param>
        /// <param name="options">The options parameter can contain one or more options.</param>
        /// <returns></returns>
        ValueTask<EvalResult> Eval(string expression, object options = null);

        /// <summary>Reloads the inspected page.</summary>
        /// <param name="reloadOptions"></param>
        ValueTask Reload(ReloadOptions reloadOptions = null);
    }
}
