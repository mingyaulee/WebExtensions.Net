using System.Collections.Generic;

namespace WebExtensions.Net.Generator.CodeGeneration
{
    public class CodeSection
    {
        public CodeSection()
        {
            Lines = new List<string>();
        }

        public IList<string> Lines { get; }
        public int Indentation { get; set; }
    }
}
