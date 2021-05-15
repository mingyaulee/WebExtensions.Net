using System;

namespace WebExtension.Net
{
    /// <summary>
    /// Invoke JavaScript function reference options.
    /// </summary>
    public class InvokeFunctionReferenceOption : InvokeOption
    {
        internal InvokeFunctionReferenceOption(Guid referenceId)
        {
            ReferenceId = referenceId;
        }

        /// <summary>
        /// Reference ID of the JavaScript function.
        /// </summary>
        public Guid ReferenceId { get; set; }
    }
}
