using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker.Screens
{
    internal class DesignerBrick
    {
        public int x, y;
        public int width, height;
        public SolidBrush solidBrush;
        public DesignerBrick(int _x, int _y, Color _c)
        {
            x = _x;
            y = _y;
            solidBrush = new SolidBrush(_c);
            width = 35;
            height = 14;
        }
        public DesignerBrick(int _x, int _y, Color _c, int _w, int _h)
        {

        }

    }
}
