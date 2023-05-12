using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
     class HealthBar
    {
        public int progress;
        public Color hpColor = Color.Green;
        public Color backColor = Color.Gray;
        public int x, y, w, h;
        public HealthBar() 
        { 

        }

        public int setProgress(int hp, int maxHp)
        {
            return (int)(((double)hp) / ((double)maxHp)) * 100;
        }
    }
}
