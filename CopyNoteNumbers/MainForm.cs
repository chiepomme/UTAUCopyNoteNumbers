using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CopyNoteNumbers
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        void OnCopyButtonClicked(object sender, EventArgs e)
        {
            var ustPath = Environment.GetCommandLineArgs()[1];
            new USTFileCopier().Copy(ustPath, USTFileCopier.DefaultCopyPath);
            Close();
        }

        void OnAuthorLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://chiepom.me/");
        }

        void OnPasteButtonClicked(object sender, EventArgs e)
        {
            var ustPath = Environment.GetCommandLineArgs()[1];
            int offsetTick;

            if (int.TryParse(Offset.Text, out offsetTick))
                new USTFilePaster().Paste(USTFileCopier.DefaultCopyPath, ustPath, offsetTick);
            else
                new USTFilePaster().Paste(USTFileCopier.DefaultCopyPath, ustPath);
            Close();
        }
    }
}
