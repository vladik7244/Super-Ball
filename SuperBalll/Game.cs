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
        }
        /// <summary>
        /// Создает экземпляр игры, и связывает его с игровым окном, которым является PictureBox
        /// </summary>
        /// <param name="gameWindow">PictureBox - игровое окно</param>
        public void Draw()
        {
            G.Clear(Color.White);
            foreach(GameObject obj in Objects.Items)
            {
                obj.Draw(G);
            }
            GameWindow.Image = Image;
        }
        
    }
}
