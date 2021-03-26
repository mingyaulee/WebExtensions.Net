namespace WebExtension.Net
{
    /// <summary>
    /// Invoke JavaScript options.
    /// </summary>
    public abstract class InvokeOption
    {
        /// <summary>
        /// The reference ID to be used as a key for the JavaScript object returned.
        /// </summary>
        public string ReturnObjectReferenceId { get; set; }
    }
}
