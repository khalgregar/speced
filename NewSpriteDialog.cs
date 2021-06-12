using System;
using System.Windows.Forms;

namespace SpecEd
{
    public partial class NewSpriteDialog : Form
    {
        public int TileWidth
        {
            get { return Convert.ToInt32(udTileWidth.Value); }
        }

        public int TileHeight
        {
            get { return Convert.ToInt32(udTileHeight.Value); }
        }

        public int NumFrames
        {
            get { return Convert.ToInt32(udNumFrames.Value); }
        }

        public int MovementType
        {
            get { return cbMovement.SelectedIndex; }
        }

        public SpriteType SpriteType
        {
            get => (SpriteType)cbSpriteType.SelectedIndex;
        }

        public NewSpriteDialog()
        {
            InitializeComponent();
            cbMovement.SelectedIndex = 0;
        }
    }
}
