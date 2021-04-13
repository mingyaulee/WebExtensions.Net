using System.Threading.Tasks;

namespace WebExtension.Net.ContentScripts
{
    // Type Class
    /// <summary>An object that represents a content script registered programmatically</summary>
    public class RegisteredContentScript : BaseObject
    {
        /// <summary>Unregister a content script registered programmatically</summary>
        public virtual ValueTask Unregister()
        {
            return InvokeVoidAsync("unregister");
        }
    }
}
