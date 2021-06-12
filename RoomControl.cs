using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Collections.Generic;

namespace SpecEd
{
    public partial class RoomControl : UserControl
    {
        private Dictionary<uint, Bitmap> m_roomBitmaps = new Dictionary<uint, Bitmap>();
        private Point m_origin = new Point();
        private bool m_isDragging;
        private Point m_lastDrag;
        private ControlModeType m_controlMode = ControlModeType.Pan;
        private int m_scale = 2;
        private bool m_showGrid = true;
        private uint m_selectedRoomHash;
        private GameData m_gameData;

        public enum ControlModeType
        {
            Pan,
            Draw,
            Sprites,
            Room
        }

        public uint SelectedRoomHash { get => m_selectedRoomHash; }

        public bool ShowGrid
        {
            get => m_showGrid;
            set
            {
                m_showGrid = value;
                Invalidate();
            }
        }

        public int ViewScale
        {
            get { return m_scale; }
            set
            {
                if (m_scale >= 1 && m_scale <= 5)
                {
                    m_scale = value;
                    Invalidate();
                }
            }
        }

        public GameData GameData { get => m_gameData; set => setGameData(value); }
        public int CellBrush { get; set; }
        public int CellBrushAlternate { get; set; }

        public Point Origin { get { return m_origin; } }

        public int TileBrush { get; set; } = -1;

        public int SpriteBrush { get; set; } = -1;

        public ControlModeType ControlMode {
            get { return m_controlMode; }
            set
            {
                m_controlMode = value;
                Invalidate();
                OnControlModeChanged();
            }
        }

        public event EventHandler ControlModeChanged;

        public RoomControl()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void setGameData(GameData _gameData)
        {
            m_gameData = _gameData;

            foreach (var bmp in m_roomBitmaps.Values)
            {
                bmp.Dispose();
            }
            m_roomBitmaps.Clear();

            for (uint col = 0; col < GameData.NumRoomsY; ++col)
            {
                for (uint row = 0; row < GameData.NumRoomsX; ++row)
                {
                    uint hash = GameData.getRoomHash(row, col);
                    redrawRoomBitmap(hash);
                }
            }
        }

        public void rebuildRoomBitmaps()
        {
            foreach (var roomHash in m_gameData.m_rooms.Keys)
            {
                redrawRoomBitmap(roomHash);
            }

            Invalidate();
        }

        public void redrawRoomBitmap(uint _roomHash)
        {
            if (GameData != null)
            {
                Room room;
                if (!GameData.m_rooms.TryGetValue(_roomHash, out room))
                {
                    return;
                }

                Bitmap bmp;
                if (!m_roomBitmaps.TryGetValue(_roomHash, out bmp))
                {
                    bmp = new Bitmap(Room.Width * 8, Room.Height * 8);
                    m_roomBitmaps.Add(_roomHash, bmp);
                }

                using (var g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.Black);


                    using (var cellWriter = new BitmapCellWriter(bmp))
                    {
                        foreach (var instance in room.m_tileInstances)
                        {
                            Tile tile;
                            if (GameData.m_tiles.TryGetValue(instance.tileId, out tile))
                            {
                                for (int ry = 0; ry <= instance.repeatY; ++ry)
                                {
                                    for (int rx = 0; rx <= instance.repeatX; ++rx)
                                    {
                                        int offsetX = rx * tile.Width;
                                        int offsetY = ry * tile.Height;

                                        for (int cy = 0; cy < tile.Height; ++cy)
                                        {
                                            for (int cx = 0; cx < tile.Width; ++cx)
                                            {
                                                int ax = cx + instance.x + offsetX;
                                                int ay = cy + instance.y + offsetY;
                                                if (ax >= 0 && ax < Room.Width && ay >= 0 && ay < Room.Height)
                                                {
                                                    var cell = tile.getCell(cx, cy);
                                                    cellWriter.RenderCell(cell, ax, ay);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        foreach (var spriteInstance in room.m_spriteInstances.Values)
                        {
                            Sprite sprite = m_gameData.m_sprites[spriteInstance.spriteId];
                            cellWriter.RenderSprite(sprite, 0, spriteInstance.startX, spriteInstance.startY, spriteInstance.colour);
                        }
                    }

                    
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            if (ControlMode == ControlModeType.Room)
            {
                Point roomLoc = GameData.getRoomLocation(m_selectedRoomHash);

                int w = Room.Width * 8 * m_scale;
                int h = Room.Height * 8 * m_scale;
                int x = Origin.X + roomLoc.X * w;
                int y = Origin.Y + roomLoc.Y * h;

                using (var pen = new Pen(Color.FromArgb(255, 255, 0), 1f))
                {
                    e.Graphics.DrawRectangle(pen, x, y, w, h);
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.CompositingMode = CompositingMode.SourceCopy;
            e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;

            if (GameData != null)
            {
                var penGrid = new Pen(Color.FromArgb(60, 60, 60), 0.25f);
                var penRoomBounds = new Pen(Color.FromArgb(192, 192, 192), 0.25f);

                e.Graphics.Clear(Color.DarkSlateGray);

                for (uint row = 0; row < GameData.NumRoomsY; ++row)
                {
                    for (uint col = 0; col < GameData.NumRoomsX; ++col)
                    {
                        int w = Room.Width * 8 * m_scale;
                        int h = Room.Height * 8 * m_scale;
                        int x = Origin.X + (int)col * w;
                        int y = Origin.Y + (int)row * h;

                        uint roomHash = GameData.getRoomHash(col, row);
                        Bitmap bmp;
                        if (m_roomBitmaps.TryGetValue(roomHash, out bmp))
                        {
                            RectangleF destRect = new RectangleF(x, y, w, h);
                            RectangleF sourceRect = new RectangleF(0, 0, bmp.Width, bmp.Height);

                            // TODO - discard stuff out of bounds.

                            e.Graphics.DrawImage(bmp, destRect, sourceRect, GraphicsUnit.Pixel);

                            if (ShowGrid)
                            {
                                int cellW = 8 * m_scale;
                                for (int ly = y; ly <= y+h; ly += cellW)
                                {
                                    e.Graphics.DrawLine(penGrid, new Point(x, ly), new Point(x + w, ly));

                                }

                                for (int lx = x; lx <= x+w; lx += cellW)
                                {
                                    e.Graphics.DrawLine(penGrid, new Point(lx, y), new Point(lx, y + h));

                                }
                            }
                        }
                        if (ShowGrid)
                        {
                            e.Graphics.DrawRectangle(penRoomBounds, x, y, w, h);

                            Room room;
                            if (m_gameData.m_rooms.TryGetValue(roomHash, out room))
                            {
                                foreach (var spriteInstance in room.m_spriteInstances.Values)
                                {
                                    Sprite sprite = m_gameData.m_sprites[spriteInstance.spriteId];

                                    int cx, cy, cw, ch;
                                    if (sprite.moveType == 0)
                                    {
                                        // Horizontal
                                        cx = spriteInstance.startX - spriteInstance.deltaMin;
                                        cy = spriteInstance.startY;
                                        cw = spriteInstance.deltaMin + spriteInstance.deltaMax + sprite.tileWidth;
                                        ch = sprite.tileHeight;
                                    }
                                    else if (sprite.moveType == 1)
                                    {
                                        // Vertical
                                        cx = spriteInstance.startX;
                                        cy = spriteInstance.startY - spriteInstance.deltaMin;
                                        cw = sprite.tileWidth;
                                        ch = spriteInstance.deltaMin + spriteInstance.deltaMax + sprite.tileHeight;
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    Rectangle rect = new Rectangle(x + cx * 8 * m_scale, y + cy * 8 * m_scale, cw * 8 * m_scale, ch * 8 * m_scale);
                                    e.Graphics.DrawRectangle(Pens.Red, rect);
                                }
                            }
                        }
                    }
                }

                penGrid.Dispose();
                penRoomBounds.Dispose();
            }
        }

        protected override void OnClick(EventArgs e)
        {
            var args = (MouseEventArgs)e;
            if (ControlMode == ControlModeType.Room)
            {
                if (args.Button.HasFlag(MouseButtons.Left))
                {
                    int x = (args.Location.X - Origin.X) / (ViewScale * 8 * Room.Width);
                    int y = (args.Location.Y - Origin.Y) / (ViewScale * 8 * Room.Height);
                    m_selectedRoomHash = GameData.getRoomHash((uint)x, (uint)y);
                    OnSelectedRoomHashChanged();
                }
            }
            else if (ControlMode == ControlModeType.Sprites)
            {
                if (args.Button.HasFlag(MouseButtons.Left))
                {
                    OnDrawSprite(args.Location, false);
                }
                else if (args.Button.HasFlag(MouseButtons.Right))
                {
                    OnDrawSprite(args.Location, true);
                }
            }
            else if (ControlMode == ControlModeType.Draw)
            {
                OnDrawCell(args.Location, args.Button);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if ((ControlMode == ControlModeType.Pan && e.Button.HasFlag(MouseButtons.Left)) || e.Button.HasFlag(MouseButtons.Middle))
            {
                if (!m_isDragging)
                {
                    m_isDragging = true;
                    m_lastDrag = e.Location;
                    Cursor = Cursors.Hand;
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if ((ControlMode == ControlModeType.Pan && e.Button.HasFlag(MouseButtons.Left)) || e.Button.HasFlag(MouseButtons.Middle))
            {
                if (m_isDragging)
                {
                    m_origin.X += e.Location.X - m_lastDrag.X;
                    m_origin.Y += e.Location.Y - m_lastDrag.Y;
                    m_lastDrag = e.Location;
                    Invalidate();
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if ((ControlMode == ControlModeType.Pan && e.Button.HasFlag(MouseButtons.Left)) || e.Button.HasFlag(MouseButtons.Middle))
            {
                m_isDragging = false;
                Cursor = Cursors.Default;
            }
        }

        private void OnDrawSprite(Point _p, bool _erase)
        {
            // coords in cell space
            int x = (_p.X - Origin.X) / (ViewScale * 8);
            int y = (_p.Y - Origin.Y) / (ViewScale * 8);

            int roomx = x / Room.Width;
            int roomy = y / Room.Height;
            Room room = m_gameData.getRoom((uint)roomx, (uint)roomy, false);
            if (room != null)
            {
                uint roomHash = GameData.getRoomHash((uint)roomx, (uint)roomy);
                int cellx = x - roomx * Room.Width;
                int celly = y - roomy * Room.Height;
                if (cellx >= 0 && cellx < Room.Width && celly >= 0 && celly < Room.Height)
                {
                    if (!_erase)
                    {
                        SpriteInstance editInstance = null;
                        bool isExisting = false;
                        foreach (var pair in room.m_spriteInstances)
                        {
                            SpriteInstance instance = pair.Value;
                            Sprite sprite = m_gameData.m_sprites[instance.spriteId];

                            if (cellx >= instance.startX && cellx < instance.startX + sprite.tileWidth && celly >= instance.startY && celly < instance.startY + sprite.tileHeight)
                            {
                                editInstance = instance;
                                isExisting = true;
                                break;
                            }
                        }

                        if (editInstance == null && SpriteBrush >= 0)
                        {
                            editInstance = new SpriteInstance();
                            editInstance.spriteId = SpriteBrush;
                            editInstance.startX = cellx;
                            editInstance.startY = celly;
                            editInstance.colour = 6;
                        }

                        if (editInstance != null)
                        {
                            var dlg = new SpritePropertiesDialog();
                            dlg.SpriteInstance = editInstance;
                            if (dlg.ShowDialog(this) == DialogResult.OK)
                            {
                                editInstance = dlg.SpriteInstance;
                                if (!isExisting)
                                {
                                    m_gameData.addSpriteInstance(room, editInstance);
                                }
                                redrawRoomBitmap(roomHash);
                                Invalidate();
                            }
                        }
                    }
                    else
                    {
                        List<int> toRemove = new List<int>();
                        foreach (var pair in room.m_spriteInstances)
                        {
                            int instanceId = pair.Key;
                            SpriteInstance instance = pair.Value;
                            
                            if (instance.startX == cellx && instance.startY == celly)
                            {
                                toRemove.Add(instanceId);
                            }
                        }

                        foreach (var instanceId in toRemove)
                        {
                            room.m_spriteInstances.Remove(instanceId);
                        }

                        redrawRoomBitmap(roomHash);
                        Invalidate();
                    }
                }
            }
        }

        private void OnDrawCell(Point _p, MouseButtons _buttons)
        {
            // coords in cell space
            int x = (_p.X - Origin.X) / (ViewScale * 8);
            int y = (_p.Y - Origin.Y) / (ViewScale * 8);

            int roomx = x / Room.Width;
            int roomy = y / Room.Height;
            Room room = m_gameData.getRoom((uint)roomx, (uint)roomy, false);
            if (room != null)
            {
                uint roomHash = GameData.getRoomHash((uint)roomx, (uint)roomy);
                int cellx = x - roomx*Room.Width;
                int celly = y - roomy*Room.Height;
                if (cellx >= 0 && cellx < Room.Width && celly >= 0 && celly < Room.Height)
                {
                    if (_buttons.HasFlag(MouseButtons.Left))
                    {
                        var currentInstance = m_gameData.getTileInstanceInCell(room, cellx, celly);
                        if (currentInstance == null)
                        {
                            if (TileBrush >= 0)
                            {
                                var instance = new TileInstance();
                                instance.tileId = TileBrush;
                                instance.x = cellx;
                                instance.y = celly;
                                room.m_tileInstances.Add(instance);
                                redrawRoomBitmap(roomHash);
                                Invalidate();
                            }
                                    
                        }
                        else
                        {
                            OnTileInstanceClicked(currentInstance);
                        }
                        
                    }
                    else if (_buttons.HasFlag(MouseButtons.Right))
                    {
                        var currentInstance = m_gameData.getTileInstanceInCell(room, cellx, celly);
                        if (currentInstance != null)
                        {
                            room.m_tileInstances.Remove(currentInstance);
                            redrawRoomBitmap(roomHash);
                            Invalidate();

                        }
                    }
                }
            }
        }
        
        protected virtual void OnControlModeChanged()
        {
            ControlModeChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler SelectedRoomHashChanged;
        public event EventHandler<TileInstanceClickedArgs> TileInstanceClicked;

        public class TileInstanceClickedArgs : EventArgs
        {
            public TileInstance Instance { get; private set; }

            public TileInstanceClickedArgs(TileInstance _instance)
            {
                Instance = _instance;
            }
        }

        protected virtual void OnSelectedRoomHashChanged()
        {
            SelectedRoomHashChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnTileInstanceClicked(TileInstance _instance)
        {
            TileInstanceClicked?.Invoke(this, new TileInstanceClickedArgs(_instance));
        }
    }
}
