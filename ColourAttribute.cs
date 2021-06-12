using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecEd
{
    public class ColourAttribute
    {
        public static byte BLACK    = 0;
        public static byte BLUE     = 1;
        public static byte RED      = 2;
        public static byte MAGENTA  = 3;
        public static byte GREEN    = 4;
        public static byte CYAN     = 5;
        public static byte YELLOW   = 6;
        public static byte WHITE    = 7;

        public byte Ink { get; set; }
    
        public byte Paper { get; set; }
        
        public bool IsBright { get; set; }

        public byte asByte()
        {
            return (byte)(Ink & 0x7 | ((Paper & 0x7 ) << 3) | (IsBright ? 0x40 : 0));
        }

        public ColourAttribute()
        {
            Ink = WHITE;
            Paper = BLACK;
            IsBright = false;
        }

        public ColourAttribute deepCopy()
        {
            ColourAttribute attr = new ColourAttribute();
            attr.Ink = Ink;
            attr.Paper = Paper;
            attr.IsBright = IsBright;
            return attr;
        }
    }
}
