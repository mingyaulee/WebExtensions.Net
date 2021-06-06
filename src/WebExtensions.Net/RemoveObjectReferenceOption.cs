namespace WebExtensions.Net
{
    /// <summary>
    /// Remove JavaScript object reference options.
    /// </summary>
    public class RemoveObjectReferenceOption : InvokeOption
    {
        /// <summary>
        /// The identifier for the action 'RemoveObjectReference'.
        /// </summary>
        public const string Identifier = "WebExtensionsNet.RemoveObjectReference";

        internal RemoveObjectReferenceOption(string referenceId)
        {
            ReferenceId = referenceId;
        }

        /// <summary>
        /// Reference ID of the JavaScript object.
        /// </summary>
        public string ReferenceId { get; set; }
    }
}
