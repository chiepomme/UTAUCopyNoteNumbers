using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace CopyNoteNumbers
{
    public class USTFileCopier
    {
        public const string DefaultCopyPath = @"copy.ust";

        public void Copy(string fromPath, string toPath = DefaultCopyPath)
        {
            File.Copy(fromPath, toPath, true);
        }
    }
}
