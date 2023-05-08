/*  Created by: 
 *  Project: Brick Breaker
 *  Date: 
 */ 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace BrickBreaker
{

    public partial class GameScreen : UserControl
    {
        #region global values

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, rightArrowDown;

        // Game values
        public static int lives;

        // Paddle and Ball objects
        public static Paddle paddle;
        Ball ball;

        // list of all blocks for current level
        public static List<Block> blocks = new List<Block>();
        public static List<Ball> ballList = new List<Ball>();
        public static List<Powerup> powers = new List<Powerup>();
        public static List<Gun> guns = new List<Gun>();
        public static List<Bullet> bullets = new List<Bullet>();

        // Brushes
        SolidBrush paddleBrush = new SolidBrush(Color.White);
        SolidBrush ballBrush = new SolidBrush(Color.White);
        SolidBrush blockBrush = new SolidBrush(Color.Red);

        // Powerup variables
        int appearance;
        public static int powerSize = 20;

        Image[] images = new Image[] {Properties.Resources.ammoBox, Properties.Resources.chugJugEdited, Properties.Resources.scar, Properties.Resources.shotgun, Properties.Resources.thanos};
        
        
        #endregion
        List<Ball> ballList = new List<Ball>();
        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }

        public void Brayden()
        {

        }

        

        public void OnStart()
        {
            // reset powerup code
            onStartPowerup();

            //set life counter
            lives = 3;

            //set all button presses to false.
            leftArrowDown = rightArrowDown = false;

            // setup starting paddle values and create paddle object
            int paddleWidth = 80;
            int paddleHeight = 20;
            int paddleX = ((this.Width / 2) - (paddleWidth / 2));
            int paddleY = (this.Height - paddleHeight) - 60;
            int paddleSpeed = 8;
            paddle = new Paddle(paddleX, paddleY, paddleWidth, paddleHeight, paddleSpeed, Color.White);

            // setup starting ball values
            int ballX = this.Width / 2 - 10;
            int ballY = this.Height - paddle.height - 80;

            // Creates a new ball
            int xSpeed = 3;
            int ySpeed = 3;
            int ballSize = 20;
            ball = new Ball(ballX, ballY, xSpeed, ySpeed, ballSize);
            ballList.Add(ball);

            #region Creates blocks for generic level. Need to replace with code that loads levels.
            
            //TODO - replace all the code in this region eventually with code that loads levels from xml files
            
            blocks.Clear();
            int x = 10;

            while (blocks.Count < 12)
            {
                x += 57;
                Block b1 = new Block(x, 10, 1, Color.White);
                blocks.Add(b1);
            }

            #endregion

            // start the game engine loop
            gameTimer.Enabled = true;
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            Brayden();
            // Move the paddle
            if (leftArrowDown && paddle.x > 0)
            {
                paddle.Move("left");
            }
            if (rightArrowDown && paddle.x < (this.Width - paddle.width))
            {
                paddle.Move("right");
            }

            if(!rightArrowDown && !leftArrowDown)
            {
                paddle.lastMove = "none";
            }

            // Move ball 
            ball.Move(); 

            // Check for collision with top and side walls
            ball.WallCollision(this);

            // Check for ball hitting bottom of screen
            for(int i = ballList.Count-1; i >= 0; i--)
            {
                if (ballList[i].BottomCollision(this))
                {
                    ballList.RemoveAt(i);
                }
            }

            if(ballList.Count == 0)
            {
                lives--;
                ball.x = ((paddle.x - (ball.size / 2)) + (paddle.width / 2));
                ball.y = (this.Height - paddle.height) - 85;
                ballList.Add(ball);
                if (lives <= 0)
                {
                    gameTimer.Enabled = false;
                    OnEnd();
                }
            }
            if (ball.BottomCollision(this))
            { 


                // Moves the ball back to origin
               

                
            }

            // Check for collision of ball with paddle, (incl. paddle movement)
            ball.PaddleCollision(paddle);

            // Check if ball has collided with any blocks
            foreach (Block b in blocks)
            {
                if (ball.BlockCollision(b))
                {

                    createPowerup("Scar", b.x + b.width/2 - powerSize/2, b.y + b.height / 2 - powerSize/2, powerSize);

                    blocks.Remove(b);

                    if (blocks.Count == 0)
                    {
                        gameTimer.Enabled = false;
                        OnEnd();
                    }

                    break;
                }
            }

            // Powerup actions
            runPowerupLoop();

            // Redraw the screen
            Refresh();
        }

        public void OnEnd()
        {
            // Goes to the game over screen
            Form form = this.FindForm();
            MenuScreen ps = new MenuScreen();
            
            ps.Location = new Point((form.Width - ps.Width) / 2, (form.Height - ps.Height) / 2);

            form.Controls.Add(ps);
            form.Controls.Remove(this);
        }

        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            // Draws paddle
            paddleBrush.Color = paddle.colour;
            e.Graphics.FillRectangle(paddleBrush, paddle.x, paddle.y, paddle.width, paddle.height);

            // Draws blocks
            foreach (Block b in blocks)
            {
                e.Graphics.FillRectangle(blockBrush, b.x, b.y, b.width, b.height);
            }

            // Draws ball
            e.Graphics.FillRectangle(ballBrush, (int)ball.x, (int)ball.y, (int)ball.size, (int)ball.size);

            // Draws powerups
            foreach (Powerup p in powers)
            {
                e.Graphics.DrawImage(images[p.appearance], p.x, p.y, p.size, p.size);
            }

            // Draws guns
            foreach (Gun g in guns)
            {
                e.Graphics.FillRectangle(paddleBrush, g.x, g.y, g.width, g.height);
            }

            // Draws bullets
            foreach (Bullet b in bullets)
            {
                e.Graphics.FillRectangle(paddleBrush, b.x, b.y, b.size, b.size);
            }
        }

        public void runPowerupLoop()
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

            //Creating powerups happens when the bricks break
            //Painting powerups happens in the paint method

            //// Powerup code
            for (int i = 0; i < powers.Count; i++)
            {
                // move powerup
                powers[i].Move();

                // check for collision of powerup with paddle
                if (powers[i].PaddleCollision(paddle) == true)
                {
                    powers[i].GivePowerup();
                    powers.RemoveAt(i);
                }

                try{ // remove offscreen powerups
                    if (powers[i].y > this.Height)
                    {
                        powers.RemoveAt(i);
                    }
                }catch{} // can probably be fixed with a break; but I am trying to remove those right now
            }

            #region code that should be in the game loop and used by everyone
            ////This code deletes blocks in what I think is a more proper way than just deleting a block when it is hit
            // remove blocks from power ups 
            for (int i = 0; i < blocks.Count; i++)
            {
                if (blocks[i].hp <= 0)
                {
                    blocks.RemoveAt(i);
                }
            }
            // end game if powerup causes it -- Repeat code from above that could be simplified
            if (blocks.Count == 0)
            {
                gameTimer.Enabled = false;
                OnEnd();
            }
            #endregion

            //// Gun code
            foreach (Gun g in guns)
            {
                // move to follow player
                g.Move();

                // fire if possible
                g.Shoot(g.gunType);

                // decrease life and remove if necessary
                g.lifeSpan--;
                if (g.lifeSpan == 0)
                {
                    guns.Remove(g);
                    break;
                }
            }

            //// Bullet code
            foreach (Bullet b in bullets)
            {
                // move bullets
                b.Move();

                // remove offscreen bullets
                if (b.y < -100)
                {
                    bullets.Remove(b);
                    break;
                }
            }

            // check if bullet hit block
            try
            {
                for (int i = 0; i < bullets.Count; i++)
                {
                    foreach (Block b in blocks)
                    {
                        if (bullets[i].Collision(b) == true)
                        {
                            // remove lives from blocks
                            b.hp--;

                            // add powerup created from bullet if the block was destroyed
                            if (b.hp <= 0)
                            {
                                createPowerup("Scar", b.x + b.width / 2 - powerSize / 2, b.y + b.height / 2 - powerSize / 2, powerSize);
                            }

                            // remove bullet if it cannot do anything anymore
                            bullets[i].damageVal--;

                            if (bullets[i].damageVal == 0)
                            {
                                bullets.RemoveAt(i);
                            }

                            // allow code to keep running even if the bullets are removed
                            if (bullets.Count == 0)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            catch { } //this code exists because I haven't yet fixed an issue where everything breaks when a bullet and ball hit a block at the same time
        }

        public void createPowerup(string powerName, int x, int y, int size) 
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

            // check to see if there was a valid powerup
            if (powerName == "Ammo" || powerName == "ChugJug" || powerName == "Scar" || powerName == "Shotgun" || powerName == "RocketLauncher" || powerName == "InfinityGauntlet")
            {   // assign appearance
                switch (powerName)
                {
                    case "Ammo":
                        appearance = 0;
                        break;

                    case "ChugJug":
                        appearance = 1;
                        break;

                    case "Scar":
                        appearance = 2;
                        break;

                    case "Shotgun":
                        appearance = 3;
                        break;

                    case "RocketLauncher":
                        appearance = 4;
                        break;

                    case "InfinityGauntlet":
                        appearance = 5;
                        break;
                }

                // create physical entity to for the player to collide with
                Powerup powerUp = new Powerup(powerName, x, y, size, appearance);
                powers.Add(powerUp);
            }
        }

        public void onStartPowerup()
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

            //set values
            powers.Clear();
            bullets.Clear();
            ballList.Clear();
            guns.Clear();
        }
    }
}
