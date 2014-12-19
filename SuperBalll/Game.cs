using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace SuperBalll
{
    class Game
    {


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
          
        }

        void GameWindow_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (GameObject obj in Objects.Items)
            {
                obj.MouseUp(e.Button,e.Location);
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
            foreach(GameObject obj in Objects.Items)
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
            foreach(IAnimation obj in Objects.Animated)
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
  
    }
}
