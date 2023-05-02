using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class Ball
    {
        public double x, y, xSpeed, ySpeed, size, score;
        public double speedCap = 8;
        public double speedMin = 0.3;
        public double paddleMoveOffset = 0.55;
        public Color colour;

        List<Ball> ballList = new List<Ball>();

        public static Random rand = new Random();

        public Ball(double _x, double _y, double _xSpeed, double _ySpeed, double _ballSize)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
            size = _ballSize;

        }

        public void Move()
        {
            x = x + xSpeed;
            y = y + ySpeed;
        }

        public Rectangle DoubleRectangle(double x, double y, double width, double height)
        {
            return new Rectangle((int)x, (int)y, (int)width, (int)height);
        }
        public bool BlockCollision(Block b)
        {
            Rectangle blockRec = new Rectangle(b.x, b.y, b.width, b.height);
            Rectangle ballRec = DoubleRectangle(x, y, size, size);

            if (ballRec.IntersectsWith(blockRec))
            {
                if (ySpeed >0)
                {
                    x = b.x - 0;
                }
                ySpeed *= -1;
                score++;
            }

            return blockRec.IntersectsWith(ballRec);
        }

        public void PaddleCollision(Paddle p)
        {
            Rectangle ballRec = DoubleRectangle(x, y, size, size);
            Rectangle paddleRec = new Rectangle(p.x, p.y, p.width, p.height);

            Rectangle leftPaddleRec = new Rectangle(p.x, p.y, p.width / 2, p.height);
            Rectangle rightPaddleRec = new Rectangle(p.x + (p.width/2), p.y, p.width / 2, p.height);

            if (ballRec.IntersectsWith(paddleRec))
            {
                if(ySpeed > 0)
                {
                    y = p.y - size;
                }
                ySpeed *= -1;
                if (p.lastMove == "right")
                {
                    xSpeed += paddleMoveOffset;
                }
                if (p.lastMove == "left")
                {
                    xSpeed -= paddleMoveOffset;
                }
                
                if (ballRec.IntersectsWith(leftPaddleRec))
                {
                    if(xSpeed > 0)
                    {
                        xSpeed *= 1+p.curve;
                    }
                    else
                    {
                        xSpeed *= 1 - p.curve;
                    }
                    
                }
                if (ballRec.IntersectsWith(rightPaddleRec))
                {
                    if (xSpeed < 0)
                    {
                        xSpeed *= 1 - p.curve;
                    }
                    else
                    {
                        xSpeed *= 1 + p.curve;
                    }
                }
                if(xSpeed > speedCap)
                {
                    xSpeed = speedCap;
                }
                else if(xSpeed < -speedCap)
                {
                    xSpeed = -speedCap;
                }
                else if(xSpeed < speedMin && xSpeed >= 0)
                {
                    xSpeed = speedMin;
                }
                else if(xSpeed > -speedMin && xSpeed < 0)
                {
                    xSpeed = -speedMin;
                }
                
            }
            
        }

        public void WallCollision(UserControl UC)
        {
            // Collision with left wall
            if (x <= 0)
            {
                xSpeed *= -1;
            }
            // Collision with right wall
            if (x >= (UC.Width - size))
            {
                xSpeed *= -1;
            }
            // Collision with top wall
            if (y <= 2)
            {
                ySpeed *= -1;
            }
        }

        public bool BottomCollision(UserControl UC)
        {
            Boolean didCollide = false;

            if (y >= UC.Height)
            {
                didCollide = true;
            }

            return didCollide;
        }

    }
}
