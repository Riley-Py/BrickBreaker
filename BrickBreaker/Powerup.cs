using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BrickBreaker
{
    public class Powerup
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

        public string powerName;
        public int x, y, ySpeed = 4, size = 20;

        public Powerup(string _powerName) //, int _xLocation, int _yLocation
        {
            powerName = _powerName;
            //x = _xLocation;
            //y = _yLocation;
        }

        public void Move()
        {
            y = y + ySpeed;
        }

        public void PaddleCollision(Paddle p)
        {
            Rectangle powerRec = new Rectangle(x, y, size, size);
            Rectangle paddleRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (powerRec.IntersectsWith(paddleRec))
            {
                GivePowerup();
            }
        }

        public void GivePowerup()
        {
            ////TO FIX ERRORS, I NEED lives AND blocks TO BE A PUBLIC STATIC
            switch (powerName)
            {
                //add ball
                case "Ammo":
                    #region notes
                    //add a ball to the game
                    //store the ball within a list
                    //only take a life from the player if the balls in that list = 0
                    #endregion
                    break;

                //add extra life, to a maximum of one extra life
                case "ChugJug":
                    //check the lives count, if the default is 3 lives than we can add another until it reaches 4 lives
                    if (GameScreen.lives < 4)
                    {
                        GameScreen.lives++;
                    }
                    //otherwise do nothing
                    break;

                //temporary machine gun that fires straight upwards
                case "Scar":
                    #region notes
                    //create a gun class that stores which of the three guns are in use
                    //have that gun class launch projectiles upwards
                    //have code within the game that calls a move method for the gun bullets (so have a class for each type of bullet)
                    //when the bullets collide with the blocks, have them remove a life from the block
                    //have the weapon disappear after a few seconds

                    //gun class(gun type), bullet class(bullet type(scar,shot,rpg))
                    //gun class makes gun, which makes the bullets 
                    #endregion
                    break;

                //temporary shotgun that fires straight upwards
                case "Shotgun":
                    break;

                //rocket launcher that fires straight upwards once, AOE attack
                case "RocketLauncher":
                    break;

                //reduce half of the lives of each block
                case "InfinityGauntlet":
                    //for each block, divide it's lives by two (round up on odd numbers)
                    for (int i = 0; i < GameScreen.blocks.Count; i++) 
                    {
                        if (GameScreen.blocks[i].hp == 1)
                        {
                            GameScreen.blocks[i].hp--;
                        }

                        GameScreen.blocks[i].hp /= 2;
                    }
                    //to make up for the rounding, any block with one life will be destroyed
                    break;
            }
        }
    }
}
