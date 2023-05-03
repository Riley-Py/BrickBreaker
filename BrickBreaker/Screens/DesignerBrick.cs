using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker.Screens
{
    internal class DesignerBrick
    {
        //public static int lastX = 0, lastY = 0;
        public int x, y;
        public int width, height;
        public Powerup powerup;
        public SolidBrush solidBrush;
        public int hp;
        public Image powerupImage;

        public DesignerBrick(int _x, int _y, int _hp, int _w, int _h, Powerup pu)
        {
            x = _x;
            y = _y;
            solidBrush = new SolidBrush(HPToColor(_hp));
            width = _w;
            height = _h;
            powerup = pu;
            powerupImage = PowerUpToImage(pu);
            hp = _hp;
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
        /// <summary>
        /// Converting powerups to images to be used for editing
        /// </summary>
        /// <param name="powerup"></param>
        /// <returns></returns>
        private Image PowerUpToImage(Powerup powerup)
        {
            Powerup power = powerup;
            
            switch (power)
            {
                case Powerup.Ammo:
                    return Properties.Resources.ammoBox;
                case Powerup.ChugJug:
                    return Properties.Resources.chugJugEdited;
                case Powerup.RocketLauncher:
                     return Properties.Resources.rocketLauncher;

            }
            return null;
            
            

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
