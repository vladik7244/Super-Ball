using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace SuperBalll.Objects
{
    public class Player : GameObject
    {
        private int size = 32;
        Color color;

        Objects.Selector selector;
        /// <summary>
        /// Селектор, который используется игроком для управления
        /// </summary>
        internal Objects.Selector Selector
        {
            get { return selector; }
            set { selector = value; }
        }
        /// <summary>
        /// Цвет игрока
        /// </summary>
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        /// <summary>
        /// переопределение метода рисования игрока (рисуем шар)
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(System.Drawing.Graphics g)
        {
            RectangleF rectangle = new RectangleF(Location, new Size(size, size));
            g.FillEllipse(new SolidBrush(Color), rectangle);
            g.DrawEllipse(new Pen(Brushes.Black, 3), rectangle);
            //g.DrawImage(Image.FromFile("sprite.png"), Location);
        }

        /// <summary>
        /// Тут будать описываться действия пользователя для шага
        /// </summary>
        public override void Step()
        {
            base.Step();
        }
        public override void KeyDown(Keys key)
        {
            if (key == Keys.Space)
            {

            }
        }
        public override void MouseDown(MouseButtons mb, Point loc)
        {
            if (mb == MouseButtons.Left)
            {
                this.Selector.Location = new Point(loc.X - 64, loc.Y - 64);
                this.Selector.AnimationStep = 0.2f;
                
                //this.Selector.IsVisible = true;
            }
            if (mb == MouseButtons.Right)
            {

                
                //this.Selector.IsVisible = true;
            }
        }
        public override void MouseUp(MouseButtons mb, Point loc)
        {
            if (mb == MouseButtons.Left)
            {
                this.Selector.AnimationStep = -0.1f;
                this.Selector.MouseUp(mb, loc);
                //this.Selector.IsVisible = false;
            }

        }
        public override void MouseMove(Point loc)
        {
           
        }
    }
}
