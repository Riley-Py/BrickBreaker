using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BrickBreaker
{
    public enum PowerupEnum
    {
        None = 0,

        Ammo = 1,
        ChugJug = 2,
        Scar = 3,
        Shotgun = 4,
        RocketLauncher = 5,
        InfinityGauntlet = 6,

        Default = 7
    }
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
        public int x, y, size, ySpeed = 4;
        public int appearance; 

        public Powerup(string _powerName, int _xLocation, int _yLocation, int _size, int _appearance)
        {
            powerName = _powerName;
            x = _xLocation;
            y = _yLocation;
            size = _size;
            appearance = _appearance;
        }

        public void Move()
        {
            y += ySpeed;
        }

        public bool PaddleCollision(Paddle p)
        {
            Rectangle powerRec = new Rectangle(x, y, size, size);
            Rectangle paddleRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (powerRec.IntersectsWith(paddleRec))
            {
                return true;
            }
            return false;
        }

        public void GivePowerup()
        {
            switch (powerName)
            {
                //add ball
                case "Ammo":
                    Ball ball = new Ball(GameScreen.paddle.x + GameScreen.paddle.width/2, GameScreen.paddle.y - GameScreen.paddle.height, 3, 3, 20);
                    GameScreen.ballList.Add(ball); 
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
                    //store which of the three guns are in use
                    Gun gunSc = new Gun("Scar");
                    GameScreen.guns.Add(gunSc);
                    break;

                //temporary shotgun that fires in a spread upwards
                case "Shotgun":
                    //store which of the three guns are in use
                    Gun gunSh = new Gun("Shotgun");
                    GameScreen.guns.Add(gunSh);
                    break;

                //rocket launcher that fires straight upwards once, AOE attack
                case "RocketLauncher":
                    //store which of the three guns are in use
                    Gun gunRL = new Gun("RocketLauncher");
                    GameScreen.guns.Add(gunRL);
                    break;

                //reduce half of the lives of each block
                case "InfinityGauntlet":
                    //for each block, divide it's lives by two (round up on odd numbers)
                    for (int i = 0; i < GameScreen.bricks.Count; i++) 
                    {
                        if (GameScreen.bricks[i].hp == 1)
                        {
                            GameScreen.bricks[i].hp--;
                        }

                        GameScreen.bricks[i].hp /= 2;
                    }
                    //to make up for the rounding, any block with one life will be destroyed
                    break;
            }
        }
    }
}
