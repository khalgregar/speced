using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace SpecEd
{
    public partial class SpriteControl : UserControl
    {
        private Bitmap m_bitmap;
        private Bitmap m_maskBitmap;
        private Sprite m_sprite;
        private int m_frame;
        private Point m_origin;
        private bool m_showGrid = true;
        private bool m_showMask = false;
        private bool m_isDragging;
        private Point m_lastDrag;
           

        public Sprite Sprite { get => m_sprite; set => setSprite(value); }
        public int Frame { get => m_frame; set => setFrame(value); }
        public Point Origin { get => m_origin; }
        public int ViewScale { get; set; } = 16;
        public Bitmap Bitmap { get => m_bitmap; }
        public Bitmap MaskBitmap { get => m_maskBitmap; }
        public bool ShowMask
        {
            get => m_showMask;
            set
            {
                m_showMask = value;
                Invalidate();
            }
        }
        

        public SpriteControl()
        {
            InitializeComponent();
        }

        public void setSprite(Sprite _sprite)
        {
            m_sprite = _sprite;
            rebuildBitmap();
            Invalidate();
        }

        public void rebuildBitmap()
        {
            if (m_bitmap != null)
            {
                m_bitmap.Dispose();
                m_bitmap = null;
            }

            if (m_maskBitmap != null)
            {
                m_maskBitmap.Dispose();
                m_maskBitmap = null;
            }

            if (m_sprite != null)
            {
                m_bitmap = new Bitmap(m_sprite.tileWidth * 8, m_sprite.tileHeight*8, PixelFormat.Format32bppPArgb);
                using (var bmpWriter = new BitmapCellWriter(m_bitmap))
                {
                    bmpWriter.RenderSprite(m_sprite, Frame, 0, 0);
                }

                if (m_sprite.masks != null)
                {
                    m_maskBitmap = new Bitmap(m_sprite.tileWidth * 8, m_sprite.tileHeight * 8, PixelFormat.Format32bppPArgb);
                    using (var bmpWriter = new BitmapCellWriter(m_maskBitmap))
                    {
                        bmpWriter.RenderSpriteMask(m_sprite, Frame, 0, 0);
                    }
                }
            }

            Invalidate();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.DarkSlateGray);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.CompositingMode = CompositingMode.SourceCopy;
            e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;

            

            if (m_bitmap != null)
            {
                int w = m_bitmap.Width * ViewScale;
                int h = m_bitmap.Height * ViewScale;
                int x = Origin.X;
                int y = Origin.Y;

                RectangleF destRect = new RectangleF(x, y, w, h);
                RectangleF sourceRect = new RectangleF(0, 0, m_bitmap.Width, m_bitmap.Height);

                e.Graphics.DrawImage(m_bitmap, destRect, sourceRect, GraphicsUnit.Pixel);
                if (m_showMask)
                {
                    e.Graphics.CompositingMode = CompositingMode.SourceOver;
                    e.Graphics.DrawImage(m_maskBitmap, destRect, sourceRect, GraphicsUnit.Pixel);
                    e.Graphics.CompositingMode = CompositingMode.SourceCopy;
                }
                
                if (m_showGrid)
                {
                    var penD = new Pen(Color.FromArgb(60, 60, 60), 0.25f);
                    var penL = new Pen(Color.FromArgb(120, 120, 120), 0.25f);

                    for (int ly = 0; ly <= m_sprite.tileHeight * 8; ++ly)
                    {
                        var pen = (ly % 8 == 0) ? penL : penD;
                        int lineY = y + ly * ViewScale;
                        e.Graphics.DrawLine(pen, new Point(x, lineY), new Point(x + w, lineY));
                    }

                    for (int lx = 0; lx <= m_sprite.tileWidth * 8; ++lx)
                    {
                        var pen = (lx % 8 == 0) ? penL : penD;
                        int lineX = x + lx * ViewScale;
                        e.Graphics.DrawLine(pen, new Point(lineX, y), new Point(lineX, y + h));

                    }

                    penD.Dispose();
                    penL.Dispose();
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                drawPixel(e.Location, true);
            }
            else if (e.Button.HasFlag(MouseButtons.Right))
            {
                drawPixel(e.Location, false);
            }
            else if (e.Button.HasFlag(MouseButtons.Middle))
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
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                drawPixel(e.Location, true);
            }
            else if (e.Button.HasFlag(MouseButtons.Right))
            {
                drawPixel(e.Location, false);
            }
            else if (e.Button.HasFlag(MouseButtons.Middle))
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
            if (e.Button.HasFlag(MouseButtons.Middle))
            {
                m_isDragging = false;
                Cursor = Cursors.Default;
            }
        }

        private void drawPixel(Point _screenPos, bool _set)
        {
            if (m_sprite == null)
            {
                return;
            }

            int sx = _screenPos.X - Origin.X;
            int sy = _screenPos.Y - Origin.Y;
            float x = sx / (float)ViewScale;
            float y = sy / (float)ViewScale;
            int cx = (int)(x / 8);
            int cy = (int)(y / 8);

            byte[,,] frames = m_showMask ? m_sprite.masks : m_sprite.frames;

            if (cx >= 0 && cx < m_sprite.tileWidth && y >= 0 && cy < m_sprite.tileHeight)
            {
                int pixelX = (int)x % 8;

                byte b = frames[Frame, cx, (int)y];
                byte mask = (byte)(1 << (7 - pixelX));
                if (_set)
                {
                    b |= mask;
                }
                else
                {
                    b &= (byte)~mask;
                }
                frames[Frame, cx, (int)y] = b;
                rebuildBitmap();
            }

        }

        private void setFrame(int _frame)
        {
            m_frame = _frame;
            rebuildBitmap();
        }
    }
}
