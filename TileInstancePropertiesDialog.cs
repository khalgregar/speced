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
    public partial class TileInstancePropertiesDialog : Form
    {
        public TileInstancePropertiesDialog()
        {
            InitializeComponent();
        }

        public int CellX
        {
            get => Convert.ToInt32(udX.Value);
            set => udX.Value = value;
        }

        public int CellY
        {
            get => Convert.ToInt32(udY.Value);
            set => udY.Value = value;
        }

        public int RepeatX
        {
            get => Convert.ToInt32(udRX.Value);
            set => udRX.Value = value;
        }

        public int RepeatY
        {
            get => Convert.ToInt32(udRY.Value);
            set => udRY.Value = value;
        }

        public string ObjectName
        {
            get => tbName.Text;
            set => tbName.Text = value;
        }
    }
}
