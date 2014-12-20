using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperBalll;
using System.Drawing;

namespace testApp
{
    class Program
    {
        static void Main(string[] args)
        {
            float a1, a2;
            while(true)
            {
                a1 = (float)Convert.ToDouble(Console.ReadLine());
                a2 = (float)Convert.ToDouble(Console.ReadLine());
                Console.WriteLine(Game.SubstactAngle(a1,a2).ToString()+"\n------");
            }
           // Console.WriteLine(SuperBalll.Game.GetPointLength(new PointF(100, 100), new PointF(200, 200)));

            Console.ReadLine();
        }
    }
}
