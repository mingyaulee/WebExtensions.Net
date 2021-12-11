using System.Threading.Tasks;

namespace WebExtensions.Net.Runtime
{
    public partial class Port
    {
        /// <summary>Post a message to the port.</summary>
        /// <param name="message">JSON-serializable message.</param>
        public virtual ValueTask PostMessage(object message)
        {
            return InvokeVoidAsync("postMessage", message);
        }
    }
}
