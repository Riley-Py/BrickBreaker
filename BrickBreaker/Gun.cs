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
            lifeSpan = 500;
        }
        //when the bullets collide with the blocks, have them remove a life from the block
        //have the weapon disappear after a few seconds

        //gun class(gun type), bullet class(bullet type(scar,shot,rpg))
        //gun class makes gun, which makes the bullets 
        public void CreateGun()
        {
            //create a rectangle to display gun
            Rectangle gunRect = new Rectangle(GameScreen.paddle.x + GameScreen.paddle.width / 2 - width / 2, GameScreen.paddle.y - 4 * GameScreen.paddle.height, width, height);

            //Select the gun type
            switch (gunType)
            {
                case "Scar":
                    //assign its duration
                    //lifeSpan = 500;

                    //have it shoot bullets
                    break;

                case "Shotgun":
                    break;

                case "RocketLauncher":
                    break;
            }
        }

    }
}
