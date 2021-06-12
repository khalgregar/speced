using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpecEd
{
    class ObjectPalette : ListBox
    {
        private Dictionary<int, Bitmap> m_bitmaps = new Dictionary<int, Bitmap>();
        private GameData m_gameData;

        public GameData GameData
        {
            get => m_gameData;
            set => setGameData(value);
        }

        public int SelectedTile
        {
            get
            {
                if (SelectedItem == null)
                {
                    return -1;
                }
                return ((ObjectPaletteItem)SelectedItem).TileId;
            }
        }

        private class ObjectPaletteItem
        {
            public int TileId { get; private set; }
            public Tile Tile { get; private set; }
            public Bitmap Bitmap { get; private set; }

            public ObjectPaletteItem(int _tileId, Tile _tile)
            {
                TileId = _tileId;
                Tile = _tile;
                buildBitmap();
            }

            public void buildBitmap()
            {
                if (Bitmap != null)
                {
                    Bitmap.Dispose();
                }

                Bitmap bmp = new Bitmap(Tile.Width * 8, Tile.Height * 8, PixelFormat.Format32bppPArgb);
                using (var bmpWriter = new BitmapCellWriter(bmp))
                {
                    for (int y = 0; y < Tile.Height; ++y)
                    {
                        for (int x = 0; x < Tile.Width; ++x)
                        {
                            var cell = Tile.getCell(x, y);
                            bmpWriter.RenderCell(cell, x, y);
                        }
                    }
                }

                Bitmap = bmp;
            }
        }

        public ObjectPalette()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.ItemHeight = 120;
            MultiColumn = true;
            ColumnWidth = 120;
        }

        public void redrawItems()
        {
            foreach (var i in Items)
            {
                var item = (ObjectPaletteItem)i;
                item.buildBitmap();
            }
            RefreshItems();
        }

        public void rebuildItems()
        {
            setGameData(m_gameData);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0 && e.Index < Items.Count)
            {
                var item = (ObjectPaletteItem)Items[e.Index];

                Graphics g = e.Graphics;
                g.CompositingMode = CompositingMode.SourceCopy;
                g.CompositingQuality = CompositingQuality.HighSpeed;
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = PixelOffsetMode.Half;

                int cx = e.Bounds.X + e.Bounds.Width / 2;
                int cy = e.Bounds.Y + e.Bounds.Height / 2;
                int bw = (item.Bitmap.Width / 2) * 6;
                int bh = (item.Bitmap.Height / 2) * 6;

                Rectangle rDst = new Rectangle(new Point(cx-bw/2, cy-bh/2), new Size(bw, bh));
                g.DrawImage(item.Bitmap, rDst);
            }
            e.DrawFocusRectangle();
        }

        private void setGameData(GameData _gameData)
        {
            Items.Clear();

            if (m_gameData != null)
            {
                m_gameData.TileAdded -= onTileAdded;
            }

            m_gameData = _gameData;
            if (m_gameData == null)
            {
                return;
            }
            
            foreach (var tilePair in m_gameData.m_tiles)
            {
                onTileAdded(null, new GameData.TileEventArgs(tilePair.Key, tilePair.Value));
            }

            
            m_gameData.TileAdded += onTileAdded;
        }

        private void onTileAdded(object _sender, GameData.TileEventArgs _args)
        {
            Items.Add(new ObjectPaletteItem(_args.TileId, _args.Tile));
        }
    }
}
