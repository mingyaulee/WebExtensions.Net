using System;
using System.Text.Json.Serialization;

namespace WebExtensions.Net
{
    /// <summary>
    /// A DotNet delegate reference to be invoked in JavaScript.
    /// </summary>
    internal class DotNetDelegateReference
    {
        /// <summary>
        /// Creates a new instance of the DotNetDelegateReference class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public DotNetDelegateReference(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Indicate that this object is a DotNet delegate reference.
        /// </summary>
        [JsonPropertyName("__isDelegateReference")]
        public bool IsDelegateReference { get; } = true;

        /// <summary>
        /// The identifier of this DotNet delegate reference.
        /// </summary>
        [JsonPropertyName("__id")]
        public Guid Id { get; }
    }
}
