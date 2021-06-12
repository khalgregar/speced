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
    class SpritePalette : ListBox
    {
        private Dictionary<int, Bitmap> m_bitmaps = new Dictionary<int, Bitmap>();
        private GameData m_gameData;

        public GameData GameData
        {
            get => m_gameData;
            set => setGameData(value);
        }

        public int SelectedSprite
        {
            get
            {
                if (SelectedItem == null)
                {
                    return -1;
                }
                return ((SpritePaletteItem)SelectedItem).SpriteId;
            }
        }

        private class SpritePaletteItem
        {
            public int SpriteId { get; private set; }
            public Sprite Sprite { get; private set; }
            public Bitmap Bitmap { get; private set; }
            public bool IsPlayer { get; set; }

            public SpritePaletteItem(int _spriteId, Sprite _sprite)
            {
                SpriteId = _spriteId;
                Sprite = _sprite;
                buildBitmap();
            }

            public void buildBitmap()
            {
                Bitmap bmp = new Bitmap(Sprite.tileWidth * 8, Sprite.tileHeight*8, PixelFormat.Format32bppPArgb);
                using (var bmpWriter = new BitmapCellWriter(bmp))
                {
                    bmpWriter.RenderSprite(Sprite, 0, 0, 0);
                }

                if (Bitmap != null)
                {
                    Bitmap.Dispose();
                }
                Bitmap = bmp;
            }
        }

        public SpritePalette()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.ItemHeight = 120;
            MultiColumn = true;
            ColumnWidth = 120;
            BackColor = Color.DarkSlateGray;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0 && e.Index < Items.Count)
            {
                var item = (SpritePaletteItem)Items[e.Index];

                Graphics g = e.Graphics;
                g.CompositingMode = CompositingMode.SourceCopy;
                g.CompositingQuality = CompositingQuality.HighSpeed;
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = PixelOffsetMode.Half;

                int cx = e.Bounds.X + e.Bounds.Width / 2;
                int cy = e.Bounds.Y + e.Bounds.Height / 2;
                int bw = (item.Bitmap.Width / 2) * 6;
                int bh = (item.Bitmap.Height / 2) * 6;

                Rectangle rDst = new Rectangle(new Point(cx - bw / 2, cy - bh / 2), new Size(bw, bh));
                g.DrawImage(item.Bitmap, rDst);

                if (item.IsPlayer)
                {
                    g.DrawRectangle(Pens.Red, rDst);
                }
            }
            e.DrawFocusRectangle();
        }

        private void setGameData(GameData _gameData)
        {
            foreach (var bmp in m_bitmaps.Values)
            {
                bmp.Dispose();
            }

            m_bitmaps.Clear();

            m_gameData = _gameData;
            if (m_gameData == null)
            {
                return;
            }

            foreach (var pair in m_gameData.m_sprites)
            {
                onSpriteAdded(pair.Key, pair.Value);
            }


            m_gameData.SpriteAdded += (sender, args) => onSpriteAdded(args.SpriteId, args.Sprite);
            m_gameData.PlayerSpriteChanged += (sender, args) => onPlayerSpriteChanged();
        }

        private void onSpriteAdded(int _spriteId, Sprite _sprite)
        {
            var item = new SpritePaletteItem(_spriteId, _sprite);
            item.IsPlayer = (item.SpriteId == m_gameData.m_playerSprite);
            Items.Add(item);
        }

        public void onSpriteDeleted(int _spriteId)
        {
            var toRemove = new List<SpritePaletteItem>();
            foreach (SpritePaletteItem item in Items)
            {
                if (item.SpriteId == _spriteId)
                {
                    toRemove.Add(item);
                }
            }
            foreach (var item in toRemove)
            {
                Items.Remove(item);
            }

        }

        private void onPlayerSpriteChanged()
        {
            foreach (var item in Items)
            {
                var spriteItem = (SpritePaletteItem)item;
                spriteItem.IsPlayer = (spriteItem.SpriteId == m_gameData.m_playerSprite);
            }

            Invalidate();
        }

        public void refreshSprites()
        {
            foreach (SpritePaletteItem item in Items)
            {
                item.buildBitmap();
            }
            Invalidate();
        }
    }
}
