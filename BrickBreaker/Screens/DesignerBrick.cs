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
        
        //public static int lastX = 0, lastY = 0;
        public int x, y;
        public int width, height;
        public SolidBrush solidBrush;
        public DesignerBrick(int _x, int _y, int _hp)
        {

            x = _x;
            y = _y;
            solidBrush = new SolidBrush(HPToColor(_hp));
            width = 35;
            height = 14;

        }
        public DesignerBrick(int _x, int _y, int _hp, int _w, int _h)
        {

        }


        private Color HPToColor(int hitPoints)
        {
            switch(hitPoints)
            {
                case 1:
                    return Color.Gray;
                    
                case 2:
                    return Color.Green;
                case 3:
                    return Color.Blue;
                case 4:
                    return Color.Purple;
                case 5:
                    return Color.Gold;

                default:
                    return Color.White;
            }
        }
    }
}
