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
    public partial class ObjectControl : UserControl
    {
        private Bitmap m_bitmap;
        private Tile m_tile;
        private bool m_isDragging;
        private Point m_lastDrag;
        private Point m_origin;
        private bool m_showGrid = true;
        private ModeType m_mode = ModeType.Pixel;
        private Point m_selectedCell = new Point(0,0);
        private int m_viewScale = 32;

        public event EventHandler ModeChanged;
        public event EventHandler SelectedCellChanged;

        public enum ModeType
        {
            Pixel,
            Cell
        }

        public ModeType Mode
        {
            get => m_mode;
            set
            {
                m_mode = value;
                OnModeChanged();
            }
        }

        public bool ShowGrid
        {
            get => m_showGrid;
            set
            {
                m_showGrid = value;
                Invalidate();
            }
        }

        public Tile Tile { get => m_tile; set => setTile(value); }
        public Point Origin { get => m_origin; }
        public int ViewScale
        {
            get => m_viewScale;
            set
            {
                m_viewScale = Math.Min( Math.Max(value, 4), 64);

            }
        }

        public ObjectControl()
        {
            InitializeComponent();
            m_origin = new Point(20, 20);
        }

        private void setTile(Tile _tile)
        {
            m_tile = _tile;
            rebuildBitmap();
            Invalidate();
        }

        public CharacterCell getSelectedCell()
        {
            return m_tile?.getCell(m_selectedCell.X, m_selectedCell.Y);
        }

        public void resizeTile(int _width, int _height)
        {
            if (m_tile == null)
            {
                return;
            }

            var cells = new CharacterCell[_width * _height];

            for (int y = 0; y < _height; ++y)
            {
                for (int x = 0; x < _width; ++x)
                {
                    CharacterCell cell = null;
                    if (m_tile != null)
                    {
                        cell = m_tile.getCell(x, y);
                    }

                    if (cell == null)
                    {
                        cell = new CharacterCell();
                    }
                    cells[y * _width + x] = cell;
                }
            }

            m_tile.Width = _width;
            m_tile.Height = _height;
            m_tile.Cells = cells;

            rebuildBitmap();
            Invalidate();
        }

        public void rebuildBitmap()
        {
            if (m_tile == null)
            {
                if (m_bitmap != null)
                {
                    m_bitmap.Dispose();
                }
                m_bitmap = null;
            }
            else
            {
                m_bitmap = new Bitmap(m_tile.Width * 8, m_tile.Height * 8, PixelFormat.Format32bppPArgb);
                using (var bmpWriter = new BitmapCellWriter(m_bitmap))
                {
                    for (int y = 0; y < m_tile.Height; ++y)
                    {
                        for (int x = 0; x < m_tile.Width; ++x)
                        {
                            CharacterCell cell = m_tile.getCell(x, y);
                            bmpWriter.RenderCell(cell, x, y);
                        }
                    }
                }
            }
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

                if (m_showGrid)
                {
                    var penD = new Pen(Color.FromArgb(60, 60, 60), 0.25f);
                    var penL = new Pen(Color.FromArgb(120, 120, 120), 0.25f);

                    for (int ly = 0; ly <= m_tile.Height * 8; ++ly)
                    {
                        var pen = (ly % 8 == 0) ? penL : penD;
                        int lineY = y + ly * ViewScale;
                        e.Graphics.DrawLine(pen, new Point(x, lineY), new Point(x + w, lineY));

                    }

                    for (int lx = 0; lx <= m_tile.Width * 8; ++lx)
                    {
                        var pen = (lx % 8 == 0) ? penL : penD;
                        int lineX = x + lx * ViewScale;
                        e.Graphics.DrawLine(pen, new Point(lineX, y), new Point(lineX, y + h));

                    }

                    penD.Dispose();
                    penL.Dispose();
                }

                if (Mode == ModeType.Cell)
                {
                    using (var pen = new Pen(Color.FromArgb(255, 255, 255), 2f))
                    {
                        int cx = Origin.X + m_selectedCell.X * 8 * ViewScale;
                        int cy = Origin.Y + m_selectedCell.Y * 8 * ViewScale;
                        int cs = 8 * ViewScale;

                        Point[] pts =
                        {
                            new Point(cx,cy),
                            new Point(cx+cs,cy),
                            new Point(cx+cs,cy+cs),
                            new Point(cx,cy+cs),
                            new Point(cx,cy)
                        };

                        e.Graphics.DrawLines(pen, pts);
                        
                    }
                }
            }
        }

        protected override void OnClick(EventArgs e)
        {
            var args = (MouseEventArgs)e;
            if (Mode == ModeType.Cell)
            {
                int sx = args.Location.X - Origin.X;
                int sy = args.Location.Y - Origin.Y;
                float x = sx / (float)ViewScale;
                float y = sy / (float)ViewScale;
                int cx = (int)(x / 8);
                int cy = (int)(y / 8);

                if (cx >= 0 && cx < m_tile.Width && cy >= 0 && cy < m_tile.Height)
                {
                    if (args.Button.HasFlag(MouseButtons.Left))
                    {
                        m_selectedCell.X = cx;
                        m_selectedCell.Y = cy;
                        Invalidate();
                        OnSelectedCellChanged();
                    }
                    else if (args.Button.HasFlag(MouseButtons.Right))
                    {
                        CharacterCell cSrc = m_tile.getCell(m_selectedCell.X, m_selectedCell.Y);
                        CharacterCell cDst = m_tile.getCell(cx, cy);
                        cDst.colour.Ink = cSrc.colour.Ink;
                        cDst.colour.Paper = cSrc.colour.Paper;
                        cDst.colour.IsBright = cSrc.colour.IsBright;
                        rebuildBitmap();
                        Invalidate();
                    }
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (Mode == ModeType.Pixel)
            {
                if (e.Button.HasFlag(MouseButtons.Left))
                {
                    drawPixel(e.Location, true);
                }
                else if (e.Button.HasFlag(MouseButtons.Right))
                {
                    drawPixel(e.Location, false);
                }
            }
            

            if (e.Button.HasFlag(MouseButtons.Middle))
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
            if (Mode == ModeType.Pixel)
            {
                if (e.Button.HasFlag(MouseButtons.Left))
                {
                    drawPixel(e.Location, true);
                }
                else if (e.Button.HasFlag(MouseButtons.Right))
                {
                    drawPixel(e.Location, false);
                }
            }

            if (e.Button.HasFlag(MouseButtons.Middle))
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

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            int delta = e.Delta / 120;
            ViewScale += delta;
            rebuildBitmap();
            Invalidate();
        }

        private void drawPixel(Point _screenPos, bool _set)
        {
            if (m_tile == null)
            {
                return;
            }

            int sx = _screenPos.X - Origin.X;
            int sy = _screenPos.Y - Origin.Y;
            if (sx < 0 || sy < 0)
            {
                return;
            }
            float x = sx / (float)ViewScale;
            float y = sy / (float)ViewScale;
            int cx = (int)(x / 8);
            int cy = (int)(y / 8);

            if (cx >= 0 && cx < m_tile.Width && cy >= 0 && cy < m_tile.Height)
            {
                CharacterCell cell = m_tile.getCell(cx, cy);
                int pixelX = (int)x % 8;
                int pixelY = (int)y % 8;

                byte row = cell.rows[pixelY];
                byte mask = (byte)(1 << (7 - pixelX));
                if (_set)
                {
                    row |= mask;
                }
                else
                {
                    row &= (byte)~mask;
                }
                cell.rows[pixelY] = row;
                rebuildBitmap();
                Invalidate();
            }
            
        }

        protected virtual void OnModeChanged()
        {
            rebuildBitmap();
            Invalidate();
            ModeChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnSelectedCellChanged()
        {
            SelectedCellChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
