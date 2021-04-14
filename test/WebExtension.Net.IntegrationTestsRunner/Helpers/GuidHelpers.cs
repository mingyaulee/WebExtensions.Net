using System;
using System.Security.Cryptography;
using System.Text;

namespace WebExtension.Net.IntegrationTestsRunner.Helpers
{
    /// <summary>
    /// Helper methods for working with <see cref="Guid"/>.
    /// </summary>
    public static class GuidHelpers
    {
        /// <summary>
        /// The namespace for ISO OIDs (from RFC 4122, Appendix C).
        /// </summary>
        private static readonly Guid IsoOidNamespace = new Guid("6ba7b812-9dad-11d1-80b4-00c04fd430c8");

        /// <summary>
        /// Creates a name-based UUID using the algorithm from RFC 4122 §4.3.
        /// </summary>
        /// <param name="name">The name (within that namespace).</param>
        /// <returns>A UUID derived from the namespace and name.</returns>
        public static Guid Create(string name)
        {
            // convert the name to a sequence of octets (as defined by the standard or conventions of its namespace) (step 3)
            byte[] nameBytes = Encoding.UTF8.GetBytes(name);

            // convert the namespace UUID to network order (step 3)
            byte[] namespaceBytes = IsoOidNamespace.ToByteArray();
            SwapByteOrder(namespaceBytes);

            // compute the hash of the name space ID concatenated with the name (step 4)
            using var algorithm = SHA1.Create();
            algorithm.TransformBlock(namespaceBytes, 0, namespaceBytes.Length, null, 0);
            algorithm.TransformFinalBlock(nameBytes, 0, nameBytes.Length);
            var hash = algorithm.Hash;

            // most bytes from the hash are copied straight to the bytes of the new GUID (steps 5-7, 9, 11-12)
            byte[] newGuid = new byte[16];
            Array.Copy(hash, 0, newGuid, 0, 16);

            // set the four most significant bits (bits 12 through 15) of the time_hi_and_version field to the appropriate 4-bit version number from Section 4.1.3 (step 8)
            newGuid[6] = (byte)((newGuid[6] & 0x0F) | (5 << 4));

            // set the two most significant bits (bits 6 and 7) of the clock_seq_hi_and_reserved to zero and one, respectively (step 10)
            newGuid[8] = (byte)((newGuid[8] & 0x3F) | 0x80);

            // convert the resulting UUID to local byte order (step 13)
            SwapByteOrder(newGuid);
            return new Guid(newGuid);
        }

        // Converts a GUID (expressed as a byte array) to/from network order (MSB-first).
        private static void SwapByteOrder(byte[] guid)
        {
            SwapBytes(guid, 0, 3);
            SwapBytes(guid, 1, 2);
            SwapBytes(guid, 4, 5);
            SwapBytes(guid, 6, 7);
        }

        private static void SwapBytes(byte[] guid, int left, int right)
        {
            byte temp = guid[left];
            guid[left] = guid[right];
            guid[right] = temp;
        }
    }
}
