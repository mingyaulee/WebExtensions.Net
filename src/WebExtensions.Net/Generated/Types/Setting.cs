using JsBind.Net;
using System.Threading.Tasks;

namespace WebExtensions.Net.Types
{
    // Type Class
    /// <summary></summary>
    [BindAllProperties]
    public partial class Setting : BaseObject
    {
        /// <summary>Clears the setting, restoring any default value.</summary>
        /// <param name="details">Which setting to clear.</param>
        [JsAccessPath("clear")]
        public virtual ValueTask Clear(ClearDetails details)
        {
            return InvokeVoidAsync("clear", details);
        }

        /// <summary>Gets the value of a setting.</summary>
        /// <param name="details">Which setting to consider.</param>
        /// <returns>Details of the currently effective value.</returns>
        [JsAccessPath("get")]
        public virtual ValueTask<CallbackDetails> Get(GetDetails details)
        {
            return InvokeAsync<CallbackDetails>("get", details);
        }

        /// <summary>Sets the value of a setting.</summary>
        /// <param name="details">Which setting to change.</param>
        [JsAccessPath("set")]
        public virtual ValueTask Set(SetDetails details)
        {
            return InvokeVoidAsync("set", details);
        }
    }
}
