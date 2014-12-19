using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace SuperBalll.Objects
{
    class Selector:GameObject,IAnimation
    {
        public Selector()
        {
            this.IsVisible = true; 
        }

        public override void Draw(System.Drawing.Graphics g)
        {
            if(IsVisible)
            g.DrawArc(new System.Drawing.Pen(new SolidBrush(Color.FromArgb(Convert.ToInt32(255*Animation),Color.Blue)), 8), new RectangleF(Location, new Size(128, 128)),-90,Animation*360);
           
        }
        public override void Step()
        {

            base.Step();
        }



        private float animation;

        public float Animation
        {
            get { return animation; }
            set { animation = value; }
        }

        private float animationStep;

        public float AnimationStep
        {
            get { return animationStep; }
            set { animationStep = value; }
        }
    
    }
}
