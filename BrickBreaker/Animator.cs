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
        public int x, y;

        protected int frameCount;
        protected int duration;
        protected AnimationStyle animationStyle;
        

        public Animator(int x, int y, int frameCount)
        {

        }
        
        public Animator(int x, int y, int frameCount, Bitmap[] bitmaps)
        {
            animationStyle = AnimationStyle.Bitmap;
        }
    }

    internal class BitmapAnimator : Animator
    {
        Bitmap[] bitmaps;
        public BitmapAnimator(int x, int y, int frameCount, Bitmap[] bmps) :base(x, y, frameCount)
        {
            animationStyle = AnimationStyle.Particle;

            
        }
    }
  
    internal class ParticleAnimator : Animator
    {
        Color color;

        public ParticleAnimator(int x, int y, int frameCount, Color c) : base(x, y, frameCount)
        {
            animationStyle = AnimationStyle.Particle;


        }
    }

    enum AnimationStyle
    {
        Bitmap = 0,
        Particle = 1
    }
}
