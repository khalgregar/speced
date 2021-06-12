using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpecEd
{
    public partial class PaletteControl : UserControl
    {
        private static Size s_colSize = new Size(32, 32);
        private ColourAttribute m_attribute;

        public ColourAttribute Attribute
        {
            get { return m_attribute; }
            set { setColourAttribute(value); }
        }

        public event EventHandler AttributeChanged;

        public PaletteControl()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (m_attribute != null)
            {
                int col = m_attribute.IsBright ? 1 : 0;
                if (m_attribute.Ink == m_attribute.Paper)
                {
                    byte color = (byte)(7 - (int)m_attribute.Ink);
                    drawTextInSwatch(e.Graphics, m_attribute.Ink, col, "IP", SpectrumColours.coloursBright[color]);
                }
                else
                {
                    byte color = (byte)(7 - (int)m_attribute.Ink);
                    drawTextInSwatch(e.Graphics, m_attribute.Ink, col, "I", SpectrumColours.coloursBright[color]);

                    color = (byte)(7 - (int)m_attribute.Paper);
                    drawTextInSwatch(e.Graphics, m_attribute.Paper, col, "P", SpectrumColours.coloursBright[color]);
                }

                
            }

            
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            for (int i = 0; i < 8; ++i)
            {
                using (Brush brush = new SolidBrush(SpectrumColours.colours[i]))
                {
                    e.Graphics.FillRectangle(brush, new Rectangle( new Point(0,i*s_colSize.Height), s_colSize));
                }
            }

            for (int i = 0; i < 8; ++i)
            {
                using (Brush brush = new SolidBrush(SpectrumColours.coloursBright[i]))
                {
                    e.Graphics.FillRectangle(brush, new Rectangle(new Point(s_colSize.Width, i * s_colSize.Height), s_colSize));
                }
            }
        }

        private void setColourAttribute(ColourAttribute _attribute)
        {
            m_attribute = _attribute;
            Invalidate();
        }

        private void drawTextInSwatch(Graphics _g, int _row, int _col, String _text, Color _colour)
        {
            Font drawFont = new Font("Courier New", 16);
            SolidBrush drawBrush = new SolidBrush(_colour);
            float y = _row * s_colSize.Width + s_colSize.Width/2;
            float x = _col * s_colSize.Height + s_colSize.Height/2;
            StringFormat drawFormat = new StringFormat();
            drawFormat.LineAlignment = StringAlignment.Center;
            drawFormat.Alignment = StringAlignment.Center;
            _g.DrawString(_text, drawFont, drawBrush, x, y, drawFormat);
            drawFont.Dispose();
            drawBrush.Dispose();
        }

        protected override void OnClick(EventArgs e)
        {
            if (m_attribute != null)
            {
                var args = (MouseEventArgs)e;
                int row = args.Location.Y / s_colSize.Height;
                int col = args.Location.X / s_colSize.Width;
                
                if (row >= 0 && row < 8)
                {
                    if (args.Button.HasFlag(MouseButtons.Left))
                    {
                        m_attribute.Ink = (byte)row;
                        m_attribute.IsBright = col == 1;
                        OnAttributeChanged();
                    }
                    else if (args.Button.HasFlag(MouseButtons.Right))
                    {
                        m_attribute.Paper = (byte)row;
                        m_attribute.IsBright = col == 1;
                        OnAttributeChanged();
                    }
                }
                Invalidate();
            }
        }

        protected virtual void OnAttributeChanged()
        {
            AttributeChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
