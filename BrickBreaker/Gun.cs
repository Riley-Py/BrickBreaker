using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BrickBreaker
{
    public class Gun
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

        public string gunType;
        public int x, y, width, height;
        public int lifeSpan;

        public Gun(string _gunType)
        {
            gunType = _gunType;
            width = 30;
            height = 60;
            x = GameScreen.paddle.x + GameScreen.paddle.width / 2 - width / 2;
            y = GameScreen.paddle.y - 4 * GameScreen.paddle.height;

            //Select the gun type
            switch (gunType)
            {
                case "Scar":
                    //assign its duration
                    lifeSpan = 240;
                    break;

                case "Shotgun":
                    //assign its duration
                    lifeSpan = 240;
                    break;

                case "RocketLauncher":
                    break;
            }
        }

        public void Shoot(string gunType)
        {
            switch (gunType)
            {
                case "Scar":
                    //have it shoot bullets
                    if (lifeSpan % 30 == 0)
                    {
                        Bullet bulletSc = new Bullet("Scar", x, width, y);
                        GameScreen.bullets.Add(bulletSc);
                    }
                    break;

                case "Shotgun":
                    //have it shoot bullets
                    if (lifeSpan >= 50 && lifeSpan < 55)
                    {
                        Bullet bulletSh = new Bullet("Shotgun", x, width, y);
                        GameScreen.bullets.Add(bulletSh);
                    }
                    break;

                case "RocketLauncher":
                    break;
            }
        }


        public void Move()
        {
            x = GameScreen.paddle.x + GameScreen.paddle.width / 2 - width / 2;
            y = GameScreen.paddle.y - 4 * GameScreen.paddle.height;
        }
    }
}
