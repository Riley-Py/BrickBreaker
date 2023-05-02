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
        SolidBrush[] powerupBrushes = new SolidBrush[] { new SolidBrush(Color.Red), new SolidBrush(Color.Orange), new SolidBrush(Color.Yellow), new SolidBrush(Color.Green), new SolidBrush(Color.Blue), new SolidBrush(Color.Violet) };
        ////TO ADD IMAGES, CHANGE THIS ARRAY INTO AN IMAGE ARRAY AND FILL WITH THE IMAGES////
        
        #endregion

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
            int xSpeed = 6;
            int ySpeed = 6;
            int ballSize = 20;
            ball = new Ball(ballX, ballY, xSpeed, ySpeed, ballSize);

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

            // Move ball 
            ball.Move(); 

            // Check for collision with top and side walls
            ball.WallCollision(this);

            // Check for ball hitting bottom of screen
            if (ball.BottomCollision(this))
            {
                lives--;

                // Moves the ball back to origin
                ball.x = ((paddle.x - (ball.size / 2)) + (paddle.width / 2));
                ball.y = (this.Height - paddle.height) - 85;

                if (lives == 0)
                {
                    gameTimer.Enabled = false;
                    OnEnd();
                }
            }

            // Check for collision of ball with paddle, (incl. paddle movement)
            ball.PaddleCollision(paddle);

            // Check if ball has collided with any blocks
            foreach (Block b in blocks)
            {
                if (ball.BlockCollision(b))
                {
                    createPowerup("Shotgun", b.x + b.width/2 - powerSize/2, b.y + b.height / 2 - powerSize/2, powerSize);

                    blocks.Remove(b);

                    if (blocks.Count == 0)
                    {
                        gameTimer.Enabled = false;
                        OnEnd();
                    }

                    break;
                }
            }

            //powerup actions
            runLoopPowerup();

            //redraw the screen
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
            e.Graphics.FillRectangle(ballBrush, ball.x, ball.y, ball.size, ball.size);

            // Draws powerups
            foreach (Powerup p in powers)
            {
                e.Graphics.FillRectangle(powerupBrushes[p.appearance], p.x, p.y, p.size, p.size);
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

        public void runLoopPowerup()
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

            // move the powerups 
            foreach (Powerup p in powers)
            {
                p.Move();
            }

            // move the bullets 
            foreach (Bullet b in bullets)
            {
                b.Move();
            }

            // check if player has collided with any powerups 
            foreach (Powerup p in powers)
            {
                Rectangle powerRec = new Rectangle(p.x, p.y, p.size, p.size);
                Rectangle paddleRec = new Rectangle(paddle.x, paddle.y, paddle.width, paddle.height);

                // check for collision of powerup with paddle
                p.PaddleCollision(paddle);

                ////TO DO - Clean up this repeat code to remove the powerup////
                if (powerRec.IntersectsWith(paddleRec))
                {
                    powers.Remove(p);
                    break;
                }
            }

            // remove blocks from power ups 
            for (int i = 0; i < blocks.Count; i++)
            {
                if (blocks[i].hp <= 0)
                {
                    blocks.RemoveAt(i);
                }
            }

            // remove unused offscreen powerups
            foreach (Powerup p in powers)
            {
                if (p.y > this.Height)
                {
                    powers.Remove(p);
                        break;
                }
            }

            // end game if powerup causes it -- Repeat code from above that could be simplified
            if (blocks.Count == 0)
            {
                gameTimer.Enabled = false;
                OnEnd();
            }

            ////GUN CODE
            foreach (Gun g in guns)
            {
                //move to follow player
                g.Move();

                //decrease life and remove
                g.lifeSpan--;
                if (g.lifeSpan == 0)
                {
                    guns.Remove(g);
                }

                //fire if possible
                g.Shoot(g.gunType);
                break;
            }
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

            //assign appearance
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

            //create physical entity to for the player to collide with
            Powerup powerUp = new Powerup(powerName, x, y, size, appearance);
            powers.Add(powerUp);
        }
    }
}
