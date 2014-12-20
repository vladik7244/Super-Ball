using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperBalll
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {     
            stringFormat.Alignment = System.Drawing.StringAlignment.Center;
            stringFormat.LineAlignment = System.Drawing.StringAlignment.Center;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
       
        }

        public static Game game;
        public static System.Drawing.Font font = new System.Drawing.Font("Segoe UI", 14);
        public static System.Drawing.StringFormat stringFormat = new System.Drawing.StringFormat();
    }
}
