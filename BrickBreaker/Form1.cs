using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Start the program centred on the Menu Screen
            MenuScreen ms = new MenuScreen();
            this.Controls.Add(ms);

            ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);
        }

        public static void createPowerup(string powerName)
        {
            #region Overall Notes
            /* Code written by Isaha Flinch.
             * This code exists to create powerups for player to use.  The powerups
             * are stored with the data of a block and are generated upon that block's 
             * distruction.  The powerup will fall towards the player slowly.  If 
             * collected, the powerup will be given.  Otherwise the powerup will be 
             * removed without use.
             */
            #endregion

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
                    #region notes
                    //check the lives count
                    //if the default is 3 lives than we can add another until it reaches 4 lives
                    //otherwise do nothing
                    #endregion
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
                case "InfinityGauntlet ":
                    #region notes
                    //for each block, divide it's lives by two (round up on odd numbers)
                    //to make up for the rounding, any block with one life will be destroyed
                    #endregion
                    break;
            }       
        }
    }
}
