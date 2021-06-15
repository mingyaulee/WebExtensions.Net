using System.Threading.Tasks;
using WebExtensions.Net.Manifest;

namespace WebExtensions.Net.Devtools.Panels
{
    // Type Class
    /// <summary>A sidebar created by the extension.</summary>
    public partial class ExtensionSidebarPane : BaseObject
    {
        /// <summary>Sets an expression that is evaluated within the inspected page. The result is displayed in the sidebar pane.</summary>
        /// <param name="expression">An expression to be evaluated in context of the inspected page. JavaScript objects and DOM nodes are displayed in an expandable tree similar to the console/watch.</param>
        /// <param name="rootTitle">An optional title for the root of the expression tree.</param>
        public virtual ValueTask SetExpression(string expression, string rootTitle)
        {
            return InvokeVoidAsync("setExpression", expression, rootTitle);
        }

        /// <summary>Sets a JSON-compliant object to be displayed in the sidebar pane.</summary>
        /// <param name="jsonObject">An object to be displayed in context of the inspected page. Evaluated in the context of the caller (API client).</param>
        /// <param name="rootTitle">An optional title for the root of the expression tree.</param>
        public virtual ValueTask SetObject(string jsonObject, string rootTitle)
        {
            return InvokeVoidAsync("setObject", jsonObject, rootTitle);
        }

        /// <summary>Sets an HTML page to be displayed in the sidebar pane.</summary>
        /// <param name="path">Relative path of an extension page to display within the sidebar.</param>
        public virtual ValueTask SetPage(ExtensionUrl path)
        {
            return InvokeVoidAsync("setPage", path);
        }
    }
}
