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

        public Game(PictureBox gameWindow)
        {
            this.GameWindow = gameWindow;
            this.Image = new Bitmap(GameWindow.Width, GameWindow.Height);
        }
       
        public void Draw()
        {
            G.Clear(Color.White);

            GameWindow.Image = Image;
        }
        
    }
}
