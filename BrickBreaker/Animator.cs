using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    internal class Animator
    {
        int x, y;

        int frameCount;
        int duration;
        AnimationStyle animationStyle;

        public Animator(int x, int y, int frameCount, Color c)
        {

        }
        public Animator(int x, int y, int frameCount, Bitmap[] bitmaps)
        {

        }
    }

    enum AnimationStyle
    {
        Bitmap = 0,
        Particle = 1
    }
}
