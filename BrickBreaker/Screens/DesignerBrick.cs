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
        Powerup powerup;
        public SolidBrush solidBrush;

        public DesignerBrick(int _x, int _y, int _hp, int _w, int _h, Powerup pu)
        {
            x = _x;
            y = _y;
            solidBrush = new SolidBrush(HPToColor(_hp));
            width = _w;
            height = _h;
            powerup = pu;
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

        public bool containsPoint(int pX,  int pY)
        {
            pX += this.width / 2;
            pY += this.height / 2;
            if(pX > this.x && pX < this.x + this.width && pY > this.y && pY < this.y + this.height)
            {
                return true;
            }
            return false;
        }
        public bool containsBrick(DesignerBrick b)
        {
            Rectangle r = new Rectangle(b.x, b.y, b.width, b.height);
            Rectangle r2 = new Rectangle(x, y, width, height);
            if(r.IntersectsWith(r2))
            {
                return true;
            }
            return false;
        }
    }
}
