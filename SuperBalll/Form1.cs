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
        
        public Form1()
        {
            InitializeComponent();
            Bounds = Screen.PrimaryScreen.Bounds;//Полноэкранность
            Program.game = new Game(pictureBox1);
            Program.game.WindowColor = Color.White;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Player pl = new Player();
            pl.Color = Color.Red;
            Selector selector = new Selector(pl);
            pl.Selector = selector;
            Program.game.Objects.Items.Add(pl);
            Program.game.Objects.Items.Add(selector);
            Program.game.Objects.Animated.Add(selector);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
