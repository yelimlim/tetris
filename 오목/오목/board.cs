using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 오목
{
    class board
    {
        public Point top;
        public Point bottom;
        public Point left;
        public Point right;

        public board()
        {
        }

        public void show(Graphics g)
        {
            top.X = 0;
            bottom.X = 600;
            for (top.Y = 0; top.Y < 600; top.Y += 30)
            {
                bottom.Y = top.Y;
                g.DrawLine(Pens.Black, top, bottom);
            }

            left.Y = 0;
            right.Y = 600;
            for (left.X = 0; left.X < 600; left.X += 30)
            {
                right.X = left.X;
                g.DrawLine(Pens.Black, left, right);
            }
            
        }
    }
}
