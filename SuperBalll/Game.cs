using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace SuperBalll
{
    public class Game
    {
        public Point MousePosition;

        Timer StepTimer;

        Color windowColor;
        /// <summary>
        /// Цвет фона игрового окна
        /// </summary>
        public Color WindowColor
        {
            get { return windowColor; }
            set { windowColor = value; }
        }
        Bitmap image;
        /// <summary>
        /// Главный холст (картинка всего игрового поля)
        /// </summary>
        public Bitmap Image
        {
            get { return image; }
            set { image = value; }
        }

        /// <summary>
        /// Графика, на ней будут происходить все отрисовки
        /// </summary>
        private Graphics G;

        /// <summary>
        /// PictureBox - игровое окно
        /// </summary>
        PictureBox GameWindow;

        ObjectCollection objects;
        /// <summary>
        /// Список текущих игровых объектов
        /// </summary>
        internal ObjectCollection Objects
        {
            get { return objects; }
            set { objects = value; }
        }

        /// <summary>
        /// Создает экземпляр игры, и связывает его с игровым окном, которым является PictureBox
        /// </summary>
        /// <param name="gameWindow">PictureBox - игровое окно</param>
        public Game(PictureBox gameWindow)
        {
            this.GameWindow = gameWindow;
            this.Image = new Bitmap(GameWindow.Width, GameWindow.Height);
            this.G = Graphics.FromImage(Image);
            this.Objects = new ObjectCollection();
            this.windowColor = Color.Black;
            this.StepTimer = new Timer();

            this.StepTimer.Interval = 17;

            this.StepTimer.Tick += StepTimer_Tick;

            this.StepTimer.Start();
            this.GameWindow.MouseDown += GameWindow_MouseDown;
            this.GameWindow.MouseUp += GameWindow_MouseUp;
            this.GameWindow.MouseMove += GameWindow_MouseMove;

        }

        void GameWindow_MouseMove(object sender, MouseEventArgs e)
        {
            MousePosition = e.Location;
        }

        void GameWindow_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (GameObject obj in Objects.Items)
            {
                obj.MouseUp(e.Button, e.Location);
            }
        }

        void GameWindow_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (GameObject obj in Objects.Items)
            {
                obj.MouseDown(e.Button, e.Location);
            }
        }

        void StepTimer_Tick(object sender, EventArgs e)
        {
            Step();
            Draw();
        }


        /// <summary>
        /// Создает экземпляр игры, и связывает его с игровым окном, которым является PictureBox
        /// </summary>
        /// <param name="gameWindow">PictureBox - игровое окно</param>
        public void Draw()
        {
            G.Clear(windowColor);
            foreach (GameObject obj in Objects.Items)
            {
                obj.Draw(G);
            }
            GameWindow.Image = Image;
        }
        /// <summary>
        /// Игровой шаг
        /// </summary>
        public void Step()
        {
            foreach (IAnimation obj in Objects.Animated)
            {
                if (obj.Animation <= 1 && obj.Animation >= 0) obj.Animation += obj.AnimationStep;
                obj.Animation = Math.Min(1, Math.Max(0, obj.Animation));
            }

            foreach (GameObject obj in Objects.Items)
            {
                obj.Step();
            }

        }

        /*  public void KeyUp()
          {
              foreach (GameObject obj in Objects.Items)
              {
                  obj.KeyUp();
              }
          }
          public void keyDown()
          {
              foreach (GameObject obj in Objects.Items)
              {
                  obj.KeyDown();
              }
          }*/
        /// <summary>
        /// Возвращает угол между двумя точками
        /// </summary>
        /// <param name="p1">Певрая точка</param>
        /// <param name="p2">Вторая точка</param>
        /// <returns> угол между двумя точками</returns>
        public static float GetPointAngle(PointF p1, PointF p2)
        {
            //return (float)Math.Acos((p2.X - p1.X) / GetPointLength(p1, p2)) * 180 / (float)Math.PI;
            if (p2.Y < p1.Y)
                return (float)Math.Acos((p2.X - p1.X) / GetPointLength(p1, p2)) * 180 / (float)Math.PI;
            else
                return 360f - (float)Math.Acos((p2.X - p1.X) / GetPointLength(p1, p2)) * 180 / (float)Math.PI;
        }
        /// <summary>
        /// Возвращает расстояние между двумя точками
        /// </summary>
        /// <param name="p1">Певрая точка</param>
        /// <param name="p2">Вторая точка</param>
        /// <returns>расстояние между двумя точками</returns>
        public static float GetPointLength(PointF p1, PointF p2)
        {
            return (float)Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));
        }
        /// <summary>
        /// Возвращает разницу между двумя углами
        /// </summary>
        /// <param name="a1">угол 1</param>
        /// <param name="a2">угол 2</param>
        /// <returns>разницу между двумя углами</returns>
        public static float SubstactAngle(float a, float b)
        {
           /* float aa1 = (float)(Math.Acos(Math.Cos(a1 * Math.PI / 180)) * 180f / Math.PI);
            float aa2 = (float)(Math.Acos(Math.Cos(a2 * Math.PI / 180)) * 180f / Math.PI);
            return Math.Abs(aa2 - aa1);*/
            float r1, r2;
            if (a > b) { r1 = a - b; r2 = b - a + 360; } else { r1 = b - a; r2 = a - b + 360; }
            return Math.Min(r1, r2);
        }
        public static PointF LengthDir(float length,float angle)
        {
            return new PointF((float)Math.Cos(angle * Math.PI / 180) * length, (float)Math.Sin(angle * Math.PI / 180) * length);
        }
    }
}
