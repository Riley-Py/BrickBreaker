using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        Random randGen = new Random();
        int xSpread;

        public Bullet(string _bulletType, int _x, int _gWidth, int _y)
        {
            bulletType = _bulletType;
            x = _x + _gWidth/2 - size/2;
            y = _y;

            xSpread = randGen.Next(-5, 6);
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
                    break;
            }

        }
    }
}
