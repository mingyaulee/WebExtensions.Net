namespace WebExtension.Net
{
    /// <summary>
    /// Remove JavaScript object reference options.
    /// </summary>
    public class RemoveObjectReferenceOption : InvokeOption
    {
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
