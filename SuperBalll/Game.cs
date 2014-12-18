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
        Bitmap Image;
        Graphics G;
        PictureBox GameWindow;
        ObjectCollection Objects;

        /// <summary>
        /// Создает экземпляр игры, и связывает его с игровым окном, которым является PictureBox
        /// </summary>
        /// <param name="gameWindow">PictureBox - игровое окно</param>
        public Game(PictureBox gameWindow)
        {
            this.GameWindow = gameWindow;
            this.Image = new Bitmap(GameWindow.Width, GameWindow.Height);
        }
       
        public void Draw()
        {
            G.Clear(Color.White);
            foreach()
            GameWindow.Image = Image;
        }
        
    }
}
