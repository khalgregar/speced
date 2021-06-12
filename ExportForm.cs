using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpecEd
{
    public partial class ExportForm : Form
    {
        public ExportForm()
        {
            InitializeComponent();
            loadSettings();
        }

        public static void doExport()
        {
            String filename = null;
            String template = null;

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\WinRegistry");
            if (key != null)
            {
                object keyVal = key.GetValue("ExportFile");
                if (keyVal != null)
                {
                    filename = keyVal.ToString();
                }

                keyVal = key.GetValue("ExportTemplate");
                if (keyVal != null)
                {
                    template = keyVal.ToString();
                }

                key.Close();
            }

            if (!String.IsNullOrWhiteSpace(filename) && !String.IsNullOrWhiteSpace(template))
            {
                var logFile = Path.Combine( Path.GetDirectoryName(filename), Path.GetFileNameWithoutExtension(filename)) + ".log.txt";

                Exporter exporter = new Exporter();
                using (var fileWriter = File.Create(logFile))
                {
                    using (var logWriter = new StreamWriter(fileWriter))
                    {
                        exporter.export128(GameData.get(), template, filename, logWriter);
                    }
                    
                }
                
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbFolder.Text))
            {
                MessageBox.Show(this, "Folder is invalid", "Export Error", MessageBoxButtons.OK);
                return;
            }

            if (String.IsNullOrWhiteSpace(tbTemplate.Text))
            {
                MessageBox.Show(this, "Template is invalid", "Export Error", MessageBoxButtons.OK);
                return;
            }

            saveSettings();

            doExport();
            
            Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog();
            dlg.Filter = "SNA files|*.sna";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tbFolder.Text = dlg.FileName;
            }
        }

        private void loadSettings()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\WinRegistry");
            if (key != null)
            {
                object keyVal = key.GetValue("ExportFile");
                if (keyVal != null)
                {
                    tbFolder.Text = keyVal.ToString();
                }

                keyVal = key.GetValue("ExportTemplate");
                if (keyVal != null)
                {
                    tbTemplate.Text = keyVal.ToString();
                }

                key.Close();
            }
        }

        private void saveSettings()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\WinRegistry");
            key.SetValue("ExportFile", tbFolder.Text);
            key.SetValue("ExportTemplate", tbTemplate.Text);
            key.Close();
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "SNA files |*.sna";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tbTemplate.Text = dlg.FileName;
            }
        }
    }
}
