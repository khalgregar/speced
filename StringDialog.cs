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
    public partial class StringDialog : Form
    {
        public StringDialog()
        {
            InitializeComponent();
        }

        public String Value
        {
            get => tbValue.Text;
            set => tbValue.Text = value;
        }
    }
}
