using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperBalll.Objects;

namespace SuperBalll
{
    public partial class Form1 : Form
    {
        Game game;
        public Form1()
        {
            InitializeComponent();
            Bounds = Screen.PrimaryScreen.Bounds;//Полноэкранность
            game = new Game(pictureBox1);
            game.WindowColor = Color.White;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Player pl = new Player();
            pl.Color = Color.Red;
            Selector selector = new Selector();
            pl.Selector = selector;
            game.Objects.Items.Add(pl);
            game.Objects.Items.Add(selector);
            game.Objects.Animated.Add(selector);

        }
    }
}
