using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace SuperBalll.Objects
{
    public class Selector : GameObject, IAnimation
    {
        public Selector(Player player)
        {
            this.player = player;
            this.IsVisible = true;
            actions.Add(new SelectorItem(Color.Red, () => { player.Speed = new PointF(0, -10); },"Jump"));
            actions.Add(new SelectorItem(Color.Green, () => { player.Acceleration= new PointF(0,0); },"Ungravity"));
            actions.Add(new SelectorItem(Color.Violet, () => { player.Acceleration = new PointF(0, 0.4f); }, "Gravity"));
            actions.Add(new SelectorItem(Color.Blue, () => { player.Speed=new PointF(0,0); },"Stop"));
        }
        Player player;
        List<SelectorItem> actions = new List<SelectorItem>();
        /// <summary>
        /// Список действий, которые может выполнять пользователь
        /// </summary>
        internal List<SelectorItem> Actions
        {
            get { return actions; }
            set { actions = value; }
        }

        int nearestItem;
        public override void Draw(System.Drawing.Graphics g)
        {
            if (IsVisible)
            {
                g.TranslateTransform(Location.X + 64, Location.Y + 64);

                g.DrawArc(new System.Drawing.Pen(new SolidBrush(Color.FromArgb(Convert.ToInt32(255 * Animation), Color.Blue)), 8), new RectangleF(-64, -64, 128, 128), -90, Animation * 360);

                nearestItem = GetNearestItem();
                for (int i = 0; i < actions.Count; i++)
                {
                    g.RotateTransform(-360 * i / actions.Count);

                    g.TranslateTransform(128, 0);
                    g.RotateTransform(360 * i / actions.Count);
                    if (i != nearestItem) { g.ScaleTransform(0.8f, 0.8f); }
                    Actions[i].Draw(g,Animation);
                    if (i != nearestItem) { g.ScaleTransform(1f / 0.8f, 1f / 0.8f); }
                    g.RotateTransform(-360 * i / actions.Count);
                    g.TranslateTransform(-128, 0);
                    g.RotateTransform(360 * i / actions.Count);
                }

                //g.DrawString(nearestItem.ToString(), new Font("Segoe UI", 14), Brushes.Blue, new PointF(0, 0));

               
                g.TranslateTransform(-Location.X, -Location.Y);
                g.ResetTransform();
            }
        }
        /// <summary>
        /// Возвращает ближайший элемент селектора к мышке
        /// </summary>
        /// <returns>-1, если такого элемента нет</returns>
        private int GetNearestItem()
        {
            float angle = Game.GetPointAngle(new Point(Convert.ToInt32(Location.X) + 64, Convert.ToInt32(Location.Y) + 64), Program.game.MousePosition);
            float[] angles = new float[actions.Count];
            for (int i = 0; i < actions.Count; i++)
            {
                angles[i] = Game.SubstactAngle(angle, (float)i / (float)actions.Count * 360);
         
            }
            int min = 0;

            for (int i = 1; i < angles.Length; i++)
            {
                if (angles[i] < angles[min]) { min = i; }
            }
            if (Game.GetPointLength(Program.game.MousePosition, new Point(Convert.ToInt32(Location.X) + 64, Convert.ToInt32(Location.Y) + 64)) < 64) min = -1;

            return min;

        }

        public override void MouseDown(System.Windows.Forms.MouseButtons mb, Point loc)
        {

        }

        public override void MouseUp(System.Windows.Forms.MouseButtons mb, Point loc)
        {
            if (nearestItem != -1)
            {
                if (actions[nearestItem].Action != null)
                {
                    actions[nearestItem].Action();
                    player.Color = actions[nearestItem].Color;
                }
            }
        }


        public override void Step()
        {
            if (Animation == 0)
            {
                IsVisible = false;
            }
            else
            {
                IsVisible = true;
            }

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
    public class SelectorItem
    {
        public Color Color{get;set;}
        public string Text { get; set; }
        public Action Action { get; set; }
    
        public SelectorItem(Color color, Action action, string text)
        {
            this.Color = color;
            this.Action = action;
            this.Text = text;
        }

       
        public void Draw(System.Drawing.Graphics g,float Animation)
        {
            
            g.FillEllipse(new SolidBrush(Color), new RectangleF(-20*Animation, -20*Animation, 40*Animation, 40*Animation));
            g.DrawString(Text, Program.font, Brushes.Blue, new PointF(0, 30),Program.stringFormat);
        }
    }
}
