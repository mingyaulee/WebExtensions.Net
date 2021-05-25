using System;

namespace WebExtension.Net
{
    /// <summary>
    /// Invoke JavaScript function reference options.
    /// </summary>
    public class InvokeFunctionReferenceOption : InvokeOption
    {
        /// <summary>
        /// The identifier for the action 'InvokeFunctionFromDotNet'.
        /// </summary>
        public const string Identifier = "WebExtensionNet.InvokeFunctionFromDotNet";

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
