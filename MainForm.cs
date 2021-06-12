using Microsoft.Win32;
using Newtonsoft.Json;
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
    public partial class MainForm : Form
    {
        private GameData m_gameData;
        private string m_filename;
        private Room m_selectedRoom;

        public Room SelectedRoom
        {
            get => m_selectedRoom;
        }
        
        public string Filename
        {
            get { return m_filename; }
            set
            {
                m_filename = value;
                saveSettings();
            }
        }

        public MainForm()
        {
            InitializeComponent();

            roomControl.ControlModeChanged += (sender, args) =>
            {
                btnPanRooms.Checked = roomControl.ControlMode == RoomControl.ControlModeType.Pan;
                btnRoomDraw.Checked = roomControl.ControlMode == RoomControl.ControlModeType.Draw;
                btnRoomSelect.Checked = roomControl.ControlMode == RoomControl.ControlModeType.Room;
                btnModeSprites.Checked = roomControl.ControlMode == RoomControl.ControlModeType.Sprites;
                
                if (roomControl.ControlMode == RoomControl.ControlModeType.Draw)
                {
                    tabControlTools.SelectTab(0);
                }
                else if (roomControl.ControlMode == RoomControl.ControlModeType.Sprites)
                {
                    tabControlTools.SelectTab(1);
                }
                else if (roomControl.ControlMode == RoomControl.ControlModeType.Room)
                {
                    tabControlTools.SelectTab(2);
                }
            };

            roomControl.ControlMode = RoomControl.ControlModeType.Draw;

            roomControl.SelectedRoomHashChanged += RoomControl_SelectedRoomHashChanged;
            roomControl.TileInstanceClicked += OnTileInstanceClicked;

            loadSettings();
            if (!String.IsNullOrWhiteSpace(Filename))
            {
                openFile();
            }
        }

        private void OnTileInstanceClicked(object sender, RoomControl.TileInstanceClickedArgs e)
        {
            var dlg = new TileInstancePropertiesDialog
            {
                CellX = e.Instance.x,
                CellY = e.Instance.y,
                RepeatX = e.Instance.repeatX,
                RepeatY = e.Instance.repeatY,
                ObjectName = e.Instance.name
            };

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                e.Instance.x = dlg.CellX;
                e.Instance.y = dlg.CellY;
                e.Instance.repeatX = dlg.RepeatX;
                e.Instance.repeatY = dlg.RepeatY;
                e.Instance.name = dlg.ObjectName;

                roomControl.rebuildRoomBitmaps();
                roomControl.Invalidate();
            }
        }

        private void RoomControl_SelectedRoomHashChanged(object sender, EventArgs e)
        {
            Point roomPos = GameData.getRoomLocation(roomControl.SelectedRoomHash);
            var room = m_gameData.getRoom((uint)roomPos.X, (uint)roomPos.Y, true);
            setSelectedRoom(room, roomPos.X, roomPos.Y);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_gameData != null)
            {
                if (String.IsNullOrWhiteSpace(Filename))
                {
                    doSaveAs();
                }
                else
                {
                    doSave();
                }
            }
        }

        private void doSaveAs()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text File|*.txt";
            dlg.Title = "Save Game Data";
            dlg.ShowDialog();

            Filename = dlg.FileName;
            if (!String.IsNullOrWhiteSpace(Filename))
            {
                doSave();
            }
        }

        private void doSave()
        {
            m_gameData.save(Filename);
        }

        private void setGameData( GameData _gameData )
        {
            m_gameData = _gameData;
            roomControl.GameData = m_gameData;
            stringTableView.DataSource = m_gameData.m_strings;
            

            //roomControl.Room = m_gameData.m_rooms[0];
            objectPalette.GameData = m_gameData;
            spritePalette.GameData = m_gameData;

            refreshStaticsList();
            refreshAudioList();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filename = null;
            setGameData(new GameData());
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text File|*.txt";
            dlg.Title = "Save Game Data";
            dlg.ShowDialog();

            Filename = dlg.FileName;
            if (!String.IsNullOrWhiteSpace(Filename))
            {
                openFile();
            }
        }

        private void openFile()
        {
            string inFile = File.ReadAllText(Filename);
            GameData gameData = JsonConvert.DeserializeObject<GameData>(inFile);
            setGameData(gameData);
        }

        private void loadSettings()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\WinRegistry");
            if (key != null)
            {
                Filename = key.GetValue("LastFile").ToString();
                key.Close();
            }
        }

        private void saveSettings()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\WinRegistry");
            key.SetValue("LastFile", Filename ?? String.Empty);
            key.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_gameData != null && !String.IsNullOrWhiteSpace(Filename))
            {
                doSave();
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var exportForm = new ExportForm();
            exportForm.ShowDialog(this);
        }

        private void btnPanRooms_Click(object sender, EventArgs e)
        {
            roomControl.ControlMode = RoomControl.ControlModeType.Pan;
        }

        private void btnModeSprites_Click(object sender, EventArgs e)
        {
            roomControl.ControlMode = RoomControl.ControlModeType.Sprites;
        }

        private void btnRoomSelect_Click(object sender, EventArgs e)
        {
            roomControl.ControlMode = RoomControl.ControlModeType.Room;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            roomControl.ControlMode = RoomControl.ControlModeType.Draw;
            btnPanRooms.Checked = false;
            btnRoomSelect.Checked = false;
        }

        private void menuItem_RoomScale1_Click(object sender, EventArgs e)
        {
            roomControl.ViewScale = 1;
        }

        private void menuItem_RoomScale2_Click(object sender, EventArgs e)
        {
            roomControl.ViewScale = 2;
        }

        private void menuItem_RoomScale3_Click(object sender, EventArgs e)
        {
            roomControl.ViewScale = 3;
        }

        private void menuItem_RoomScale4_Click(object sender, EventArgs e)
        {
            roomControl.ViewScale = 4;
        }

        private void menuItem_RoomScale5_Click(object sender, EventArgs e)
        {
            roomControl.ViewScale = 5;
        }

        private void btnNewObject_Click(object sender, EventArgs e)
        {
            EditObjectDialog dlg = new EditObjectDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                m_gameData.addTile(dlg.Tile);
            }
        }

        private void btnEditObject_Click(object sender, EventArgs e)
        {
            int tileId = objectPalette.SelectedTile;
            if (tileId < 0)
            {
                return;
            }

            Tile tile = m_gameData.m_tiles[tileId].deepCopy();

            EditObjectDialog dlg = new EditObjectDialog();
            dlg.Tile = tile;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                m_gameData.m_tiles[tileId].deepCopy(tile);
                roomControl.rebuildRoomBitmaps();
                objectPalette.redrawItems();
            }
        }

        private void objectPalette_SelectedIndexChanged(object sender, EventArgs e)
        {
            roomControl.TileBrush = objectPalette.SelectedTile;
        }

        private void btnRoomGrid_Click(object sender, EventArgs e)
        {
            roomControl.ShowGrid = btnRoomGrid.Checked;
        }

        private void btnRoomCreate_Click(object sender, EventArgs e)
        {
            Point roomPos = GameData.getRoomLocation(roomControl.SelectedRoomHash);
            var room = m_gameData.getRoom((uint)roomPos.X, (uint)roomPos.Y, true);
            setSelectedRoom(room, roomPos.X, roomPos.Y);
        }

        private void btnNewSprite_Click(object sender, EventArgs e)
        {
            var dlg = new NewSpriteDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                m_gameData.addSprite(dlg.TileWidth, dlg.TileHeight, dlg.NumFrames, dlg.MovementType, dlg.SpriteType);
            }
        }

        private void btnEditSprite_Click(object sender, EventArgs e)
        {
            if (spritePalette.SelectedSprite != -1)
            {
                var dlg = new EditSpriteDialog();
                dlg.Sprite = m_gameData.m_sprites[spritePalette.SelectedSprite];
                dlg.ShowDialog(this);
                spritePalette.refreshSprites();
            }
        }

        private void btnSetAsPlayer_Click(object sender, EventArgs e)
        {
            if (spritePalette.SelectedSprite != -1)
            {
                m_gameData.setPlayerSprite(spritePalette.SelectedSprite);
            }
        }

        private void spritePalette_SelectedIndexChanged(object sender, EventArgs e)
        {
            roomControl.SpriteBrush = spritePalette.SelectedSprite;
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (objectPalette.SelectedTile != -1)
            {
                if (MessageBox.Show("Are you sure you want to delete this tile?", "Delete Tile", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    m_gameData.deleteTile(objectPalette.SelectedTile);
                    roomControl.rebuildRoomBitmaps();
                    objectPalette.rebuildItems();
                }
            }
        }

        private void btnDeleteSprite_Click(object sender, EventArgs e)
        {
            int spriteId = spritePalette.SelectedSprite;
            if (spriteId != -1)
            {
                if (m_gameData.m_playerSprite == spriteId)
                {
                    MessageBox.Show("Sprite is set as player sprite.", "Cannot Delete Sprite", MessageBoxButtons.OK);
                }
                else if (MessageBox.Show("Are you sure you want to delete this sprite?", "Delete Sprite", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    m_gameData.deleteSprite(spriteId);
                    roomControl.rebuildRoomBitmaps();
                    spritePalette.onSpriteDeleted(spriteId);
                }
            }
        }

        private void btnSetTitle_Click(object sender, EventArgs e)
        {
            Room room = SelectedRoom;
            if (room != null)
            {
                room.m_title = tbRoomTitle.Text;
                room.m_infoID = tbRoomInfoID.Text;
            }
        }

        private void setSelectedRoom(Room _room, int _x, int _y)
        {
            m_selectedRoom = _room;
            if (m_selectedRoom == null)
            {
                tbRoomX.Text = String.Empty;
                tbRoomY.Text = String.Empty;
                tbRoomTitle.Text = String.Empty;
                tbRoomTitle.Enabled = false;
                tbRoomInfoID.Enabled = false;
            }
            else
            {
                tbRoomX.Text = _x.ToString();
                tbRoomY.Text = _y.ToString();
                tbRoomTitle.Enabled = true;
                tbRoomTitle.Text = m_selectedRoom.m_title;
                tbRoomInfoID.Text = m_selectedRoom.m_infoID;
            }

            roomControl.redrawRoomBitmap(roomControl.SelectedRoomHash);
            roomControl.Invalidate();
        }

        private void btnNewStatic_Click(object sender, EventArgs e)
        {
            var dlg = new EditObjectDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var staticGraphic = new StaticGraphic();
                staticGraphic.m_tile = dlg.Tile;
                m_gameData.addStatic(staticGraphic);
                refreshStaticsList();
            }
        }

        private void refreshStaticsList()
        {
            lbStatics.Items.Clear();
            if (m_gameData != null)
            {
                foreach (var staticGraphic in m_gameData.m_statics)
                {
                    lbStatics.Items.Add(staticGraphic);
                }
            }
        }

        private void btnRenameStatic_Click(object sender, EventArgs e)
        {
            var staticGraphic = lbStatics.SelectedItem as StaticGraphic;
            if (staticGraphic != null)
            {
                var dlg = new StringDialog();
                dlg.Text = "Rename Static";
                dlg.Value = staticGraphic.m_name;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    staticGraphic.m_name = dlg.Value;
                    refreshStaticsList();
                }
            }
        }

        private void btnEditStatic_Click(object sender, EventArgs e)
        {
            var staticGraphic = lbStatics.SelectedItem as StaticGraphic;
            if (staticGraphic != null)
            {
                var dlg = new EditObjectDialog();
                dlg.Tile = staticGraphic.m_tile.deepCopy();
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    staticGraphic.m_tile = dlg.Tile;
                }
            }
        }

        private void btnDeleteStatic_Click(object sender, EventArgs e)
        {
            var staticGraphic = lbStatics.SelectedItem as StaticGraphic;
            if (staticGraphic != null)
            {
                m_gameData.deleteStatic(staticGraphic);
                refreshStaticsList();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportForm.doExport();
        }

        private void btnAudioImport_Click(object sender, EventArgs e)
        {
            var dlg = new ImportAudioDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                AudioItem audioItem = new AudioItem();
                audioItem.Title = dlg.Title;
                audioItem.Contents = File.ReadAllText(dlg.Filename);
                m_gameData.m_audioItems.Add(audioItem);
                refreshAudioList();
            }
        }

        private void btnAudioDelete_Click(object sender, EventArgs e)
        {
            int selIdx = lbAudio.SelectedIndex;
            if (selIdx != -1)
            {
                m_gameData.m_audioItems.RemoveAt(selIdx);
                refreshAudioList();
            }
        }

        private void refreshAudioList()
        {
            lbAudio.Items.Clear();
            if (m_gameData != null)
            {
                foreach (var audioItem in m_gameData.m_audioItems)
                {
                    lbAudio.Items.Add(audioItem);
                }
            }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            m_gameData.m_strings.Add(new StringTableItem());
        }
    }
}
