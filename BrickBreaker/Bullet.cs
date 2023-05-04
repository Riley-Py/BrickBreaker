using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BrickBreaker
{
    public class Bullet
    {
        #region Overall Notes
        /* Code written by Isaha Flinch.
         * This code exists to create powerups for player to use.  The powerups
         * are stored with the data of a block and are generated upon that block's 
         * destruction.  The powerup will fall towards the player slowly.  If 
         * collected, the powerup will be given.  Otherwise the powerup will be 
         * removed without use.
         */
        #endregion

        public string bulletType;
        public int x, y, size = 10;
        public int damageVal = 1;

        Random randGen = new Random();
        int xSpread;

        public Bullet(string _bulletType, int _x, int _gWidth, int _y)
        {
            //assign bullet type and spread
            bulletType = _bulletType;
            xSpread = randGen.Next(-5, 6);

            //have the rocket launcher deal more damage and be larger
            if (bulletType == "RocketLauncher")
            {
                damageVal = 5;
                size = 80;
            }

            //find the location of the bullet
            x = _x + _gWidth / 2 - size / 2;
            y = _y;
        }

        public void Move()
        {
            switch (bulletType)
            {
                case "Scar":
                    y -= 10;
                    break;

                case "Shotgun":
                    x += xSpread;
                    y -= 10;
                    break;

                case "RocketLauncher":
                    y -= 10;
                    break;
            }
        }

        public bool Collision(Block b)
        {
            Rectangle bulletRec = new Rectangle(x, y, size, size);
            Rectangle blockRec = new Rectangle(b.x, b.y, b.width, b.height);

            if (bulletRec.IntersectsWith(blockRec))
            {
                return true;
            }
            return false;
        }

    }
}
