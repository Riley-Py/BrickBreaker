using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
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

        private Point deltaPoint(Point p1, Point p2)
        {
            return new Point(Math.Abs(p2.X - p1.X), Math.Abs(p2.Y - p1.Y));
        }
        private double distSq(Point p1, Point p2)
        {
            return Math.Abs(p2.X - p1.X) + Math.Abs(p2.Y - p1.Y);
        }
        public bool BlockCollision(Block b)
        {
            Rectangle blockRec = new Rectangle(b.x, b.y, b.width, b.height);
            Rectangle ballRec = DoubleRectangle(x, y, size, size);
            bool intersects = blockRec.IntersectsWith(ballRec);
            if (intersects)
            {
                BlockUnintersectorinator(b.x, b.y, b.width, b.height);

            }
            //if (ballRec.IntersectsWith(blockRec))
            //{
            //    if (ySpeed > 0)
            //    {
            //        x = b.x - 0;
            //    }
            //    ySpeed *= -1;
            //    score++;
            //}

            return intersects;
        }

        private void BlockUnintersectorinator(int bX, int bY, int bW, int bH)
        {
            int realX = (int)(x + size);
            int realY = (int)(y + size);


            Point ballPoint = new Point((realX), (realY));

            Point[] corners =
            {
                new Point(bX, bY), //topleft
                new Point(bX + bW, bY), //topright
                new Point(bX, bY + bH), //bottomleft
                new Point(bX + bW, bY + bH)  //bottomright
            };
            int[] distanceSq = new int[4];
            for (int i = 0; i < corners.Length; i++)
            {
                distanceSq[i] = Math.Abs(realX - corners[i].X) + Math.Abs(realY - corners[i].Y);
            }
            int closestIndex = 0;

            for (int i = 0; i < distanceSq.Length; i++)
            {
                if (distanceSq[i] < distanceSq[closestIndex])
                {
                    closestIndex = i;
                }
            }
            int cX = corners[closestIndex].X;
            int cY = corners[closestIndex].Y;
            Point deltaCorner = deltaPoint(corners[closestIndex], ballPoint);
            // 0 : top left
            // 1 : top right
            // 2: bottom left
            // 3: bottom right
            if (closestIndex == 0) 
            {
                //if(deltaCorner.X < deltaCorner.Y) //top
                if(realX < cX+size)
                {
                    y = cY - (2 * size);
                    ySpeed *= -1;
                }

                else //left
                {
                    x = cX - (2 * size);
                    xSpeed *= -1;
                }
                
            }
            else if (closestIndex == 1) // 
            {
                //if (deltaCorner.X < deltaCorner.Y) //top
                if(realX > cX + size)
                {
                    y = cY - (2 * size);
                    ySpeed *= -1;
                }

                else //right
                {
                    x = cX;
                    xSpeed *= -1;
                }
                y = cY;
                ySpeed *= -1;
            }
            else if (closestIndex == 2) 
            {
                //if (deltaCorner.X < deltaCorner.Y) //bottom
                if (realX < cX + size)
                {
                    y = cY;
                    ySpeed *= -1;
                }

                else //left
                {
                    x = cX - (2 * size);
                    xSpeed *= -1;
                }
            }
            else if (closestIndex == 3) 
            
            {
                //if (deltaCorner.X < deltaCorner.Y) //bottom
                if (realX > cX + size)
                {
                    y = cY;
                    ySpeed *= -1;
                }

                else //right
                {
                    x = cX;
                    xSpeed *= -1;
                }
            }

        }
        private void BlockUnintersectorinatorV2(int bX, int bY, int bW, int bH)
        {
            int realX = (int)(x + size);
            int realY = (int)(y + size);


            PointF ballPoint = new PointF((realX), (realY));

            PointF[] corners =
            {
                new Point(bX, bY), //topleft
                new Point(bX + bW, bY), //topright
                new Point(bX, bY + bH), //bottomleft
                new Point(bX + bW, bY + bH)  //bottomright
            };

            double[] distances =
            {
                FindDistanceToSegment(ballPoint, corners[0],corners[1]),//top
                FindDistanceToSegment(ballPoint, corners[0],corners[2]),//left
                FindDistanceToSegment(ballPoint, corners[2],corners[3]),//bottom
                FindDistanceToSegment(ballPoint, corners[1],corners[3]) //right
            };
            int[] distanceSq = new int[4];
            for (int i = 0; i < corners.Length; i++)
            {
                distanceSq[i] = (int)(Math.Abs(realX - corners[i].X) + Math.Abs(realY - corners[i].Y));
            }
            int closestIndex = 0;

            for (int i = 0; i < distances.Length; i++)
            {
                if (distances[i] < distances[closestIndex])
                {
                    closestIndex = i;
                }
            }
            // 0 : top 
            // 1 : left
            // 2: bottom
            // 3: right
            if (closestIndex == 0)
            {
                ySpeed *= -1;
                y = corners[0].Y - 2 * size;


            }
            else if (closestIndex == 1) // 
            {
               xSpeed *= -1;
                x = corners[0].X - 2 * size;
            }
            else if (closestIndex == 2)
            {
                ySpeed *= -1;
                y = corners[3].Y;
            }
            else if (closestIndex == 3)

            {
                xSpeed *= -1;
                x = corners[3].X;
            }

        }
        private double FindDistanceToSegment(
        PointF pt, PointF p1, PointF p2)
        {
            PointF closest;
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            if ((dx == 0) && (dy == 0))
            {
                // It's a point not a line segment.
                closest = p1;
                dx = pt.X - p1.X;
                dy = pt.Y - p1.Y;
                return Math.Sqrt(dx * dx + dy * dy);
            }

            // Calculate the t that minimizes the distance.
            float t = ((pt.X - p1.X) * dx + (pt.Y - p1.Y) * dy) /
                (dx * dx + dy * dy);

            // See if this represents one of the segment's
            // end points or a point in the middle.
            if (t < 0)
            {
                closest = new PointF(p1.X, p1.Y);
                dx = pt.X - p1.X;
                dy = pt.Y - p1.Y;
            }
            else if (t > 1)
            {
                closest = new PointF(p2.X, p2.Y);
                dx = pt.X - p2.X;
                dy = pt.Y - p2.Y;
            }
            else
            {
                closest = new PointF(p1.X + t * dx, p1.Y + t * dy);
                dx = pt.X - closest.X;
                dy = pt.Y - closest.Y;
            }

            return Math.Sqrt(dx * dx + dy * dy);
        }
        public void PaddleCollision(Paddle p)
        {
            Rectangle ballRec = DoubleRectangle(x, y, size, size);
            Rectangle paddleRec = new Rectangle(p.x, p.y, p.width, p.height);

            Rectangle leftPaddleRec = new Rectangle(p.x, p.y, p.width / 2, p.height);
            Rectangle rightPaddleRec = new Rectangle(p.x + (p.width / 2), p.y, p.width / 2, p.height);

            if (ballRec.IntersectsWith(paddleRec))
            {
                if (ySpeed > 0)
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
                    if (xSpeed > 0)
                    {
                        xSpeed *= 1 + p.curve;
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
                if (xSpeed > speedCap)
                {
                    xSpeed = speedCap;
                }
                else if (xSpeed < -speedCap)
                {
                    xSpeed = -speedCap;
                }
                else if (xSpeed < speedMin && xSpeed >= 0)
                {
                    xSpeed = speedMin;
                }
                else if (xSpeed > -speedMin && xSpeed < 0)
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
