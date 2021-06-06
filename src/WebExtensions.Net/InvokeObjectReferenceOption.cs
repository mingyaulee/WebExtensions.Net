namespace WebExtension.Net
{
    /// <summary>
    /// Invoke JavaScript object reference options.
    /// </summary>
    public class InvokeObjectReferenceOption : InvokeOption
    {
        /// <summary>
        /// The identifier for the action 'InvokeOnObjectReference'.
        /// </summary>
        public const string Identifier = "WebExtensionNet.InvokeOnObjectReference";

        internal InvokeObjectReferenceOption(string referenceId, string targetPath, bool isFunction)
        {
            ReferenceId = referenceId;
            TargetPath = targetPath;
            IsFunction = isFunction;
        }

        /// <summary>
        /// The identifier of the JavaScript object.
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
