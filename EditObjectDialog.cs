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
    public partial class EditObjectDialog : Form
    {
        private Tile m_tile;
        private bool m_isSettingTile;
        
        public Tile Tile
        {
            get => m_tile;
            set => OnSetTile(value);
        }

        public EditObjectDialog()
        {
            InitializeComponent();
            bind();
            Tile = new Tile(2, 2);
        }

        private void OnSetTile(Tile _tile)
        {
            m_tile = _tile;
            objectControl.Tile = m_tile;
            m_isSettingTile = true;
            udWidth.Value = m_tile.Width;
            udHeight.Value = m_tile.Height;
            m_isSettingTile = false;
            updateBlockType();
        }

        private void bind()
        {
            objectControl.ModeChanged += (sender, args) =>
            {
                if (objectControl.Mode == ObjectControl.ModeType.Pixel)
                {
                    paletteControl.Attribute = null;
                }
                else if (objectControl.Mode == ObjectControl.ModeType.Cell)
                {
                    paletteControl.Attribute = objectControl.getSelectedCell().colour;
                }
            };

            objectControl.SelectedCellChanged += (sender, args) =>
            {
                setSelectedCell(objectControl.getSelectedCell());
            };

            paletteControl.AttributeChanged += (sender, args) =>
            {
                objectControl.rebuildBitmap();
                objectControl.Invalidate();
            };

            setMode(ObjectControl.ModeType.Pixel);
        }

        private void btnGrid_Click(object sender, EventArgs e)
        {
            objectControl.ShowGrid = !objectControl.ShowGrid;
        }

        private void udWidth_ValueChanged(object sender, EventArgs e)
        {
            if (!m_isSettingTile)
            {
                objectControl.resizeTile((int)udWidth.Value, (int)udHeight.Value);
            }
        }

        private void udHeight_ValueChanged(object sender, EventArgs e)
        {
            if (!m_isSettingTile)
            {
                objectControl.resizeTile((int)udWidth.Value, (int)udHeight.Value);
            }
        }

        private void btnModeCell_Click(object sender, EventArgs e)
        {
            setMode(ObjectControl.ModeType.Cell);
        }

        private void btnModeDraw_Click(object sender, EventArgs e)
        {
            setMode(ObjectControl.ModeType.Pixel);
        }

        private void setMode(ObjectControl.ModeType _mode)
        {
            objectControl.Mode = _mode;
            btnModeDraw.Checked = objectControl.Mode == ObjectControl.ModeType.Pixel;
            btnModeCell.Checked = objectControl.Mode == ObjectControl.ModeType.Cell;

            updateBlockType();
        }

        private void setSelectedCell(CharacterCell _cell)
        {
            paletteControl.Attribute = _cell.colour;
            updateBlockType();
        }

        private void rbBlockType_CheckedChanged(object sender, EventArgs e)
        {
            var btn = (RadioButton)sender;
            if (btn.Checked)
            {
                BlockType blockType = (BlockType)btn.Tag;
                if (m_tile.BlockType != blockType)
                {
                    m_tile.BlockType = blockType;
                    if (blockType == BlockType.Switch)
                    {
                        m_tile.SwitchType = SwitchType.Toggle;
                    }
                    else
                    {
                        m_tile.SwitchType = SwitchType.None;
                    }
                    updateBlockType();
                }
            }
        }

        private void rbSwitchType_CheckedChanged(object sender, EventArgs e)
        {
            var btn = (RadioButton)sender;
            if (btn.Checked)
            {
                SwitchType switchType = (SwitchType)btn.Tag;
                if (m_tile.SwitchType != switchType)
                {
                    m_tile.SwitchType = switchType;
                    updateBlockType();
                }
            }
        }

        private void updateBlockType()
        {
            if (m_tile != null)
            {
                switch (m_tile.BlockType)
                {
                    default:
                    case BlockType.Empty:
                        rbEmpty.Checked = true;
                        break;
                    case BlockType.Platform:
                        rbPlatform.Checked = true;
                        break;
                    case BlockType.Wall:
                        rbWall.Checked = true;
                        break;
                    case BlockType.Deadly:
                        rbDeadly.Checked = true;
                        break;
                    case BlockType.Collectable:
                        rbCollectable.Checked = true;
                        break;
                    case BlockType.Info:
                        rbInfo.Checked = true;
                        break;
                    case BlockType.Switch:
                        rbSwitch.Checked = true;
                        break;
                    case BlockType.Goodie:
                        rbGoodie.Checked = true;
                        break;
                }

                switch (m_tile.SwitchType)
                {
                    case SwitchType.Toggle:
                        stToggle.Checked = true;
                        break;
                    case SwitchType.Single:
                        stSingle.Checked = true;
                        break;
                    case SwitchType.Pressure:
                        stPressure.Checked = true;
                        break;
                    default:
                        stToggle.Checked = false;
                        stSingle.Checked = false;
                        stPressure.Checked = false;
                        break;
                }

                gbSwitchType.Enabled = m_tile.BlockType == BlockType.Switch;
            }
        }
    }
}
