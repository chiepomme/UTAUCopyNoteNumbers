using System.IO;
using System.Windows.Forms;

namespace CopyNoteNumbers
{
    public class USTFileCopier
    {
        public static string DefaultCopyPath
        {
            get { return Path.Combine(Application.UserAppDataPath, "copy.ust"); }
        }

        public void Copy(string fromPath, string toPath)
        {
            File.Copy(fromPath, toPath, true);
        }
    }
}
