using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BrickBreaker
{
    public class Block
    {
        public int width = 50;
        public int height = 25;

        public int x;
        public int y; 
        public int hp;
        public Color colour;
        public Powerup powerup;

        public static Random rand = new Random();

        public Block(int _x, int _y, int _hp, Color _colour, Powerup powerup)
        {
            x = _x;
            y = _y;
            hp = _hp;
            colour = _colour;
        }
        public Block(int _x, int _y, int _hp, Color _colour)
        {
            x = _x;
            y = _y;
            hp = _hp;
            colour = _colour;
        }
        public Block(int _x, int _y, int _w, int _h, int _hp, Color _colour)
        {
            x = _x;
            y = _y;
            hp = _hp;
            width = _w;
            height = _h;
            colour = _colour;
        }

        private Color HPToColor(int hitPoints)
        {
            switch (hitPoints)
            {
                case 1:
                    return Color.Gray;
                case 2:
                    return Color.Green;
                case 3:
                    return Color.Blue;
                case 4:
                    return Color.Purple;
                case 5:
                    return Color.Gold;
                default:
                    return Color.White;
            }
        }
        /// <summary>
        /// Converting powerups to images to be used for editing
        /// </summary>
        /// <param name="powerup"></param>
        /// <returns></returns>
        
    }
}
