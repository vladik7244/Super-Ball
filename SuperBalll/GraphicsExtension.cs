using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBalll
{
    static class GraphicsExtension
    {
        static void DrawDDD(this System.Drawing.Graphics g)
        {
            g.DrawEllipse(System.Drawing.Pens.AliceBlue, 0, 0, 100, 100);
        }
    }
}
