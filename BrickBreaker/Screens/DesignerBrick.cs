using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker.Screens
{
    public class DesignerBrick
    {
        //public static int lastX = 0, lastY = 0;
        public int x, y;
        public int width, height;
        public PowerupEnum powerup;
        public SolidBrush solidBrush;
        public int hp;
        public Image powerupImage;
        public int background;
      

        public DesignerBrick(int _x, int _y, int _hp, int _w, int _h, PowerupEnum pu, int _background)
        {
            x = _x;
            y = _y;
            solidBrush = new SolidBrush(HPToColor(_hp));
            width = _w;
            height = _h;
            powerup = pu;
            powerupImage = PowerUpToImage(pu);
            hp = _hp;
            background = _background;
       
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
        private Image PowerUpToImage(PowerupEnum powerup)
        {
            PowerupEnum power = powerup;
            
            //Add more powerups as needed (modify the enum list in level designer, however)
            switch (power)
            {
                case PowerupEnum.Ammo:
                    return Properties.Resources.ammoBox;
                case PowerupEnum.ChugJug:
                    return Properties.Resources.chugJugEdited;
                case PowerupEnum.RocketLauncher:
                     return Properties.Resources.rocketLauncher;
                case PowerupEnum.Scar:
                    return Properties.Resources.scar;
                case PowerupEnum.Shotgun:
                    return Properties.Resources.shotgun;
                case PowerupEnum.InfinityGauntlet:
                    return Properties.Resources.thanos;

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
