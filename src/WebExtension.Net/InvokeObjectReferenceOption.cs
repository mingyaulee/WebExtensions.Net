namespace WebExtension.Net
{
    /// <summary>
    /// Invoke JavaScript object options.
    /// </summary>
    public class InvokeObjectReferenceOption : InvokeOption
    {
        internal InvokeObjectReferenceOption(string referenceId) : this(referenceId, null) { }

        internal InvokeObjectReferenceOption(string referenceId, string targetPath) : this(referenceId, targetPath, false) { }

        internal InvokeObjectReferenceOption(string referenceId, string targetPath, bool isFunction)
        {
            ReferenceId = referenceId;
            TargetPath = targetPath;
            IsFunction = isFunction;
        }

        /// <summary>
        /// Reference ID of the JavaScript object.
        /// </summary>
        public string ReferenceId { get; set; }

        /// <summary>
        /// The target path of the JavaScript object.
        /// </summary>
        public string TargetPath { get; set; }

        /// <summary>
        /// The indicator if the target is a function.
        /// </summary>
        public bool IsFunction { get; set; }
    }
}
