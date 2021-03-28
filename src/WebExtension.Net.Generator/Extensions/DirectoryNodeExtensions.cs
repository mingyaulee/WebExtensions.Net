using System;
using System.IO;
using WebExtension.Net.Generator.Models;

namespace WebExtension.Net.Generator.Extensions
{
    public static class DirectoryNodeExtensions
    {
        public static string GetFilePath(this IDirectoryNode directoryNode, string path)
        {
            if (directoryNode.Directory == null)
            {
                throw new InvalidOperationException("Directory cannot be null");
            }
            return Path.Combine(directoryNode.Directory, path);
        }
    }
}
