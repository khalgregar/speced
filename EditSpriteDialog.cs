using System;
using System.Windows.Forms;

namespace SpecEd
{
    public partial class EditSpriteDialog : Form
    {
        private Sprite m_sprite;
        private int m_frame = 0;
        private byte[,] m_clipboard;
        private byte[,] m_maskClipboard;
        private bool m_editingMask = false;

        public int Frame
        {
            get => m_frame;
            set => setFrame(value);
        }
        

        public Sprite Sprite
        {
            get => m_sprite;
            set => setSprite(value);
        }

        public EditSpriteDialog()
        {
            InitializeComponent();
        }

        private void setSprite(Sprite _sprite)
        {
            m_sprite = _sprite;
            spriteControl.Sprite = m_sprite;
            setFrame(0);

            cbVertical.Checked = m_sprite.moveType == 1;
            cbDeadly.Checked = m_sprite.spriteType == SpriteType.Deadly;
            cbGenerateReverse.Checked = m_sprite.generateReverse;
            udMoveId.Value = m_sprite.moveId;
            
            updateControlsForMask();
        }

        private void setFrame(int _frame)
        {
            int frame = -1;
            if (m_sprite != null)
            {
                frame = _frame;
                if (frame < 0)
                {
                    frame = m_sprite.numFrames-1;
                }
                else if (frame >= m_sprite.numFrames)
                {
                    frame = 0;
                }
            }
            lblFrame.Text = "Frame: " + frame;
            m_frame = frame;

            spriteControl.Frame = m_frame;
        }

        private void btnDecFrame_Click(object sender, EventArgs e)
        {
            setFrame(m_frame - 1);
        }

        private void btnIncFrame_Click(object sender, EventArgs e)
        {
            setFrame(m_frame + 1);
        }

        private void btnCopyFrame_Click(object sender, EventArgs e)
        {
            if (m_sprite != null)
            {
                m_clipboard = new byte[m_sprite.tileWidth, m_sprite.tileHeight*8];
                for (int y = 0; y < m_sprite.tileHeight*8; ++y)
                {
                    for (int x = 0; x < m_sprite.tileWidth; ++x)
                    {
                        m_clipboard[x, y] = m_sprite.frames[Frame, x, y];
                    }
                }

                if (m_sprite.masks != null)
                {
                    m_maskClipboard = new byte[m_sprite.tileWidth, m_sprite.tileHeight * 8];
                    for (int y = 0; y < m_sprite.tileHeight * 8; ++y)
                    {
                        for (int x = 0; x < m_sprite.tileWidth; ++x)
                        {
                            m_maskClipboard[x, y] = m_sprite.masks[Frame, x, y];
                        }
                    }
                }
                else
                {
                    m_maskClipboard = null;
                }
            }
        }

        private void btnPasteFrame_Click(object sender, EventArgs e)
        {
            if (m_sprite != null && m_clipboard != null)
            {
                for (int y = 0; y < m_sprite.tileHeight*8; ++y)
                {
                    for (int x = 0; x < m_sprite.tileWidth; ++x)
                    {
                        m_sprite.frames[Frame, x, y] = m_clipboard[x, y];
                    }
                }

                if (m_sprite.masks != null && m_maskClipboard != null)
                {
                    for (int y = 0; y < m_sprite.tileHeight * 8; ++y)
                    {
                        for (int x = 0; x < m_sprite.tileWidth; ++x)
                        {
                            m_sprite.masks[Frame, x, y] = m_maskClipboard[x, y];
                        }
                    }
                }

                spriteControl.rebuildBitmap();
            }
        }

        private void btnShiftU_Click(object sender, EventArgs e)
        {
            if (m_sprite != null)
            {
                int numScanlines = m_sprite.tileHeight * 8;
                var pixels = new byte[m_sprite.tileWidth, numScanlines];
                for (int y = 0; y < numScanlines; ++y)
                {
                    int py = y - 1;
                    if (py < 0)
                    {
                        py = numScanlines - 1;
                    }

                    for (int x = 0; x < m_sprite.tileWidth; ++x)
                    {
                        pixels[x, py] = m_sprite.frames[Frame, x, y];   
                    }
                }

                for (int y = 0; y < numScanlines; ++y)
                {
                    for (int x = 0; x < m_sprite.tileWidth; ++x)
                    {
                        m_sprite.frames[Frame, x, y] = pixels[x, y];
                    }
                }
            }

            spriteControl.rebuildBitmap();
        }

        private void offsetPixels(int _ox, int _oy)
        {
            if (m_sprite != null)
            {
                int numScanlines = m_sprite.tileHeight * 8;
                var pixels = new byte[m_sprite.tileWidth, numScanlines];
                for (int y = 0; y < numScanlines; ++y)
                {
                    uint py = (uint)( y + _oy);
                    py %= (uint)numScanlines;
                    
                    for (int x = 0; x < m_sprite.tileWidth; ++x)
                    {
                        uint px = (uint)(x + _ox);
                        px %= (uint)numScanlines;

                        m_sprite.frames[Frame, x, y] = pixels[x, y];
                    }
                }
                
                for (int y = 0; y < numScanlines; ++y)
                {
                    for (int x = 0; x < m_sprite.tileWidth; ++x)
                    {
                        m_sprite.frames[Frame, x, y] = pixels[x, y];
                    }
                }
            }
        }

        private void btnShiftD_Click(object sender, EventArgs e)
        {
            if (m_sprite != null)
            {
                int numScanlines = m_sprite.tileHeight * 8;
                var pixels = new byte[m_sprite.tileWidth, numScanlines];
                for (int y = 0; y < numScanlines; ++y)
                {
                    int py = y + 1;
                    if (py >= numScanlines)
                    {
                        py = 0;
                    }

                    for (int x = 0; x < m_sprite.tileWidth; ++x)
                    {
                        pixels[x, py] = m_sprite.frames[Frame, x, y];
                    }
                }

                for (int y = 0; y < numScanlines; ++y)
                {
                    for (int x = 0; x < m_sprite.tileWidth; ++x)
                    {
                        m_sprite.frames[Frame, x, y] = pixels[x, y];
                    }
                }
            }

            spriteControl.rebuildBitmap();
        }

        private void btnShiftR_Click(object sender, EventArgs e)
        {
            if (m_sprite != null)
            {
                int numScanlines = m_sprite.tileHeight * 8;
                for (int y = 0; y < numScanlines; ++y)
                {
                    byte lastByte = m_sprite.frames[Frame, m_sprite.tileWidth - 1, y];
                    lastByte &= 1;
                    lastByte <<= 7;

                    for (int x = 0; x < m_sprite.tileWidth; ++x)
                    {
                        byte b = m_sprite.frames[Frame, x, y];
                        byte carryBit = (byte)(b & 1);
                        b >>= 1;
                        b |= lastByte;
                        m_sprite.frames[Frame, x, y] = b;
                        lastByte = (byte)(carryBit << 7);

                    }
                }

                spriteControl.rebuildBitmap();
            }
        }

        private void btnShiftL_Click(object sender, EventArgs e)
        {
            if (m_sprite != null)
            {
                int numScanlines = m_sprite.tileHeight * 8;
                for (int y = 0; y < numScanlines; ++y)
                {
                    byte lastByte = m_sprite.frames[Frame, 0, y];
                    lastByte &= 128;
                    lastByte >>= 7;

                    for (int x = m_sprite.tileWidth-1; x >= 0; --x)
                    {
                        byte b = m_sprite.frames[Frame, x, y];
                        byte carryBit = (byte)(b & 128);
                        b <<= 1;
                        b |= lastByte;
                        m_sprite.frames[Frame, x, y] = b;
                        lastByte = (byte)(carryBit >> 7);

                    }
                }

                spriteControl.rebuildBitmap();
            }
        }

        

        private void btnAddMask_Click(object sender, EventArgs e)
        {
            if (m_sprite == null || m_sprite.masks != null)
            {
                return;
            }

            Sprite.masks = new byte[Sprite.numFrames, Sprite.tileWidth, Sprite.tileHeight * 8];
            updateControlsForMask();
        }

        private void updateControlsForMask()
        {
            if (m_sprite.masks != null)
            {
                btnAddMask.Visible = false;
                cbShowMask.Visible = true;
            }
            else
            {
                btnAddMask.Visible = true;
                cbShowMask.Visible = false;
            }
        }

        private void cbShowMask_Click(object sender, EventArgs e)
        {
            bool editing = ((CheckBox)sender).Checked;
            spriteControl.ShowMask = editing;
            m_editingMask = editing;
        }

        private void cbGenerateReverse_CheckedChanged(object sender, EventArgs e)
        {
            m_sprite.generateReverse = ((CheckBox)sender).Checked;
        }

        private void cbVertical_CheckedChanged(object sender, EventArgs e)
        {
            m_sprite.moveType = ((CheckBox)sender).Checked ? 1: 0;
        }

        private void cbDeadly_CheckedChanged(object sender, EventArgs e)
        {
            m_sprite.spriteType = ((CheckBox)sender).Checked ? SpriteType.Deadly : SpriteType.Elevator;
        }

        private void udMoveId_ValueChanged(object sender, EventArgs e)
        {
            m_sprite.moveId = Convert.ToInt32(((NumericUpDown)sender).Value);
        }
    }
}
