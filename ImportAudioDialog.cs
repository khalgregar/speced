using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpecEd
{
    public partial class ImportAudioDialog : Form
    {
        public ImportAudioDialog()
        {
            InitializeComponent();
        }

        public string Title
        {
            get => tbTitle.Text;
            set => tbTitle.Text = value;
        }

        public string Filename
        {
            get => tbFilename.Text;
            set => tbFilename.Text = value;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "Audio Files|*.txt";
            dlg.Title = "Select File For Import";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tbFilename.Text = dlg.FileName;
            }
        }
    }
}
