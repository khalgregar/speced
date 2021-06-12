using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecEd
{
    public static class SpectrumColours
    {
        public static readonly Color[] colours = new Color[]
            {
                Color.FromArgb(255, 0, 0, 0),
                Color.FromArgb(255, 0, 0, 215),
                Color.FromArgb(255, 215, 0, 0),
                Color.FromArgb(255, 215, 0, 215),
                Color.FromArgb(255, 0, 215, 0),
                Color.FromArgb(255, 0, 215, 215),
                Color.FromArgb(255, 215, 215, 0),
                Color.FromArgb(255, 215, 215, 215)
            };

        public static readonly Color[] coloursBright = new Color[]
        {
                Color.FromArgb(255, 0, 0, 0),
                Color.FromArgb(255, 0, 0, 255),
                Color.FromArgb(255, 255, 0, 0),
                Color.FromArgb(255, 255, 0, 255),
                Color.FromArgb(255, 0, 255, 0),
                Color.FromArgb(255, 0, 255, 255),
                Color.FromArgb(255, 255, 255, 0),
                Color.FromArgb(255, 255, 255, 255)
        };

        public static readonly int BLACK    = 0;
        public static readonly int BLUE     = 1;
        public static readonly int RED      = 2;
        public static readonly int MAGENTA  = 3;
        public static readonly int GREEN    = 4;
        public static readonly int CYAN     = 5;
        public static readonly int YELLOW   = 6;
        public static readonly int WHITE    = 7;
    }
}
